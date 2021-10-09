using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesInvoice
{
    public class SalesInvoiceVM
    {
        public int? Id { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string DueDate { get; set; }

        public string Customer { get; set; }

        [Display(Name = "Order Date")]
        public string SalesOrderDate { get; set; }

        [Display(Name = "Deadline")]
        public string SalesOrderDeadline { get; set; }

        public string Total { get; set; }

        public string Paid { get; set; }

        public string Outstanding { get; set; }

        public DateTime UpdateTime { get; set; }
        public string UpdateBy { get; set; }

        public List<SalesInvoiceLineVM> SalesInvoiceLines { get; set; }
        public List<SalesInvoiceCostVM> SalesInvoiceCosts { get; set; }
        public List<SalesInvoicePaymentVM> SalesInvoicePayments { get; set; }
    }
}
