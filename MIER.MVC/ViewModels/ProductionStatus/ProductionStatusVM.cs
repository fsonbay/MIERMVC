using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.ProductionStatus
{
    public class ProductionStatusVM
    {
        public bool IsEditMode => Id.HasValue;

        public int? Id { get; set; }

        [Display(Name = "Production Status")]
        [Required(ErrorMessage = "* Required")]
        [MaxLength(Consts.MaxLength_Name)]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public string InsertBy { get; set; }

        public DateTime InsertTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
