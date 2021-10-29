using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private VendorRepo _vendorRepo;
        private VendorCategoryRepo _vendorCategoryRepo;

        public VendorController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _vendorRepo = new VendorRepo(context);
            _vendorCategoryRepo = new VendorCategoryRepo(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<Vendor> m = new List<Vendor>();

            if (showInactive)
            {
                m = _vendorRepo.GetAllIncludes();
            }
            else
            {
                m = _vendorRepo.GetAllActiveIncludes();
            }

            if (listSearch != null)
            {
                m = m.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())
                                    || m.Phone != null && m.Phone.ToLower().Contains(listSearch.ToLower())
                                    || m.Description != null && m.Description.ToLower().Contains(listSearch.ToLower())
                                    || m.VendorCategory.Name.ToLower().Contains(listSearch.ToLower())
                                    ).ToList();
            }

            List<VendorsVM> list = new List<VendorsVM>();
            foreach (var item in m)
            {
                var vm = new VendorsVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone,
                    Description = item.Description,
                    IsActive = item.IsActive,
                    VendorCategory = item.VendorCategory.Name,
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
            VendorVM vm = new VendorVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(VendorVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new Vendor
                    {
                        Name = vm.Name,
                        Phone = vm.Phone,
                        Description = vm.Description,
                        IsActive = vm.IsActive,
                        VendorCategoryId = vm.VendorCategoryId,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now,
                    };
                    _vendorRepo.Create(m);
                    TempData["Message"] = "Saved succesfully";
                }
                catch (Exception ex)
                {

                    TempData["Message"] = ex.Message;
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var m = _vendorRepo.GetById(id);
            var vm = new VendorVM
            {
                Id = m.Id,
                Name = m.Name,
                Phone = m.Phone,
                Description = m.Description,
                IsActive = m.IsActive,
                VendorCategoryId = m.VendorCategoryId,
            };

            ConfigureVM(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(VendorVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var m = _vendorRepo.GetById(vm.Id);

                    m.Name = vm.Name;
                    m.Phone = vm.Phone;
                    m.Description = vm.Description;
                    m.IsActive = vm.IsActive;
                    m.VendorCategoryId = vm.VendorCategoryId;
                    m.UpdateBy = _userManager.GetUserName(User);
                    m.UpdateTime = DateTime.Now;

                    _vendorRepo.Update(m);
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

        private void ConfigureVM(VendorVM vm)
        {
            var vendorCategory = _vendorCategoryRepo.GetAllActive().OrderBy(m => m.Name);
            vm.VendorCategoryList = new SelectList(vendorCategory, "Id", "Name");

            //Default values for insert mode
            if (!vm.IsEditMode)
            {
                vm.IsActive = true;
            }
        }
    }
}
