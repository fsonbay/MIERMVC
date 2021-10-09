using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class SalesInvoice : IEntity
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("SalesOrder")]
        public int SalesOrderId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Number { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        public decimal Total { get; set; }

        public decimal Paid { get; set; }

        public decimal Outstanding { get; set; }

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

        public List<SalesInvoiceCost> SalesInvoiceCosts { get; set; }
        public List<SalesInvoicePayment> SalesInvoicePayments { get; set; }

        public SalesOrder SalesOrder { get; set; }

    }
}
