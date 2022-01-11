using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.Purchase
{
    public class PurchaseVM
    {
        public int? Id { get; set; }

        [Display(Name = "Vendor")]
        [Required(ErrorMessage = "* Required")]
        public int VendorId { get; set; }

        [Display(Name = "Payment Method")]
        [Required(ErrorMessage = "* Required")]
        public int PaymentMethodId { get; set; }

        [Display(Name = "Related Order")]
        [Required(ErrorMessage = "* Required")]
        public int SalesOrderId { get; set; }

        public string Number { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Date { get; set; }

        public bool IsActive { get; set; }

        public string Amount { get; set; }

        public DateTime InsertTime { get; set; }

        public string InsertBy { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateBy { get; set; }

        public SelectList VendorList { get; set; }

        public SelectList PaymentMethodList { get; set; }

        public SelectList OpenOrderList { get; set; }

        public List<PurchaseLineVM> PurchaseLines { get; set; }
    }
}
