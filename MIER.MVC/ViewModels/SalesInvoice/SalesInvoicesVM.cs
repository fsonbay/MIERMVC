using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesInvoice
{
    public class SalesInvoicesVM
    {
        public int? Id { get; set; }

        public string Number { get; set; }

        public string Customer { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        [Display(Name = "Orders")]
        public string LinesName { get; set; }

        [Display(Name = "Total")]
        public string Total { get; set; }

        [Display(Name = "Paid")]
        public string Paid { get; set; }

        [Display(Name = "Outstanding")]
        public string Outstanding { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public DateTime InsertTime { get; set; }

        public string InsertBy { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateBy { get; set; }

    }
}
