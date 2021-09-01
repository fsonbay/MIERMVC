using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.Customer
{
    public class CustomersVM
    {
        public int Id { get; set; }

        public string CustomerCategory { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime InsertTime { get; set; }

        public string InsertBy { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateBy { get; set; }

    }
}
