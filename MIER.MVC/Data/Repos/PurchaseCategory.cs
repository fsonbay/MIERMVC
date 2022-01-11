using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class PurchaseCategoryRepo : AppBaseRepo<PurchaseCategory>
    {
        private readonly AppDbContext _context;

        public PurchaseCategoryRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<PurchaseCategory> GetAllActive()
        {
            var result = _context.PurchaseCategory
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

    }
}
