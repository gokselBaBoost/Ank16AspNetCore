using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repositories.Abstract
{
    public interface IRepo<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        //List<TEntity> GetAll();
        TEntity? Get(int id);
    }
}
