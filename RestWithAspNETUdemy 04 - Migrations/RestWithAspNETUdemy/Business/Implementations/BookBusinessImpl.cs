using System.Collections.Generic;
using System.Linq;
using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Extensions;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Repository.Generic;

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

        public BookVO Create(BookVO book)
        {
            return _repository.Create(book.AsEntity()).AsVO();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<BookVO> FindAll()
        {
            return _repository.FindAll().Select(b => b.AsVO());
        }

        public BookVO FindById(long id)
        {
            return _repository.FindById(id).AsVO();
        }

        public BookVO Update(BookVO book)
        {
            return _repository.Update(book.AsEntity()).AsVO();
        }
    }
}
