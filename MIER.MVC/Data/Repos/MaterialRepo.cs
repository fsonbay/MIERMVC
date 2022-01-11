using Microsoft.EntityFrameworkCore;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class MaterialRepo : AppBaseRepo<Material>
    {
        private readonly AppDbContext _context;

        public MaterialRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Material> GetAllIncludes()
        {
            var result = _context.Material
                .ToList();

            return result;
        }

        public List<Material> GetAllActive()
        {
            var result = _context.Material
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

        public List<Material> GetAllActiveIncludes()
        {
            var result = _context.Material
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

        public Material GetByIdIncludes(int id)
        {
            var result = _context.Material
                .Include(m => m.MaterialTypes)
                .FirstOrDefault(m => m.Id == id);
            return result;
        }
    }
}
