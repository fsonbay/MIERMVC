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
            _materialRepo = new(context);
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

        public IActionResult Create()
        {
            MaterialVM vm = new MaterialVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(MaterialVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new Material
                    {
                        Name = vm.Name,
                        IsActive = vm.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now
                    };

                    _materialRepo.Create(m);
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

        public IActionResult Edit(int id)
        {
            var m = _materialRepo.GetById(id);
            var vm = new MaterialVM
            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(MaterialVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _materialRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.IsActive = vm.IsActive;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _materialRepo.Update(m);
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

        private void ConfigureVM(MaterialVM vm)
        {
            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }


    }
}
