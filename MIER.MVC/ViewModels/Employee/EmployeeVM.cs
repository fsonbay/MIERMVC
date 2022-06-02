using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.Employee
{
    public class EmployeeVM
    {
        public bool IsEditMode => Id.HasValue;

        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "* Required")]
        public string FullName { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Contact Person")]
        [DataType(DataType.MultilineText)]
        public string ContactPerson { get; set; }

        [Display(Name = "Position")]
        public int EmployeePositionId { get; set; }

        [Display(Name = "Basic Salary")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public string BasicSalary { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "* Required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "KTP Photo")]
        public string PhotoURL { get; set; }

        public bool IsActive { get; set; }

        //public int SelectedYear { get; set; }
        //public int SelectedMonth { get; set; }

        ////Nested
        //public List<SalaryDetail> SalaryDetail { get; set; }
        //public List<SalaryPaymentList> SalaryPaymentList { get; set; }
        //public List<SalaryExtraList> SalaryExtraList { get; set; }

        public string InsertBy { get; set; }

        public DateTime? InsertTime { get; set; }

    }
}
