using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class SalaryPayment : IEntity
    {
        public int Id { get; set; }

        [DisplayName("Payment Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal PaymentAmount { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}
