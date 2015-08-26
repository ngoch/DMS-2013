using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(params string[] includes);
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void SaveChanges();
    }
}
