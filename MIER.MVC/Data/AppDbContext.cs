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
        public DbSet<PurchaseCategory> PurchaseCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLine { get; set; }
        public DbSet<SalesInvoice> SalesInvoice { get; set; }
        public DbSet<SalesInvoiceCost> SalesInvoiceCost { get; set; }
        public DbSet<SalesInvoicePayment> SalesInvoicePayment { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseLine> PurchaseLine { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<EmployeePosition> EmployeePosition { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<SalaryExtra> SalaryExtra { get; set; }
        public DbSet<SalaryPayment> SalaryPayment { get; set; }

    }
}
