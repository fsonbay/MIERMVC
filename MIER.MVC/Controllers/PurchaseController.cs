using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.Purchase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private PurchaseRepo _purchaseRepo;
        private PurchaseLineRepo _purchaseLineRepo;
        private VendorRepo _vendorRepo;
        private PaymentMethodRepo _paymentMethodRepo;
        private SalesOrderRepo _salesOrderRepo;
        private PurchaseCategoryRepo _purchaseCategoryRepo;

        public PurchaseController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _purchaseRepo = new PurchaseRepo(context);
            _purchaseLineRepo = new PurchaseLineRepo(context);
            _vendorRepo = new VendorRepo(context);
            _paymentMethodRepo = new PaymentMethodRepo(context);
            _salesOrderRepo = new SalesOrderRepo(context);
            _purchaseCategoryRepo = new PurchaseCategoryRepo(context);
        }

        //protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        //{
        //    if (!string.IsNullOrEmpty(requestContext.HttpContext.Request["culture"]))
        //    {
        //        Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(requestContext.HttpContext.Request["culture"]);
        //    }
        //    base.Initialize(requestContext);
        //}


        public IActionResult Index()
        {
            var i = System.Threading.Thread.CurrentThread.CurrentCulture;
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<Purchase> purchaseList = new List<Purchase>();

            if (showInactive)
            {
                purchaseList = _purchaseRepo.GetAllIncludes();
            }
            else
            {
                purchaseList = _purchaseRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                purchaseList = purchaseList.Where(m => m.Number.ToLower().Contains(listSearch.ToLower())
                            || m.Vendor.Name.ToLower().Contains(listSearch.ToLower())
                            || m.LinesName.ToLower().Contains(listSearch.ToLower())
                            || m.PaymentMethod.Name.ToLower().Contains(listSearch.ToLower())
                            || m.SalesOrder.Customer.Name.ToLower().Contains(listSearch.ToLower())
                            || m.SalesOrder.Customer.Name.ToLower().Contains(listSearch.ToLower())
                            || m.SalesOrder.Number.ToLower().Contains(listSearch.ToLower())
                            ).ToList();
            }

            List<PurchasesVM> purchasesVMList = new List<PurchasesVM>();
            foreach (var item in purchaseList)
            {
                var purchasesVM = new PurchasesVM
                {
                    Id = item.Id,
                    Number = item.Number,
                    Vendor = item.Vendor.Name,
                    RelatedOrder = string.IsNullOrEmpty(item.SalesOrderId.ToString()) ? "N/A" : item.SalesOrder.Customer.Name + " - " + item.SalesOrder.Number,
                    Payment = string.IsNullOrEmpty(item.PaymentMethodId.ToString()) ? "N/A" : item.PaymentMethod.Name,
                    LinesName = item.LinesName,
                    //Amount = item.Amount.ToString("N0"),
                    Amount = item.Amount,
                    Date = item.Date,
                    IsActive = item.IsActive,
                    InsertBy = item.InsertBy,
                    InsertTime = item.InsertTime,
                    UpdateBy = item.UpdateBy,
                    UpdateTime = item.UpdateTime
                };

                purchasesVMList.Add(purchasesVM);
            }

            TempData["123"] = "666";

            var result = purchasesVMList.ToDataSourceResult(request);

            return Json(new 
            {
                Data = result.Data,
                Total = result.Total,
                AggregateResults = result.AggregateResults,
                Errors = result.Errors,
                myProperty1 = "extra value", // Add the extra value
            });


           // return Json(result);

            //return Json(purchasesVMList.ToDataSourceResult(request));

            //var result /// get the data;

            //var resultFinal = result.ToDataSourceResult(request);
            //return Json(new
            //{
            //    Data = resultFinal.Data,
            //    Total = resultFinal.Total,
            //    AggregateResults = resultFinal.AggregateResults,
            //    Errors = resultFinal.Errors,
            //    myProperty1 = "extra value", // Add the extra value
            //});

        }

        public IActionResult Create()
        {
            Purchase model = new Purchase();
            var viewModel = ConfigureVM(model);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PurchaseVM viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var purchase = new Purchase
                    {
                        Number = CreatePurchaseNumber(DateTime.Parse(viewModel.Date), viewModel.VendorId),
                        VendorId = viewModel.VendorId,
                        PaymentMethodId = viewModel.PaymentMethodId,
                        SalesOrderId = viewModel.SalesOrderId,
                        Date = DateTime.Parse(viewModel.Date),
                        Amount = decimal.Parse(viewModel.Amount.Replace(".", "")),
                        IsActive = viewModel.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now,
                    };

                    //ITERATE LINES
                    var purchaseLineList = new List<PurchaseLine>();
                    List<string> linesName = new List<string>();

                    foreach (var item in viewModel.PurchaseLines.ToList())
                    {
                        //CREATE SUBS
                        var isActive = item.IsActive;
                        var name = item.Name;

                        if (!isActive)
                        {
                            //REMOVE FROM COLLECTION
                            viewModel.PurchaseLines.Remove(item);
                        }
                        else
                        {
                            var purchaseLine = new PurchaseLine
                            {
                                Name = item.Name,
                                Description = item.Description,
                                PurchaseCategoryId = item.PurchaseCategoryId,
                                Quantity = decimal.Parse(item.Quantity.Replace(".", "")),
                                Price = decimal.Parse(item.Price.Replace(".", "")),
                                Amount = decimal.Parse(item.Amount.Replace(".", "")),
                                PurchaseId = 0 //Default value will be replaced by actual value
                            };

                            //ADD SUB TO COLLECTION
                            linesName.Add(item.Name);
                            purchaseLineList.Add(purchaseLine);
                        }
                    }

                    //ADD SUBS TO PARENT
                    purchase.LinesName = string.Join(", ", linesName);
                    purchase.PurchaseLines = purchaseLineList;

                    //CREATE
                    _purchaseRepo.Create(purchase);

                    //MESSAGE
                    TempData["Message"] = "Saved succesfully";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = ex.Message;
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = _purchaseRepo.GetByIdIncludes(id);
            var viewModel = ConfigureVM(model);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(PurchaseVM viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //PURCHASE
                    var purchase = _purchaseRepo.GetById(viewModel.Id);
                    purchase.Number = viewModel.Number;
                    purchase.VendorId = viewModel.VendorId;
                    purchase.SalesOrderId = viewModel.SalesOrderId;
                    purchase.PaymentMethodId = viewModel.PaymentMethodId;
                    purchase.Date = DateTime.Parse(viewModel.Date);
                    purchase.Amount = decimal.Parse(viewModel.Amount.Replace(".", ""));
                    purchase.IsActive = viewModel.IsActive;
                    purchase.UpdateBy = _userManager.GetUserName(User);
                    purchase.UpdateTime = DateTime.Now;

                    ////PURCHASE LINE
                    var purchaseLineList = new List<PurchaseLine>();
                    List<string> linesName = new List<string>();
                    foreach (var item in viewModel.PurchaseLines.ToList())
                    {
                        var id = item.Id;
                        var isActive = item.IsActive;
                        var name = item.Name;

                        if (!isActive)
                        {
                            //Existing item
                            if (id != 0)
                            {
                                //Delete from database
                                var purchaseLine = _purchaseLineRepo.GetById(id);
                                _purchaseLineRepo.Delete(purchaseLine);
                            }

                            //Remove from collection
                            viewModel.PurchaseLines.Remove(item);
                        }
                        else
                        {
                            var purchaseLine = new PurchaseLine
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description,
                                PurchaseCategoryId = item.PurchaseCategoryId,
                                Quantity = decimal.Parse(item.Quantity.Replace(".", "")),
                                Price = decimal.Parse(item.Price.Replace(".", "")),
                                Amount = decimal.Parse(item.Amount.Replace(".", ""))
                            };


                            //ADD SUB TO COLLECTION
                            linesName.Add(item.Name);
                            purchaseLineList.Add(purchaseLine);
                        }
                    }

                    //ADD SUBS TO PARENT
                    purchase.LinesName = string.Join(", ", linesName);
                    purchase.PurchaseLines = purchaseLineList;

                    //UPDATE
                    _purchaseRepo.Update(purchase);

                    //MESSAGE
                    TempData["Message"] = "Saved succesfully";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error : " + ex.Message;
                }

            }
            return RedirectToAction("Index");

        }

        private PurchaseVM ConfigureVM(Purchase model)
        {
            var purchaseVM = new PurchaseVM();
            var purchaseLineVM = new PurchaseLineVM();
            var purchaseLineVMList = new List<PurchaseLineVM>();

            //GET LOOKUPS
            var vendorList = _vendorRepo.GetAllActive().OrderBy(m => m.Name);
            var paymentMethodList = _paymentMethodRepo.GetOutsActive().OrderBy(m => m.Name);
            var purchaseCategoryList = _purchaseCategoryRepo.GetAll().OrderBy(c => c.Name);
            var openOrderList = _salesOrderRepo.GetOpenActive().OrderBy(m => m.Number).ToList();

            IEnumerable<SelectListItem> openOrderItem = from s in openOrderList
                                                        select new SelectListItem
                                                        {
                                                            Value = s.Id.ToString(),
                                                            Text = s.Customer.Name.ToString() + " - " + s.Number
                                                        };

            ViewData["Vendor"] = new SelectList(vendorList, "Id", "Name");
            ViewData["PaymentMethod"] = new SelectList(paymentMethodList, "Id", "Name");
            ViewData["OpenOrder"] = new SelectList(openOrderItem, "Value", "Text");
            ViewData["PurchaseCategory"] = new SelectList(purchaseCategoryList, "Id", "Name");

            //EDIT MODE
            if (model.Id != 0)
            {
                //CONVERT PURCHASELINE TO PURCHASELINEVM
                foreach (var item in model.PurchaseLines.ToList())
                {
                    purchaseLineVM = new PurchaseLineVM
                    {
                        Id = item.Id,
                        PurchaseId = item.PurchaseId,
                        Name = item.Name,
                        Description = item.Description,
                        PurchaseCategoryId = item.PurchaseCategoryId,
                        Quantity = item.Quantity.ToString("N0"),
                        Price = item.Price.ToString("N0"),
                        Amount = item.Amount.ToString("N0"),
                        IsActive = true
                    };

                    //ADD SUB TO COLLECTION
                    purchaseLineVMList.Add(purchaseLineVM);
                }

                //CONVERT PURCHASE TO PURCHASEVM
                purchaseVM = new PurchaseVM
                {
                    Id = model.Id,
                    VendorId = model.VendorId,
                    SalesOrderId = model.SalesOrderId,
                    PaymentMethodId = model.PaymentMethodId,
                    Number = model.Number,
                    Date = model.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Amount = model.Amount.ToString("N0"),
                    IsActive = model.IsActive,
                    PurchaseLines = purchaseLineVMList,
                };
            }

            //INSERT MODE
            else
            {
                purchaseVM.Date = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                purchaseVM.IsActive = true;
                purchaseLineVM.Id = 0;
                purchaseLineVM.Name = "";
                purchaseLineVM.Description = "";
                purchaseLineVM.PurchaseCategoryId = 0;
                purchaseLineVM.IsActive = true;

                purchaseLineVMList.Add(purchaseLineVM);
                purchaseVM.PurchaseLines = purchaseLineVMList;

            }

            return purchaseVM;
        }

        private string CreatePurchaseNumber(DateTime purchaseDate, int vendorID)
        {
            string prefix = "P" + purchaseDate.ToString("yyyyMMdd");
            int vendorOrderCount = _purchaseRepo.CountVendorOrder(vendorID) + 1;
            return prefix + '-' + vendorID + '-' + vendorOrderCount;
        }


    }
}
