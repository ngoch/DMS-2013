using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain.Services
{
    public interface IDomainService<T> where T : class
    {
        IEnumerable<T> GetAll(params string[] includes);
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
    }
}
