using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private EmployeeRepo _employeeRepo;
        private EmployeePositionRepo _employeePositionRepo;

        public EmployeeController(AppDbContext context,
        UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _employeeRepo = new(context);
            _employeePositionRepo = new(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<Employee> m = new List<Employee>();

            if (showInactive)
            {
                m = _employeeRepo.GetAllIncludes();
            }
            else
            {
                m = _employeeRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())
                                    //|| m.Company != null && m.Company.ToLower().Contains(listSearch.ToLower())
                                    //|| m.Phone != null && m.Phone.ToLower().Contains(listSearch.ToLower())
                                    //|| m.Description != null && m.Description.ToLower().Contains(listSearch.ToLower())
                                    || m.EmployeePosition.Name.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }


            List<EmployeesVM> list = new();
            foreach (var item in m)
            {
                var vm = new EmployeesVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Position = item.EmployeePosition.Name,
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
            EmployeeVM vm = new EmployeeVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new Employee
                    {
                        Name = vm.Name,
                        Phone = vm.Phone,
                        IsActive = vm.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now,
                    };
                    _employeeRepo.Create(m);
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
            var m = _employeeRepo.GetById(id);
            var vm = new EmployeeVM
            {
                Id = m.Id,
                Name = m.Name,
                Phone = m.Phone,
                IsActive = m.IsActive
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(EmployeeVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _employeeRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.Phone = vm.Phone;
                    m.IsActive = vm.IsActive;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _employeeRepo.Update(m);
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

        private void ConfigureVM(EmployeeVM vm)
        {
            var employeePositionList = new SelectList(_employeePositionRepo.GetAllActive().OrderBy(m => m.Name), "Id", "Name");
            ViewData["EmployeePosition"] = employeePositionList;

            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }


    }
}
