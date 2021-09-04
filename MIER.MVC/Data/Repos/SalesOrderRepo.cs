﻿using Microsoft.EntityFrameworkCore;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data.Repos
{
    public class SalesOrderRepo : AppBaseRepo<SalesOrder>
    {
        private readonly AppDbContext _context;
        public SalesOrderRepo(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<SalesOrder> GetAllIncludes()
        {
            var result = _context.SalesOrder
                .Include(s => s.Customer)
                .Include(s => s.ProductionStatus)
                .ToList();

            return result;
        }

        public List<SalesOrder> GetAllActive()
        {
            var result = _context.SalesOrder
                .Where(m => m.IsActive == true)
                .ToList();
            return result;
        }

        public List<SalesOrder> GetAllActiveIncludes()
        {
            var result = _context.SalesOrder
                .Where(m => m.IsActive == true)
                .Include(s => s.Customer)
                .Include(s => s.ProductionStatus)
                .ToList();
            return result;
        }
    }
}
