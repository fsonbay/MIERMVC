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
            List<SalesInvoice> m = new List<SalesInvoice>();

            if (showInactive)
            {
                m = _salesInvoiceRepo.GetAllIncludes();
            }
            else
            {
                m = _salesInvoiceRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Number.ToLower().Contains(listSearch.ToLower())
                                    || m.SalesOrder.Customer.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.LinesName.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }

            List<SalesInvoicesVM> list = new List<SalesInvoicesVM>();
            foreach (var i in m)
            {
                var vm = new SalesInvoicesVM
                {
                    Id = i.Id,
                    Number = i.Number,
                    Customer = i.SalesOrder.Customer.Name,
                    LinesName = i.LinesName,
                    Date = i.Date,
                    DueDate = i.DueDate,
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

    }
}
