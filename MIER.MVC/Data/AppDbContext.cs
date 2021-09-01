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

        public DbSet<CustomerCategory> CustomerCategory { get; set; }

        public DbSet<Customer> Customer { get; set; }


    }
}
