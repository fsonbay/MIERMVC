using MIER.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.Data
{
    public interface IAppBaseRepo<TEntity>
            where TEntity : class, IEntity
    {
        List<TEntity> GetAll();

        TEntity GetById(int? id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        bool IsExist(int id);
    }
}
