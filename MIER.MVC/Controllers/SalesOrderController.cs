using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.SalesOrder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MIER.MVC.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private SalesOrderRepo _salesOrderRepo;
        private SalesOrderLineRepo _salesOrderLineRepo;
        private SalesInvoiceRepo _salesInvoiceRepo;
        private CustomerRepo _customerRepo;
        private ProductionStatusRepo _productionStatusRepo;
        private ProductRepo _productRepo;
        private MachineRepo _machineRepo;
        private MaterialRepo _materialRepo;

        public SalesOrderController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _salesOrderRepo = new (context);
            _salesOrderLineRepo = new (context);
            _salesInvoiceRepo = new (context);
            _customerRepo = new (context);
            _productionStatusRepo = new (context);
            _productRepo = new (context);
            _machineRepo = new(context);
            _materialRepo = new(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<SalesOrder> salesOrderList = new List<SalesOrder>();

            if (showInactive)
            {
                salesOrderList = _salesOrderRepo.GetAllIncludes();
            }
            else
            {
                salesOrderList = _salesOrderRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                salesOrderList = salesOrderList.Where(m => m.Number.ToLower().Contains(listSearch.ToLower())
                                    || m.Customer.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.ProductionStatus.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.LinesName.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }

            List<SalesOrdersVM> salesOrdersVMList = new List<SalesOrdersVM>();
            foreach (var item in salesOrderList)
            {
                var salesOrdersVM = new SalesOrdersVM
                {
                    Id = item.Id,
                    Number = item.Number,
                    Customer = item.Customer.Name,
                    ProductionStatus = item.ProductionStatus.Name,
                    LinesName = item.LinesName,
                    Amount = item.Amount.ToString("N0"),
                    Date = item.Date,
                    Deadline = item.Deadline,
                    IsActive = item.IsActive,
                    InsertBy = item.InsertBy,
                    InsertTime = item.InsertTime,
                    UpdateBy = item.UpdateBy,
                    UpdateTime = item.UpdateTime
                };

                salesOrdersVMList.Add(salesOrdersVM);
            }

            return Json(salesOrdersVMList.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            SalesOrder model = new SalesOrder();
            var viewModel = ConfigureVM(model);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(SalesOrderVM viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var salesOrder = new SalesOrder
                    {


                        Number = CreateSalesOrderNumber(DateTime.Parse(viewModel.Date), viewModel.CustomerId),
                        CustomerId = viewModel.CustomerId,
                        ProductionStatusId = viewModel.ProductionStatusId,
                        Date = DateTime.Parse(viewModel.Date),
                        Deadline = DateTime.Parse(viewModel.Deadline),
                        Amount = decimal.Parse(viewModel.Amount.Replace(".", "")),
                        IsActive = viewModel.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now,
                    };

                    //ITERATE LINES
                    var salesOrderLineList = new List<SalesOrderLine>();
                    List<string> linesName = new List<string>();

                    foreach (var item in viewModel.SalesOrderLines.ToList())
                    {
                        //CREATE SUBS
                        var isActive = item.IsActive;
                        var name = item.Name;

                        if (!isActive)
                        {
                            //REMOVE FROM COLLECTION
                            viewModel.SalesOrderLines.Remove(item);
                        }
                        else
                        {
                            var salesOrderLine = new SalesOrderLine
                            {
                                Name = item.Name,
                                Description = item.Description,
                                Quantity = decimal.Parse(item.Quantity.Replace(".", "")),
                                Price = decimal.Parse(item.Price.Replace(".", "")),
                                Amount = decimal.Parse(item.Amount.Replace(".", "")),
                                SalesOrderId = 0 //Default value will be replaced by actual value
                            };

                            //ADD SUB TO COLLECTION
                            linesName.Add(item.Name);
                            salesOrderLineList.Add(salesOrderLine);
                        }
                    }

                    //ADD SUBS TO PARENT
                    salesOrder.LinesName = string.Join(", ", linesName);
                    salesOrder.SalesOrderLines = salesOrderLineList;

                    _salesOrderRepo.Create(salesOrder);
                    var newOrderId = salesOrder.Id;

                    //INVOICE
                    var invoice = new SalesInvoice
                    {
                        SalesOrderId = newOrderId,
                        Number = salesOrder.Number.Substring(1),
                        Date = salesOrder.Date,
                        DueDate = salesOrder.Deadline,
                        Total = salesOrder.Amount,
                        Paid = 0,
                        Outstanding = salesOrder.Amount,
                        LinesName = salesOrder.LinesName,
                        IsActive = true,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now
                    };

                    _salesInvoiceRepo.Create(invoice);
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
            var model = _salesOrderRepo.GetByIdIncludes(id);
            var viewModel = ConfigureVM(model);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(SalesOrderVM viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //SALES ORDER
                    var salesOrder = _salesOrderRepo.GetById(viewModel.Id);
                    salesOrder.Number = viewModel.Number;
                    salesOrder.CustomerId = viewModel.CustomerId;
                    salesOrder.ProductionStatusId = viewModel.ProductionStatusId;
                    salesOrder.Date = DateTime.Parse(viewModel.Date);
                    salesOrder.Deadline = DateTime.Parse(viewModel.Deadline);
                    salesOrder.Amount = decimal.Parse(viewModel.Amount.Replace(".", ""));
                    salesOrder.IsActive = viewModel.IsActive;
                    salesOrder.UpdateBy = _userManager.GetUserName(User);
                    salesOrder.UpdateTime = DateTime.Now;

                    //SALES ORDER LINE
                    var salesOrderLineList = new List<SalesOrderLine>();
                    List<string> linesName = new List<string>();
                    foreach (var item in viewModel.SalesOrderLines.ToList())
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
                                var salesOrderLine = _salesOrderLineRepo.GetById(id);
                                _salesOrderLineRepo.Delete(salesOrderLine);
                            }

                            //Remove from collection
                            viewModel.SalesOrderLines.Remove(item);
                        }
                        else
                        {
                            var salesOrderLine = new SalesOrderLine
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description,
                                Quantity = decimal.Parse(item.Quantity.Replace(".", "")),
                                Price = decimal.Parse(item.Price.Replace(".", "")),
                                Amount = decimal.Parse(item.Amount.Replace(".", ""))
                            };


                            //ADD SUB TO COLLECTION
                            linesName.Add(item.Name);
                            salesOrderLineList.Add(salesOrderLine);
                        }
                    }

                    //ADD SUBS TO PARENT
                    salesOrder.LinesName = string.Join(", ", linesName);
                    salesOrder.SalesOrderLines = salesOrderLineList;

                    //UPDATE ORDER
                    _salesOrderRepo.Update(salesOrder);

                    //UPDATE INVOICE
                    var salesInvoice = _salesInvoiceRepo.GetBySalesOrderId(salesOrder.Id);
                    salesInvoice.Total = salesOrder.Amount;
                    salesInvoice.Outstanding = salesOrder.Amount - salesInvoice.Paid;
                    _salesInvoiceRepo.Update(salesInvoice);

                    //var salesInvoice = _salesInvoiceRepo.GetByID(salesOrder.SalesInvoiceID);
                    //var sumSalesInvoiceLines = _salesInvoiceRepo.SumSalesInvoiceLines(salesOrder.SalesInvoiceID);
                    //salesInvoice.TotalAmount = sumSalesInvoiceLines + salesOrder.TotalAmount;
                    //salesInvoice.OutstandingAmount = sumSalesInvoiceLines + salesOrder.TotalAmount - salesInvoice.PaidAmount;
                    //_salesInvoiceRepo.Update(salesInvoice);

                    TempData["Message"] = "Saved succesfully";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error : " + ex.Message;
                }

            }
            return RedirectToAction("Index");

        }

        private SalesOrderVM ConfigureVM(SalesOrder model)
        {
            var salesOrderVM = new SalesOrderVM();
            var salesOrderLineVM = new SalesOrderLineVM();
            var salesOrderLineVMList = new List<SalesOrderLineVM>();

            //GET LOOKUP LISTS (CUSTOMER & PRODUCTION STATUS)
            var customerList = new SelectList(_customerRepo.GetAllActive().OrderBy(m => m.Name), "Id", "Name");
            var productionStatusList = new SelectList(_productionStatusRepo.GetAllActive().OrderBy(m => m.Id), "Id", "Name");
            var machineList = new SelectList(_machineRepo.GetAll().OrderBy(m => m.Id), "Id", "Name");
            var materialList = new SelectList(_materialRepo.GetAll().OrderBy(m => m.Id), "Id", "Name");

            ViewData["Machine"] = new SelectList(machineList, "Id", "Name");
            ViewData["Material"] = new SelectList(materialList, "Id", "Name");

            //EDIT MODE
            if (model.Id != 0)
            {
                //CONVERT SALESORDERLINE TO SALESORDERLINEVM
                foreach (var item in model.SalesOrderLines.ToList())
                {
                    salesOrderLineVM = new SalesOrderLineVM
                    {
                        Id = item.Id,
                        SalesOrderId = item.SalesOrderId,
                        Name = item.Name,
                        Description = item.Description,
                        Quantity = item.Quantity.ToString("N0"),
                        Price = item.Price.ToString("N0"),
                        Amount = item.Amount.ToString("N0"),
                        IsActive = true
                    };

                    //ADD SUB TO COLLECTION
                    salesOrderLineVMList.Add(salesOrderLineVM);
                }

                //CONVERT SALESORDER TO SALESORDERVM
                salesOrderVM = new SalesOrderVM
                {
                    Id = model.Id,
                    CustomerId = model.CustomerId,
                    ProductionStatusId = model.ProductionStatusId,
                    Number = model.Number,
                    Date = model.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Deadline = model.Deadline.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Amount = model.Amount.ToString("N0"),
                    IsActive = model.IsActive,
                    SalesOrderLines = salesOrderLineVMList,
                    CustomerList = customerList,
                    ProductionStatusList = productionStatusList
                };
            }

            //INSERT MODE
            else
            {
                salesOrderVM.Date = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                salesOrderVM.Deadline = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                salesOrderVM.ProductionStatusId = 1;
                salesOrderVM.IsActive = true;
                salesOrderVM.CustomerList = customerList;
                salesOrderVM.ProductionStatusList = productionStatusList;

                salesOrderLineVM.Id = 0;
                salesOrderLineVM.Name = "";
                salesOrderLineVM.Description = "";
                salesOrderLineVM.IsActive = true;

                salesOrderLineVMList.Add(salesOrderLineVM);
                salesOrderVM.SalesOrderLines = salesOrderLineVMList;

            }

            return salesOrderVM;
        }

        private string CreateSalesOrderNumber(DateTime salesOrderDate, int customerId)
        {
            string prefix = "O" + salesOrderDate.ToString("yyyyMMdd");
            int custOrderCount = _salesOrderRepo.CountCustomerOrder(customerId) + 1;

            return prefix + '-' + customerId + '-' + custOrderCount;
        }

    }
}
