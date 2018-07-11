using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNETUdemy.Business
{
    /// <summary>
    /// Contract with the Exposed/available entryPoints
    /// </summary>
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        IEnumerable<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
