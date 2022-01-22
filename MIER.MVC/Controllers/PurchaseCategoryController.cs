using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.PurchaseCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class PurchaseCategoryController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private PurchaseCategoryRepo _purchaseCategoryRepo;

        public PurchaseCategoryController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _purchaseCategoryRepo = new PurchaseCategoryRepo(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<PurchaseCategory> m = new List<PurchaseCategory>();

            if (showInactive)
            {
                m = _purchaseCategoryRepo.GetAll();
            }
            else
            {
                m = _purchaseCategoryRepo.GetAllActive();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())).ToList();
            }

            List<PurchaseCategoriesVM> list = new List<PurchaseCategoriesVM>();
            foreach (var i in m)
            {
                var viewModel = new PurchaseCategoriesVM
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
            PurchaseCategoryVM vm = new PurchaseCategoryVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(PurchaseCategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new PurchaseCategory
                    {
                        Name = vm.Name,
                        IsActive = vm.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now
                    };

                    _purchaseCategoryRepo.Create(m);
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
            var m = _purchaseCategoryRepo.GetById(id);
            var vm = new PurchaseCategoryVM
            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(PurchaseCategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _purchaseCategoryRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.IsActive = vm.IsActive;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _purchaseCategoryRepo.Update(m);
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

        private void ConfigureVM(PurchaseCategoryVM vm)
        {
            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }

    }
}
