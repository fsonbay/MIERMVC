using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesInvoice
{
    public class SalesInvoiceCostVM
    {
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
