using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.EmployeePosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{

    public class EmployeePositionController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private EmployeePositionRepo _employeePositionRepo;

        public EmployeePositionController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _employeePositionRepo = new(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<EmployeePosition> m = new List<EmployeePosition>();

            if (showInactive)
            {
                m = _employeePositionRepo.GetAll();
            }
            else
            {
                m = _employeePositionRepo.GetAllActive();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())).ToList();
            }

            List<EmployeePositionsVM> list = new List<EmployeePositionsVM>();
            foreach (var i in m)
            {
                var viewModel = new EmployeePositionsVM
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
            EmployeePositionVM vm = new EmployeePositionVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(EmployeePositionVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new EmployeePosition
                    {
                        Name = vm.Name,
                        IsActive = vm.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now
                    };

                    _employeePositionRepo.Create(m);
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
            var m = _employeePositionRepo.GetById(id);
            var vm = new EmployeePositionVM
            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(EmployeePositionVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _employeePositionRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.IsActive = vm.IsActive;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _employeePositionRepo.Update(m);
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

        private void ConfigureVM(EmployeePositionVM vm)
        {
            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }

    }
}
