using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class PurchaseLine : IEntity
    {

        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("PurchaseCategory")]
        public int PurchaseCategoryId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "* Required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "* Required")]
        public decimal Amount { get; set; }

        public Purchase Purchase { get; set; }

    }
}
