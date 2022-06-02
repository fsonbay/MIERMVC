using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class MachineRepo : AppBaseRepo<Machine>
    {
        private readonly AppDbContext _context;

        public MachineRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<Machine> GetAllActive()
        {
            var result = _context.Machine
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }


    }
}
