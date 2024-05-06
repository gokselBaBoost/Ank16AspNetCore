using HMS.DAL.Context;
using HMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repositories.Abstract
{
    public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : BaseEntity
    {
        protected HmsDbContext _dbContext;
        protected Repo(HmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(TEntity entity)
        {
            entity.Created = DateTime.Now;

            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public virtual TEntity? Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public int Update(TEntity entity)
        {
            entity.Updated = DateTime.Now;

            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
