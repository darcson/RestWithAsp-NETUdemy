using RestWithAspNETUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
    }
}
