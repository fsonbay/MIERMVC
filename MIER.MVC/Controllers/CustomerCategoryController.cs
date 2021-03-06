using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.CustomerCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class CustomerCategoryController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private CustomerCategoryRepo _customerCategoryRepo;

        public CustomerCategoryController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _customerCategoryRepo = new CustomerCategoryRepo(context);

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<CustomerCategory> m = new List<CustomerCategory>();

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

            List<CustomerCategoriesVM> list = new List<CustomerCategoriesVM>();
            foreach (var item in m)
            {
                var vm = new CustomerCategoriesVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsTaxable = item.IsTaxable,
                    IsActive = item.IsActive,
                    InsertBy = item.InsertBy,
                    InsertTime = item.InsertTime,
                    UpdateBy = item.UpdateBy,
                    UpdateTime = item.UpdateTime
                };

                list.Add(vm);
            }

            return Json(list.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            CustomerCategoryVM vm = new CustomerCategoryVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CustomerCategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new CustomerCategory
                    {
                        Name = vm.Name,
                        IsTaxable = vm.IsTaxable,
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
            var vm = new CustomerCategoryVM
            {
                Id = m.Id,
                Name = m.Name,
                IsTaxable = m.IsTaxable,
                IsActive = m.IsActive
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(CustomerCategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _customerCategoryRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.IsTaxable = vm.IsTaxable;
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

        private void ConfigureVM(CustomerCategoryVM vm)
        {
            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }

    }
}
