using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.CustomerCategory
{
    public class CustomerCategoryVM
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "* Required")]
        [MaxLength(Consts.MaxLength_Name)]
        public string Name { get; set; }

        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
