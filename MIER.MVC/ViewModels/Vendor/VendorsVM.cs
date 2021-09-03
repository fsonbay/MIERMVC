﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.Vendor
{
    public class VendorsVM
    {
        public int Id { get; set; }

        public string VendorCategory { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public DateTime InsertTime { get; set; }

        public string InsertBy { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateBy { get; set; }
    }
}