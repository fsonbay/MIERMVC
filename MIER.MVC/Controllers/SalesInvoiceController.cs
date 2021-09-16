using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class SalesInvoiceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private SalesOrderRepo _salesOrderRepo;
        private SalesInvoiceRepo _salesInvoiceRepo;

        public SalesInvoiceController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _salesOrderRepo = new SalesOrderRepo(context);
            _salesInvoiceRepo = new SalesInvoiceRepo(context);
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

        private SalesInvoiceVM ConfigureVM(SalesInvoice salesInvoice)
        {
            var salesInvoiceVM = new SalesInvoiceVM();

            //EDIT MODE
            if (salesInvoice.Id != 0)
            {

                //CONVERT SALESINVOICE TO SALESINVOICEVM
                salesInvoiceVM = new SalesInvoiceVM
                {
                    Id = salesInvoice.Id,
                    Number = salesInvoice.Number,
                    Customer = salesInvoice.SalesOrder.Customer.Name,
                    Date = salesInvoice.Date,
                    DueDate = salesInvoice.DueDate
                };

            }


                return salesInvoiceVM;

        }


    }
}
