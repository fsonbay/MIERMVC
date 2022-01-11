using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Data;
using MIER.MVC.Data.Repos;
using MIER.MVC.Models;
using MIER.MVC.ViewModels.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private PaymentMethodRepo _paymentMethodRepo;

        public PaymentMethodController(AppDbContext context,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _paymentMethodRepo = new PaymentMethodRepo(context);

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List([DataSourceRequest] DataSourceRequest request, string listSearch, bool showInactive)
        {
            List<PaymentMethod> paymentMethodList = new List<PaymentMethod>();

            if (showInactive)
            {
                paymentMethodList = _paymentMethodRepo.GetAll();
            }
            else
            {
                paymentMethodList = _paymentMethodRepo.GetAllActive();
            }

            if (listSearch != null)
            {
                paymentMethodList = paymentMethodList.Where(m => m.Name.ToLower().Contains(listSearch.ToLower())).ToList();
            }

            List<PaymentMethodsVM> PaymentMethodsVMList = new List<PaymentMethodsVM>();
            foreach (var item in paymentMethodList)
            {
                var paymentMethodsVM = new PaymentMethodsVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    In = item.In,
                    Out = item.Out,
                    IsActive = item.IsActive,
                    InsertBy = item.InsertBy,
                    InsertTime = item.InsertTime,
                    UpdateBy = item.UpdateBy,
                    UpdateTime = item.UpdateTime
                };

                PaymentMethodsVMList.Add(paymentMethodsVM);
            }

            return Json(PaymentMethodsVMList.ToDataSourceResult(request));

        }

        public IActionResult Create()
        {
            PaymentMethodVM vm = new PaymentMethodVM();
            ConfigureVM(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(PaymentMethodVM paymentMethodVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var paymentMethod = new PaymentMethod
                    {
                        Name = paymentMethodVM.Name,
                        Code = paymentMethodVM.Code,
                        In = paymentMethodVM.In,
                        Out = paymentMethodVM.Out,
                        IsActive = paymentMethodVM.IsActive,
                        InsertBy = _userManager.GetUserName(User),
                        InsertTime = DateTime.Now,
                        UpdateBy = _userManager.GetUserName(User),
                        UpdateTime = DateTime.Now
                    };

                    _paymentMethodRepo.Create(paymentMethod);
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
            var paymentMethod = _paymentMethodRepo.GetById(id);
            var paymentMethodVM = new PaymentMethodVM
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Name,
                Code = paymentMethod.Code,
                In = paymentMethod.In,
                Out = paymentMethod.Out,
                IsActive = paymentMethod.IsActive
            };

            ConfigureVM(paymentMethodVM);

            return View(paymentMethodVM);
        }

        [HttpPost]
        public IActionResult Update(PaymentMethodVM paymentMethodVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var paymentMethod = _paymentMethodRepo.GetById(paymentMethodVM.Id);

                    paymentMethod.Name = paymentMethodVM.Name;
                    paymentMethod.Code = paymentMethodVM.Code;
                    paymentMethod.In = paymentMethodVM.In;
                    paymentMethod.Out = paymentMethodVM.Out;
                    paymentMethod.IsActive = paymentMethodVM.IsActive;
                    paymentMethod.UpdateBy = _userManager.GetUserName(User);
                    paymentMethod.UpdateTime = DateTime.Now;

                    _paymentMethodRepo.Update(paymentMethod);
                    TempData["Message"] = "Saved succesfully";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = ex.Message;
                }
            }
            return RedirectToAction("Index");

        }

        private void ConfigureVM(PaymentMethodVM paymentMethodVM)
        {
            //Default values for insert mode
            if (!paymentMethodVM.IsEditMode)
            {
                paymentMethodVM.IsActive = true;
            }
        }
    }
}
