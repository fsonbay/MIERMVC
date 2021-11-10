using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesInvoice
{
    public class SalesInvoiceCostVM
    {
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Price { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Amount")]
        public string CostAmount { get; set; }

        public bool IsActive { get; set; }
    }
}
