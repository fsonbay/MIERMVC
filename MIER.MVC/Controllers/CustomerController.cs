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
            List<Customer> model = new List<Customer>();

            if (showInactive)
            {
                model = _customerRepo.GetAllIncludes();
            }
            else
            {
                model = _customerRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                model = model.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.Company.ToLower().Contains(listSearch.ToLower())
                                    || m.Phone.ToLower().Contains(listSearch.ToLower())
                                    || m.Description.ToLower().Contains(listSearch.ToLower())
                                    || m.CustomerCategory.Name.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }


            List<CustomersVM> list = new List<CustomersVM>();
            foreach (var item in model)
            {
                var viewModel = new CustomersVM
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

                list.Add(viewModel);
            }

            return Json(list.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            CustomerVM viewModel = new CustomerVM();
            ConfigureVM(viewModel);
            return View(viewModel);
        }

        private void ConfigureVM(CustomerVM viewModel)
        {
            var customerCategory = _customerCategoryRepo.GetAll().OrderBy(m => m.Name);
            viewModel.CustomerCategoryList = new SelectList(customerCategory, "Id", "Name");

            //Default values for insert mode
            if (!viewModel.IsEditMode)
            {
                viewModel.IsActive = true;
            }
        }

    }


}

