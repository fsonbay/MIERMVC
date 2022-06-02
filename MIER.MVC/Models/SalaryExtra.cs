using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class SalaryExtra
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Description { get; set; }

        public decimal Amount { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
