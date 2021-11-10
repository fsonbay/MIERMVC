using Microsoft.EntityFrameworkCore;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class PurchaseRepo : AppBaseRepo<Purchase>
    {
        private readonly AppDbContext _context;

        public PurchaseRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Purchase> GetAllIncludes()
        {
            var result = _context.Purchase
                .Include(s => s.Vendor)
                .ToList();

            return result;
        }

        public List<Purchase> GetAllActive()
        {
            var result = _context.Purchase
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

        public List<Purchase> GetAllActiveIncludes()
        {
            var result = _context.Purchase
                .Where(m => m.IsActive == true)
                .Include(s => s.Vendor)
                .ToList();
            return result;
        }

    }
}
