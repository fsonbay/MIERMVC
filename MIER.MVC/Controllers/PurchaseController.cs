using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.Purchase;
using System;
using System.Collections.Generic;
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

        public PurchaseController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _purchaseRepo = new PurchaseRepo(context);
            _purchaseLineRepo = new PurchaseLineRepo(context);
            _vendorRepo = new VendorRepo(context);
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

            List<PurchasesVM> salesOrdersVMList = new List<PurchasesVM>();
            foreach (var item in purchaseList)
            {
                var salesOrdersVM = new PurchasesVM
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

                salesOrdersVMList.Add(salesOrdersVM);
            }

            return Json(salesOrdersVMList.ToDataSourceResult(request));

        }


    }
}
