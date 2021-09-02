using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class VendorCategoryRepo : AppBaseRepo<VendorCategory>
    {
        private readonly AppDbContext _context;

        public VendorCategoryRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<VendorCategory> GetAllActive()
        {
            var result = _context.VendorCategory
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }
    }
}
