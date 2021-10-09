using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesInvoice
{
    public class SalesInvoicePaymentVM
    {
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }
        public int PaymentMethodId { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public bool IsActive { get; set; }

        public SelectList PaymentMethodList { get; set; }
    }
}
