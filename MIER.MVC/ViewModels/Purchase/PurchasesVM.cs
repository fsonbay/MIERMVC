using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.Purchase
{
    public class PurchasesVM
    {
        public int? Id { get; set; }

        public string Number { get; set; }

        public string Vendor { get; set; }

        public string RelatedOrder { get; set; }

        public string Payment { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Purchases")]
        public string LinesName { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public DateTime InsertTime { get; set; }

        public string InsertBy { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateBy { get; set; }

    }
}
