using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class SalesOrder : IEntity
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("ProductionStatus")]
        public int ProductionStatusId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Number { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Deadline { get; set; }

        public decimal Amount { get; set; }

        public string LinesName { get; set; }

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

        public List<SalesOrderLine> SalesOrderLines { get; set; }
        public Customer Customer { get; set; }
        public ProductionStatus ProductionStatus { get; set; }

    }
}
