using RestWithAspNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNETUdemy.Repository
{
    /// <summary>
    /// Contract with the Exposed/available entryPoints
    /// </summary>
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
