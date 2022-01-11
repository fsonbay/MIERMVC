using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class MaterialController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private MaterialRepo _materialRepo;

        public MaterialController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _materialRepo = new MaterialRepo(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<Material> salesOrderList = new List<Material>();

            if (showInactive)
            {
                salesOrderList = _materialRepo.GetAllIncludes();
            }
            else
            {
                salesOrderList = _materialRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                salesOrderList = salesOrderList.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.TypesName.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }

            List<MaterialsVM> salesOrdersVMList = new List<MaterialsVM>();
            foreach (var item in salesOrderList)
            {
                var salesOrdersVM = new MaterialsVM
                {
                    Id = item.Id,
                    Name = item.Name,
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
