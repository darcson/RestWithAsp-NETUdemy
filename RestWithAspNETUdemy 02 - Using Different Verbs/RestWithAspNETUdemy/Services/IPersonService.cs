using RestWithAspNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNETUdemy.Services
{
    /// <summary>
    /// Contract with the Exposed/available entryPoints
    /// </summary>
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindByAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
