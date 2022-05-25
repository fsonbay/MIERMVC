using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesOrder
{
    public class SalesOrderLineVM
    {
        public int Id { get; set; }

        public int SalesOrderId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Material")]
        public int MaterialId { get; set; }

        [Display(Name = "Machine")]
        public int MachineId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Price { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Amount { get; set; }

        public bool IsActive { get; set; }
    }
}
