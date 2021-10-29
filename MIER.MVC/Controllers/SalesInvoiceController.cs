using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class SalesInvoiceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private SalesOrderRepo _salesOrderRepo;
        private SalesInvoiceRepo _salesInvoiceRepo;
        private PaymentMethodRepo _paymentMethodRepo;
        private SalesInvoicePaymentRepo _salesInvoicePaymentRepo;
        private SalesInvoiceCostRepo _salesInvoiceCostRepo;

        public SalesInvoiceController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _salesOrderRepo = new SalesOrderRepo(context);
            _salesInvoiceRepo = new SalesInvoiceRepo(context);
            _paymentMethodRepo = new PaymentMethodRepo(context);
            _salesInvoicePaymentRepo = new SalesInvoicePaymentRepo(context);
            _salesInvoiceCostRepo = new SalesInvoiceCostRepo(context);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<SalesInvoice> salesInvoiceList = new List<SalesInvoice>();

            if (showInactive)
            {
                salesInvoiceList = _salesInvoiceRepo.GetAllIncludes();
            }
            else
            {
                salesInvoiceList = _salesInvoiceRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                salesInvoiceList = salesInvoiceList.Where(m => m.Number.ToLower().Contains(listSearch.ToLower())
                                    || m.SalesOrder.Customer.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.LinesName.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }

            List<SalesInvoicesVM> salesInvoicesVMList = new List<SalesInvoicesVM>();
            foreach (var item in salesInvoiceList)
            {
                var salesInvoicesVM = new SalesInvoicesVM
                {
                    Id = item.Id,
                    Number = item.Number,
                    Customer = item.SalesOrder.Customer.Name,
                    LinesName = item.LinesName,
                    Date = item.Date,
                    DueDate = item.DueDate,
                    Total = item.Total.ToString("N0"),
                    Paid = item.Paid.ToString("N0"),
                    Outstanding = item.Outstanding.ToString("N0"),
                    IsActive = item.IsActive,
                    InsertBy = item.InsertBy,
                    InsertTime = item.InsertTime,
                    UpdateBy = item.UpdateBy,
                    UpdateTime = item.UpdateTime
                };

                salesInvoicesVMList.Add(salesInvoicesVM);
            }

            return Json(salesInvoicesVMList.ToDataSourceResult(request));

        }
        public IActionResult Edit(int id)
        {
            var model = _salesInvoiceRepo.GetByIdIncludes(id);
            var viewModel = ConfigureVM(model);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(SalesInvoiceVM viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //SALES INVOICE
                    var salesInvoice = _salesInvoiceRepo.GetById(viewModel.Id);
                    salesInvoice.Date = DateTime.Parse(viewModel.Date);
                    salesInvoice.DueDate = DateTime.Parse(viewModel.DueDate);
                    salesInvoice.UpdateBy = _userManager.GetUserName(User);
                    salesInvoice.UpdateTime = DateTime.Now;

                    //SALES INVOICE COST
                    var salesInvoiceCostList = new List<SalesInvoiceCost>();
                    foreach (var item in viewModel.SalesInvoiceCosts.ToList())
                    {
                        var salesInvoiceCost = new SalesInvoiceCost();

                        var id = item.Id;
                        var isActive = item.IsActive;
                        var name = item.Name;

                        if (!isActive)
                        {
                            //Existing item
                            if (id != 0)
                            {
                                //Delete from database
                                 salesInvoiceCost = _salesInvoiceCostRepo.GetById(id);
                                _salesInvoiceCostRepo.Delete(salesInvoiceCost);
                            }

                            //Remove from collection
                            viewModel.SalesInvoiceCosts.Remove(item);
                        }
                        else
                        {
                            salesInvoiceCost.Id = item.Id;
                            salesInvoiceCost.Name = item.Name;
                            salesInvoiceCost.Description = item.Description;
                            salesInvoiceCost.Quantity = decimal.Parse(item.Quantity.Replace(".", ""));
                            salesInvoiceCost.Price = decimal.Parse(item.Price.Replace(".", ""));
                            salesInvoiceCost.Amount = decimal.Parse(item.Amount.Replace(".", ""));

                            //Add to collection
                            salesInvoiceCostList.Add(salesInvoiceCost);
                        }
                    }

                    //Add cost list to parent
                    salesInvoice.SalesInvoiceCosts = salesInvoiceCostList;


                    //SALES INVOICE PAYMENT
                    var salesInvoicePaymentList = new List<SalesInvoicePayment>();
                    foreach(var item in viewModel.SalesInvoicePayments.ToList())
                    {
                        var salesInvoicePayment = new SalesInvoicePayment();

                        var id = item.Id;
                        var isActive = item.IsActive;
                        var name = item.Amount;

                        if (!isActive)
                        {
                            //Existing item
                            if (id != 0)
                            {
                                //Delete from database
                                salesInvoicePayment = _salesInvoicePaymentRepo.GetById(id);
                                _salesInvoicePaymentRepo.Delete(salesInvoicePayment);
                            }

                            //Remove from collection
                            viewModel.SalesInvoicePayments.Remove(item);
                        }
                        else
                        {
                            salesInvoicePayment.Id = item.Id;
                            salesInvoicePayment.PaymentMethodId = item.PaymentMethodId;
                            salesInvoicePayment.Date = DateTime.Parse(item.Date);
                            salesInvoicePayment.Amount = decimal.Parse(item.Amount.Replace(".", ""));

                            //Add to collection
                            salesInvoicePaymentList.Add(salesInvoicePayment);
                        }
                    }

                    //Add cost list to parent
                    salesInvoice.SalesInvoicePayments = salesInvoicePaymentList;

                    //UPDATE SALES INVOICE
                    _salesInvoiceRepo.Update(salesInvoice);
                    TempData["Message"] = "Saved succesfully";

                }
                catch (Exception ex)
                {
                    TempData["Message"] = ex.Message;
                }
            }

            return RedirectToAction("Index");
        }
        private SalesInvoiceVM ConfigureVM(SalesInvoice salesInvoice)
        {
            var salesInvoiceVM = new SalesInvoiceVM();
            var salesInvoiceLineVM = new SalesInvoiceLineVM();
            var salesInvoiceLineVMList = new List<SalesInvoiceLineVM>();
            var salesInvoiceCostVMList = new List<SalesInvoiceCostVM>();
            var salesInvoicePaymentVMList = new List<SalesInvoicePaymentVM>();

            //GET LOOKUP LISTS (PAYMENT METHOD)
            var paymentMethod = _paymentMethodRepo.GetAllActive().OrderBy(m => m.Name);
            ViewData["PaymentMethod"] = new SelectList(paymentMethod, "Id", "Name");

            //EDIT MODE
            if (salesInvoice.Id != 0)
            {
                //CONVERT LINE TO LINEVM
                foreach (var item in salesInvoice.SalesOrder.SalesOrderLines.ToList())
                {
                    //Assign SalesOrderLine values to SalesInvoiceLineVM
                    salesInvoiceLineVM = new SalesInvoiceLineVM
                    {
                        Id = item.Id,
                        SalesInvoiceId = salesInvoice.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Quantity = item.Quantity.ToString("N0"),
                        Price = item.Price.ToString("N0"),
                        Amount = item.Amount.ToString("N0")
                    };

                    //Add sub to list
                    salesInvoiceLineVMList.Add(salesInvoiceLineVM);
                }

                //CONVERT COST TO COSTVM
                //Cost exist
                if (salesInvoice.SalesInvoiceCosts.Count > 0)
                {
                    var salesInvoiceCostVM = new SalesInvoiceCostVM();

                    //Assign cost values to VM
                    foreach (var item in salesInvoice.SalesInvoiceCosts.ToList())
                    {
                        salesInvoiceCostVM = new SalesInvoiceCostVM
                        {
                            Id = item.Id,
                            SalesInvoiceId = item.SalesInvoiceId,
                            Name = item.Name,
                            Description = item.Description,
                            Price = item.Price.ToString("N0"),
                            Quantity = item.Quantity.ToString("N0"),
                            Amount = item.Amount.ToString("N0"),
                            IsActive = true
                        };

                        //Add sub to list
                        salesInvoiceCostVMList.Add(salesInvoiceCostVM);
                    }
                }

                //CONVERT PAYMENT TO PAYMENTVM
                //If payment exist
                if (salesInvoice.SalesInvoicePayments.Count > 0)
                {
                    var salesInvoicePaymentVM = new SalesInvoicePaymentVM();
                    //Assign payment values to VM
                    foreach (var item in salesInvoice.SalesInvoicePayments.ToList())
                    {
                        salesInvoicePaymentVM = new SalesInvoicePaymentVM
                        {
                            Id = item.Id,
                            SalesInvoiceId = item.SalesInvoiceId,
                            PaymentMethodId = item.PaymentMethodId,
                            Date = item.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                            Amount = item.Amount.ToString("N0"),
                            IsActive = true
                        };
                    }

                    //Add sub to list
                    salesInvoicePaymentVMList.Add(salesInvoicePaymentVM);
                }
                // If no existing payment create default values
                //else
                //{
                //    salesInvoicePaymentVM.Id = 0;
                //    salesInvoicePaymentVM.SalesInvoiceId = salesInvoice.Id;
                //    salesInvoicePaymentVM.PaymentMethodId = 1;
                //    salesInvoicePaymentVM.Amount = "0";
                //    salesInvoicePaymentVM.Date = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                //    salesInvoicePaymentVM.IsActive = true;
                //    salesInvoicePaymentVM.PaymentMethodList = paymentMethodList;

                //}



                //CONVERT SALESINVOICE TO SALESINVOICEVM
                salesInvoiceVM = new SalesInvoiceVM
                {
                    Id = salesInvoice.Id,
                    Number = salesInvoice.Number,
                    Date = salesInvoice.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    DueDate = salesInvoice.DueDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Total = salesInvoice.Total.ToString("N0"),
                    Paid = salesInvoice.Paid.ToString("N0"),
                    Outstanding = salesInvoice.Outstanding.ToString("N0"),
                    Customer = salesInvoice.SalesOrder.Customer.Name,
                    SalesOrderDate = salesInvoice.SalesOrder.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    SalesOrderDeadline = salesInvoice.SalesOrder.Deadline.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    SalesOrderAmount = salesInvoice.SalesOrder.Amount.ToString(),
                    SalesInvoiceLines = salesInvoiceLineVMList,
                    SalesInvoiceCosts = salesInvoiceCostVMList,
                    SalesInvoicePayments = salesInvoicePaymentVMList
                };
            }

            return salesInvoiceVM;

        }

    }
}
