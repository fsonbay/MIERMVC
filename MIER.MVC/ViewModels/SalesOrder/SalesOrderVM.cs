using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesOrder
{
    public class SalesOrderVM
    {
        public bool IsEditMode => Id.HasValue;

        public int? Id { get; set; }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "* Required")]
        public int CustomerId { get; set; }

        [Display(Name = "Production Status")]
        [Required(ErrorMessage = "* Required")]
        public int ProductionStatusId { get; set; }

        public string Number { get; set; }

        public DateTime Date { get; set; }

        public bool IsActive { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime InsertTime { get; set; }

        public string InsertBy { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateBy { get; set; }

        public SelectList CustomerList { get; set; }
        public SelectList ProductionStatusList { get; set; }
    }
}
