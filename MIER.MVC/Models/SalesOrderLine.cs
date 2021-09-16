using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class SalesOrderLine : IEntity
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("SalesOrder")]
        public int SalesOrderId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public bool IsActive { get; set; }

        public SalesOrder SalesOrder { get; set; }
    }
}
