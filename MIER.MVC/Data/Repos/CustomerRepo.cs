using Microsoft.EntityFrameworkCore;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class CustomerRepo : AppBaseRepo<Customer>
    {
        private readonly AppDbContext _context;

        public CustomerRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Customer> GetAllIncludes()
        {
            var result = _context.Customer
                .Include(s => s.CustomerCategory)
                .ToList();

            return result;
        }

        public List<Customer> GetAllActive()
        {
            var result = _context.Customer
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

        public List<Customer> GetAllActiveIncludes()
        {
            var result = _context.Customer
                .Where(m => m.IsActive == true)
                .Include(s => s.CustomerCategory)
                .ToList();
            return result;
        }
    }
}
