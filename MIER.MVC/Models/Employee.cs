using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class Employee : IEntity
    {

        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("EmployeePosition")]
        public int EmployeePositionId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }

        [DisplayName("Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Photo KTP")]
        public string PhotoURL { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime InsertTime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string InsertBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdateTime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UpdateBy { get; set; }

        public EmployeePosition EmployeePosition { get; set; }
        public List<Salary> Salaries { get; set; }
        public List<SalaryPayment> SalaryPayments { get; set; }
        public List<SalaryExtra> SalaryExtras { get; set; }


    }
}
