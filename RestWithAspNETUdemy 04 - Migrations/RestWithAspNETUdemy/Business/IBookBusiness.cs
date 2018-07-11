using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNETUdemy.Business
{
    /// <summary>
    /// Contract with the Exposed/available entryPoints
    /// </summary>
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        IEnumerable<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
