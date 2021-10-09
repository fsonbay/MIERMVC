using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class SalesInvoiceCost : IEntity
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("SalesInvoice")]
        public int SalesInvoiceId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime InsertTime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string InsertBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdateTime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UpdateBy { get; set; }

        public SalesInvoice SalesInvoice { get; set; }
    }
}
