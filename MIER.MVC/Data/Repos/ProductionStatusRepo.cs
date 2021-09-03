using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class ProductionStatusRepo : AppBaseRepo<ProductionStatus>
    {
        private readonly AppDbContext _context;

        public ProductionStatusRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<ProductionStatus> GetAllActive()
        {
            var result = _context.ProductionStatus
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }
    }
}
