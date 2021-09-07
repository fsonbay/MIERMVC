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
        private SalesInvoiceRepo _salesInvoiceRepo;
        private CustomerRepo _customerRepo;
        private ProductionStatusRepo _productionStatusRepo;

        public SalesOrderController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _salesOrderRepo = new SalesOrderRepo(context);
            _salesInvoiceRepo = new SalesInvoiceRepo(context);
            _customerRepo = new CustomerRepo(context);
            _productionStatusRepo = new ProductionStatusRepo(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<SalesOrder> m = new List<SalesOrder>();

            if (showInactive)
            {
                m = _salesOrderRepo.GetAllIncludes();
            }
            else
            {
                m = _salesOrderRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Number.ToLower().Contains(listSearch.ToLower())
                                    || m.Customer.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.ProductionStatus.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.LinesName.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }

            List<SalesOrdersVM> list = new List<SalesOrdersVM>();
            foreach (var i in m)
            {
                var vm = new SalesOrdersVM
                {
                    Id = i.Id,
                    Number = i.Number,
                    Customer = i.Customer.Name,
                    ProductionStatus = i.ProductionStatus.Name,
                    LinesName = i.LinesName,
                    Date = i.Date,
                    Deadline = i.Deadline,
                    IsActive = i.IsActive,
                    InsertBy = i.InsertBy,
                    InsertTime = i.InsertTime,
                    UpdateBy = i.UpdateBy,
                    UpdateTime = i.UpdateTime
                };

                list.Add(vm);
            }

            return Json(list.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            SalesOrderVM vm = new SalesOrderVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(SalesOrderVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var order = new SalesOrder
                    {
                        Number = CreateSalesOrderNumber(vm.Date, vm.CustomerId),
                        CustomerId = vm.CustomerId,
                        ProductionStatusId = vm.ProductionStatusId,
                        Date = vm.Date,
                        Deadline = vm.Deadline,
                        Amount = vm.Amount,
                        IsActive = vm.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now,
                    };

                    //ITERATE LINES
                    var linesList = new List<SalesOrderLine>();
                    List<string> linesName = new List<string>();

                    foreach (var i in vm.SalesOrderLines.ToList())
                    {
                        //CREATE SUBS
                        var isActive = i.IsActive;
                        var name = i.Name;

                        if (!isActive)
                        {
                            //REMOVE FROM COLLECTION
                            vm.SalesOrderLines.Remove(i);
                        }
                        else
                        {
                            var salesOrderLine = new SalesOrderLine
                            {
                                Name = i.Name,
                                Description = i.Description,
                                Quantity = i.Quantity,
                                Price = i.Price,
                                Amount = i.Amount,
                                SalesOrderId = 0, //Default value will be replaced by actual value
                                IsActive = i.IsActive
                            };

                            //ADD SUB TO COLLECTION
                            linesName.Add(i.Name);
                            linesList.Add(salesOrderLine);
                        }
                    }

                    //ADD SUBS TO PARENT
                    order.LinesName = string.Join(", ", linesName);
                    order.SalesOrderLines = linesList;

                    _salesOrderRepo.Create(order);
                    var newOrderId = order.Id;

                    //INVOICE
                    var invoice = new SalesInvoice
                    {
                        SalesOrderId = newOrderId,
                        Date = order.Date,
                        DueDate = order.Deadline,
                        Total = order.Amount,
                        Paid = 0,
                        Outstanding = order.Amount,
                        LinesName = order.LinesName,
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
            var m = _salesOrderRepo.GetById(id);
            var vm = new SalesOrderVM
            {
                Id = m.Id,
                CustomerId = m.CustomerId,
                ProductionStatusId = m.ProductionStatusId,
                Number = m.Number,
                Date = m.Date,
                Deadline = m.Deadline,
                IsActive = m.IsActive
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(SalesOrderVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _salesOrderRepo.GetById(vm.Id);

                    m.Number = vm.Number;
                    m.CustomerId = vm.CustomerId;
                    m.ProductionStatusId = vm.ProductionStatusId;
                    m.Date = vm.Date;
                    m.Deadline = vm.Deadline;
                    m.IsActive = vm.IsActive;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _salesOrderRepo.Update(m);
                    TempData["Message"] = "Saved succesfully";
                }
                catch (Exception ex)
                {
                    var err = ex.InnerException.Message;
                    TempData["Message"] = ex.Message;
                }

            }
            return RedirectToAction("Index");

        }

        private void ConfigureVM(SalesOrderVM vm)
        {
            var customer = _customerRepo.GetAllActive().OrderBy(m => m.Name);
            var productionStatus = _productionStatusRepo.GetAllActive().OrderBy(m => m.Id);

            vm.CustomerList = new SelectList(customer, "Id", "Name");
            vm.ProductionStatusList = new SelectList(productionStatus, "Id", "Name");

            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                var salesOrderLine = new SalesOrderLine();
                var salesOrderLineList = new List<SalesOrderLine>();

                vm.ProductionStatusId = 1;
                vm.IsActive = true;

                salesOrderLine.Id = 0;
                salesOrderLine.Name = "";
                salesOrderLine.Description = "";
                salesOrderLine.IsActive = true;

                salesOrderLineList.Add(salesOrderLine);
                vm.SalesOrderLines = salesOrderLineList;
            }
        }
        private string CreateSalesOrderNumber(DateTime salesOrderDate, int customerId)
        {
            string prefix = "O" + salesOrderDate.ToString("yyyyMMdd");
            int custOrderCount = _salesOrderRepo.CountCustomerOrder(customerId) + 1;

            return prefix + '-' + customerId + '-' + custOrderCount;
        }

    }
}
