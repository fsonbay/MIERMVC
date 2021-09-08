using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class ProductRepo : AppBaseRepo<Product>
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Product> GetAllActive()
        {
            var result = _context.Product
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }
    }
}
