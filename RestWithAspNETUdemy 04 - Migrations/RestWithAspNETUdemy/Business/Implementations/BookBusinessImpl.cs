using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Model.Context;
using RestWithAspNETUdemy.Repository;
using RestWithAspNETUdemy.Repository.Generic;
using Utilities.Extension;

namespace RestWithAspNETUdemy.Business.Implementations
{
    /// <summary>
    /// services are responsable for the business Rules/validations and call the Database
    /// </summary>
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;
        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
