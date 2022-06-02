using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.Machine
{
    public class MachineVM
    {
        public bool IsEditMode => Id.HasValue;

        public int? Id { get; set; }

        public string Name { get; set; }


        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
