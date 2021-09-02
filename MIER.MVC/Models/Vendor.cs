using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class Vendor : IEntity
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [ForeignKey("VendorCategory")]
        public int VendorCategoryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

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

        public VendorCategory VendorCategory { get; set; }
    }
}
