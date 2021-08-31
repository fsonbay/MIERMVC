using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Areas.Identity.Data
{
    public class AppRole : IdentityRole
    {
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public string InsertBy { get; set; }

        public DateTime? InsertTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

    }
}
