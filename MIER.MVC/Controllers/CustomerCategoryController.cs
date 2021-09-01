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

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch)
        {
            List<CustomerCategory> model = new List<CustomerCategory>();

            model = _customerCategoryRepo.GetAll();

            if (listSearch != null)
            {
                model = model.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())).ToList();
            }

            List<CustomerCategoriesVM> list = new List<CustomerCategoriesVM>();
            foreach (var item in model)
            {
                var viewModel = new CustomerCategoriesVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsTaxable = item.IsTaxable
                };

                list.Add(viewModel);
            }

            return Json(list.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCategoryVM viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new CustomerCategory
                    {
                        Name = viewModel.Name,
                        IsTaxable = viewModel.IsTaxable,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now
                    };

                    _customerCategoryRepo.Create(model);
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
            var model = _customerCategoryRepo.GetById(id);
            var viewModel = new CustomerCategoryVM
            {
                Id = model.Id,
                Name = model.Name,
                IsTaxable = model.IsTaxable
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(CustomerCategoryVM viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = _customerCategoryRepo.GetById(viewModel.Id);

                    model.Name = viewModel.Name;
                    model.IsTaxable = viewModel.IsTaxable;
                    model.UpdateBy = _userManager.GetUserName(User);
                    model.UpdateTime = DateTime.Now;

                    _customerCategoryRepo.Update(model);
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



    }
}
