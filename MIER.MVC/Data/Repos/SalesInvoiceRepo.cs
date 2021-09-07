using Microsoft.EntityFrameworkCore;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class SalesInvoiceRepo : AppBaseRepo<SalesInvoice>
    {
        private readonly AppDbContext _context;
        public SalesInvoiceRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<SalesInvoice> GetAllIncludes()
        {
            var result = _context.SalesInvoice
                .Include(s => s.SalesOrder)
                .ToList();

            return result;
        }

        public List<SalesInvoice> GetAllActive()
        {
            var result = _context.SalesInvoice
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

        public List<SalesInvoice> GetAllActiveIncludes()
        {
            var result = _context.SalesInvoice
                .Where(m => m.IsActive == true)
                .Include(s => s.SalesOrder)
                .ToList();
            return result;
        }

    }
}
