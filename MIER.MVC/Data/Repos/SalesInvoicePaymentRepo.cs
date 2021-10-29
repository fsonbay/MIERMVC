using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class SalesInvoicePaymentRepo : AppBaseRepo<SalesInvoicePayment>
    {
        private readonly AppDbContext _context;

        public SalesInvoicePaymentRepo(AppDbContext context)
        : base(context)
        {
            _context = context;
        }
    }
}
