using Microsoft.EntityFrameworkCore;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class VendorRepo : AppBaseRepo<Vendor>
    {
        private readonly AppDbContext _context;

        public VendorRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Vendor> GetAllIncludes()
        {
            var result = _context.Vendor
                .Include(s => s.VendorCategory)
                .ToList();

            return result;
        }

        public List<Vendor> GetAllActive()
        {
            var result = _context.Vendor
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

        public List<Vendor> GetAllActiveIncludes()
        {
            var result = _context.Vendor
                .Where(m => m.IsActive == true)
                .Include(s => s.VendorCategory)
                .ToList();
            return result;
        }

    }
}
