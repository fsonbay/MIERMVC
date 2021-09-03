using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.ProductionStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class ProductionStatusController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private ProductionStatusRepo _productionStatusRepo;

        public ProductionStatusController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _productionStatusRepo = new ProductionStatusRepo(context);

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<ProductionStatus> m = new List<ProductionStatus>();

            if (showInactive)
            {
                m = _productionStatusRepo.GetAll();
            }
            else
            {
                m = _productionStatusRepo.GetAllActive();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())).ToList();
            }

            List<ProductionStatusesVM> list = new List<ProductionStatusesVM>();
            foreach (var i in m)
            {
                var viewModel = new ProductionStatusesVM
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsActive = i.IsActive,
                    InsertBy = i.InsertBy,
                    InsertTime = i.InsertTime,
                    UpdateTime = i.UpdateTime,
                    UpdateBy = i.UpdateBy
            };

                list.Add(viewModel);
            }

            return Json(list.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            ProductionStatusVM vm = new ProductionStatusVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ProductionStatusVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new ProductionStatus
                    {
                        Name = vm.Name,
                        IsActive = vm.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now
                    };

                    _productionStatusRepo.Create(m);
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
            var m = _productionStatusRepo.GetById(id);
            var vm = new ProductionStatusVM
            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductionStatusVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _productionStatusRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.IsActive = vm.IsActive;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _productionStatusRepo.Update(m);
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

        private void ConfigureVM(ProductionStatusVM vm)
        {
            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }
    }
}
