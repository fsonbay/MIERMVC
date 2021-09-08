using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MIER.MVC.Areas.Identity.Data;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIER.MVC.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<ProductionStatus> ProductionStatus { get; set; }
        public DbSet<CustomerCategory> CustomerCategory { get; set; }
        public DbSet<VendorCategory> VendorCategory { get; set; }

        public DbSet<Product> Product { get; set; }


        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLine { get; set; }
        public DbSet<SalesInvoice> SalesInvoice { get; set; }

    }
}
