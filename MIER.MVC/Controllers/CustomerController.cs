using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private CustomerRepo _customerRepo;
        private CustomerCategoryRepo _customerCategoryRepo;

        public CustomerController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _customerRepo = new CustomerRepo(context);
            _customerCategoryRepo = new CustomerCategoryRepo(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<Customer> m = new List<Customer>();

            if (showInactive)
            {
                m = _customerRepo.GetAllIncludes();
            }
            else
            {
                m = _customerRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.Company.ToLower().Contains(listSearch.ToLower())
                                    || m.Phone.ToLower().Contains(listSearch.ToLower())
                                    || m.Description.ToLower().Contains(listSearch.ToLower())
                                    || m.CustomerCategory.Name.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }


            List<CustomersVM> list = new List<CustomersVM>();
            foreach (var item in m)
            {
                var vm = new CustomersVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Company = item.Company,
                    Phone = item.Phone,
                    Description = item.Description,
                    IsActive = item.IsActive,
                    CustomerCategory = item.CustomerCategory.Name,
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
            CustomerVM vm = new CustomerVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CustomerVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new Customer
                    {
                        Name = vm.Name,
                        Company = vm.Company,
                        Phone = vm.Phone,
                        Description = vm.Description,
                        IsActive = vm.IsActive,
                        CustomerCategoryId = vm.CustomerCategoryId,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now,
                    };
                    _customerRepo.Create(m);
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
            var m = _customerRepo.GetById(id);
            var vm = new CustomerVM
            {
                Id = m.Id,
                Name = m.Name,
                Company = m.Company,
                Phone = m.Phone,
                Description = m.Description,
                IsActive = m.IsActive,
                CustomerCategoryId = m.CustomerCategoryId,
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(CustomerVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _customerRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.Company = vm.Company;
                    m.Phone = vm.Phone;
                    m.Description = vm.Description;
                    m.IsActive = vm.IsActive;
                    m.CustomerCategoryId = vm.CustomerCategoryId;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _customerRepo.Update(m);
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

        private void ConfigureVM(CustomerVM vm)
        {
            var customerCategory = _customerCategoryRepo.GetAll().OrderBy(m => m.Name);
            vm.CustomerCategoryList = new SelectList(customerCategory, "Id", "Name");

            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }

    }
}

