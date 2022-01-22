using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.Purchase
{
    public class PurchaseLineVM
    {
        public int Id { get; set; }

        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "* Required")]
        public int PurchaseCategoryId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Price { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Amount { get; set; }

        public bool IsActive { get; set; }

    }
}
