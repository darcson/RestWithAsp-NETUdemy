using System;
using System.Collections.Generic;
using System.Threading;
using RestWithAspNETUdemy.Model;

namespace RestWithAspNETUdemy.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindByAll()
        {
            var mock = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                mock.Add(MockPerson(i));
            }
            return mock;
        }

        public Person FindById(long id)
        {
            return MockPerson(id);
        }

        public Person Update(Person person)
        {
            return person;
        }

        #region helpers
        private Person MockPerson(long i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = $"Person Name {i}",
                LastName = $"Person Last Name {i}",
                Address = $"Address for Person  {i}",
                Gender = GenderEnum.Masculino
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
        #endregion
    }
}
