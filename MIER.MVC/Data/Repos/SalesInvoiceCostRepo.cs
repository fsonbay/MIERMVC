using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class SalesInvoiceCostRepo : AppBaseRepo<SalesInvoiceCost>
    {
        private readonly AppDbContext _context;

        public SalesInvoiceCostRepo(AppDbContext context)
        : base(context)
        {
            _context = context;
        }
    }
}
