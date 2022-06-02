using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class EmployeePositionRepo : AppBaseRepo<EmployeePosition>
    {

        private readonly AppDbContext _context;

        public EmployeePositionRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<EmployeePosition> GetAllActive()
        {
            var result = _context.EmployeePosition
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }
    }
}
