using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.VendorCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class VendorCategoryController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private VendorCategoryRepo _customerCategoryRepo;

        public VendorCategoryController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _customerCategoryRepo = new VendorCategoryRepo(context);

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<VendorCategory> m = new List<VendorCategory>();

            if (showInactive)
            {
                m = _customerCategoryRepo.GetAll();
            }
            else
            {
                m = _customerCategoryRepo.GetAllActive();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())).ToList();
            }

            List<VendorCategoriesVM> list = new List<VendorCategoriesVM>();
            foreach (var i in m)
            {
                var viewModel = new VendorCategoriesVM
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsActive = i.IsActive
                };

                list.Add(viewModel);
            }

            return Json(list.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            VendorCategoryVM vm = new VendorCategoryVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(VendorCategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new VendorCategory
                    {
                        Name = vm.Name,
                        IsActive = vm.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now
                    };

                    _customerCategoryRepo.Create(m);
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
            var m = _customerCategoryRepo.GetById(id);
            var vm = new VendorCategoryVM
            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(VendorCategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _customerCategoryRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.IsActive = vm.IsActive;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _customerCategoryRepo.Update(m);
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

        private void ConfigureVM(VendorCategoryVM vm)
        {
            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }
    }
}
