using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.Material
{
    public class MaterialVM
    {
        public bool IsEditMode => Id.HasValue;

        public int? Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

    }
}
