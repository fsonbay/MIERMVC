using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class PaymentMethodRepo : AppBaseRepo<PaymentMethod>
    {
        private readonly AppDbContext _context;

        public PaymentMethodRepo(AppDbContext context)
    : base(context)
        {
            _context = context;
        }

        public List<PaymentMethod> GetAllActive()
        {
            var result = _context.PaymentMethod
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }
    }
}
