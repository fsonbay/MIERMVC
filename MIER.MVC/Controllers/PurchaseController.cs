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

        public PurchaseController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _purchaseRepo = new PurchaseRepo(context);
            _purchaseLineRepo = new PurchaseLineRepo(context);
            _vendorRepo = new VendorRepo(context);
            _paymentMethodRepo = new PaymentMethodRepo(context);
            _salesOrderRepo = new SalesOrderRepo(context);
        }

        public IActionResult Index()
        {
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
                    LinesName = item.LinesName,
                    Amount = item.Amount.ToString("N0"),
                    Date = item.Date,
                    IsActive = item.IsActive,
                    InsertBy = item.InsertBy,
                    InsertTime = item.InsertTime,
                    UpdateBy = item.UpdateBy,
                    UpdateTime = item.UpdateTime
                };

                purchasesVMList.Add(purchasesVM);
            }

            return Json(purchasesVMList.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            Purchase model = new Purchase();
            var viewModel = ConfigureVM(model);
            return View(viewModel);
        }

        private PurchaseVM ConfigureVM(Purchase model)
        {
            var purchaseVM = new PurchaseVM();
            var purchaseLineVM = new PurchaseLineVM();
            var purchaseLineVMList = new List<PurchaseLineVM>();


            //GET PURCHASE LOOKUP
            var vendorList = new SelectList(_vendorRepo.GetAllActive().OrderBy(m => m.Name), "Id", "Name");
            var paymentMethodList = new SelectList(_paymentMethodRepo.GetOutsActive().OrderBy(m => m.Name), "Id", "Name");
            var openOrder = _salesOrderRepo.GetOpenActive().OrderBy(m => m.Number).ToList();
            IEnumerable<SelectListItem> openOrderItem = from s in openOrder
                            select new SelectListItem
                            {
                                Value = s.Id.ToString(),
                                Text = s.Customer.Name.ToString() + " - " + s.Number
                            };
            SelectList openOrderList = new SelectList(openOrderItem, "Value", "Text");

            //GET PURCHASE LINE LOOKUP
            var paymentMethod = _paymentMethodRepo.GetInsActive().OrderBy(m => m.Name);
            ViewData["PaymentMethod"] = new SelectList(paymentMethod, "Id", "Name");


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
                        Quantity = item.Quantity.ToString("N0"),
                        Price = item.Price.ToString("N0"),
                        Amount = item.Amount.ToString("N0"),
                        IsActive = true
                    };

                    //ADD SUB TO COLLECTION
                    purchaseLineVMList.Add(purchaseLineVM);
                }

                //CONVERT SALESORDER TO SALESORDERVM
                purchaseVM = new PurchaseVM
                {
                    Id = model.Id,
                    VendorId = model.VendorId,
                    SalesOrderId = model.SalesOrderId,
                    Number = model.Number,
                    Date = model.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Amount = model.Amount.ToString("N0"),
                    IsActive = model.IsActive,
                    PurchaseLines = purchaseLineVMList,
                    VendorList = vendorList,
                    OpenOrderList = openOrderList
                };
            }

            //INSERT MODE
            else
            {
                purchaseVM.Date = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                purchaseVM.IsActive = true;
                purchaseVM.VendorList = vendorList;
                purchaseVM.PaymentMethodList = paymentMethodList;
                purchaseVM.OpenOrderList = openOrderList;

                purchaseLineVM.Id = 0;
                purchaseLineVM.Name = "";
                purchaseLineVM.Description = "";
                purchaseLineVM.IsActive = true;

                purchaseLineVMList.Add(purchaseLineVM);
                purchaseVM.PurchaseLines = purchaseLineVMList;

            }

            return purchaseVM;
        }
    }
}
