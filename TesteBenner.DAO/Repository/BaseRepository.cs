using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TesteBenner.DAO.Context;
using TesteBenner.DAO.Entities;

namespace TesteBenner.Business.Repository
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly EstacionamentoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(EstacionamentoContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void Insert(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual IList<TEntity> Get()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Merge(TEntity obj)
        {
            var current = GetById(obj.ID);
            if (current != null)
                Db.Entry(current).CurrentValues.SetValues(obj);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }
    }
}
