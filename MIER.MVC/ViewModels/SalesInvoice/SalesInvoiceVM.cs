using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesInvoice
{
    public class SalesInvoiceVM
    {
        public int? Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public string Customer { get; set; }


    }
}
