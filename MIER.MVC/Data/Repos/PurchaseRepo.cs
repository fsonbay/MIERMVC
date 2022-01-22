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
                .Include(m => m.Vendor)
                .Include(s => s.PaymentMethod)
                .Include(m => m.SalesOrder)
                .Include(m => m.SalesOrder.Customer)
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
                .Include(s => s.PaymentMethod)
                .Include(m => m.SalesOrder)
                .Include(m => m.SalesOrder.Customer)
                .ToList();
            return result;
        }

        public Purchase GetByIdIncludes(int id)
        {
            var result = _context.Purchase
                .Include(m => m.PurchaseLines)
                .FirstOrDefault(m => m.Id == id);
            return result;
        }

        public int CountVendorOrder(int vendorId)
        {
            return _context.Purchase
                .Where(p => p.VendorId == vendorId)
                .Count();
        }
    }
}
