using Microsoft.EntityFrameworkCore;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class EmployeeRepo : AppBaseRepo<Employee>
    {
        private readonly AppDbContext _context;

        public EmployeeRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Employee> GetAllIncludes()
        {
            var result = _context.Employee
                .Include(s => s.EmployeePosition)
                .ToList();

            return result;
        }

        public List<Employee> GetAllActive()
        {
            var result = _context.Employee
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

        public List<Employee> GetAllActiveIncludes()
        {
            var result = _context.Employee
                .Where(m => m.IsActive == true)
                .Include(s => s.EmployeePosition)
                .ToList();
            return result;
        }


    }
}
