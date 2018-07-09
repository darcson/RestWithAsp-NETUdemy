using RestWithAspNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNETUdemy.Repository
{
    /// <summary>
    /// Contract with the Exposed/available entryPoints
    /// </summary>
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
