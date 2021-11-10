using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class Purchase : IEntity
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "* Required")]
        public string Number { get; set; }

        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "* Required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "* Required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "* Required")]
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

        public List<PurchaseLine> PurchaseLines { get; set; }

        public Vendor Vendor { get; set; }

    }
}
