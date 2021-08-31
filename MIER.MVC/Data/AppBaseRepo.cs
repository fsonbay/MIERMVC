using Microsoft.EntityFrameworkCore;
using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data
{
    public class AppBaseRepo<TEntity> : IAppBaseRepo<TEntity>
           where TEntity : class, IEntity

    {
        private readonly AppDbContext _context;

        public AppBaseRepo(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int? id)
        {
            return _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public bool IsExist(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
