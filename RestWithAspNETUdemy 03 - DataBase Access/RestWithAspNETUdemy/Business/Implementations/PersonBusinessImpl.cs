using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Model.Context;
using RestWithAspNETUdemy.Repository;
using Utilities.Extension;

namespace RestWithAspNETUdemy.Business.Implementations
{
    /// <summary>
    /// services are responsable for the business Rules/validations and call the Database
    /// </summary>
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _personRepository;
        public PersonBusinessImpl(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindById(long id)
        {
            return _personRepository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }

        #region helpers
        
        #endregion
    }
}
