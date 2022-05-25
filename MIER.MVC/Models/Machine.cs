using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Models
{
    public class Machine : IEntity
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }

    }
}
