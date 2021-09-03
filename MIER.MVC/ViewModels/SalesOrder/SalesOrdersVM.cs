using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.SalesOrder
{
    public class SalesOrdersVM
    {
        public int? Id { get; set; }

        public string Number { get; set; }

        public DateTime Date { get; set; }

        public DateTime Deadline { get; set; }

        [Display(Name = "Delete")]
        public bool IsDelete { get; set; }

        public DateTime InsertTime { get; set; }

        public string InsertBy { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateBy { get; set; }
    }
}
