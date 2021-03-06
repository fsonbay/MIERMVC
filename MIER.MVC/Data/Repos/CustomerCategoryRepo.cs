using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class CustomerCategoryRepo : AppBaseRepo<CustomerCategory>
    {
        private readonly AppDbContext _context;

        public CustomerCategoryRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<CustomerCategory> GetAllActive()
        {
            var result = _context.CustomerCategory
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }
    }
}
