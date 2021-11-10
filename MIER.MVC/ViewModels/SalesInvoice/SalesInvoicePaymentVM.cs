using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesInvoice
{
    public class SalesInvoicePaymentVM
    {
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }

        [Display(Name = "Payment Method")]
        [Required(ErrorMessage = "* Required")]
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Date { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Amount")]
        public string PaymentAmount { get; set; }

        public bool IsActive { get; set; }

        public SelectList PaymentMethodList { get; set; }
    }
}
