using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class SalesInvoicePayment : IEntity
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("SalesInvoice")]
        public int SalesInvoiceId { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public SalesInvoice SalesInvoice { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

    }
}
