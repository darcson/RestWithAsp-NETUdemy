using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAspNETUdemy.Extensions;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Model.Context;

namespace RestWithAspNETUdemy.Repository.Implementations
{
    /// <summary>
    /// services are responsable for the business Rules and call the Database
    /// </summary>
    public class PersonRepositoryImpl : IPersonRepository
    {
        private SQLContext _context;

        public PersonRepositoryImpl(SQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add<Person>(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var dbPerson = FindById(id);
            if (dbPerson.IsNull())
                return;

            try
            {
                _context.Persons.Remove(dbPerson);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            try
            {
                return _context.Persons.ToList(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Person FindById(long id)
        {
            try
            {
                return _context.Persons.SingleOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Person Update(Person person)
        {

            var dbPerson = FindById(person.Id.GetValueOrDefault());
            if (dbPerson.IsNull())
                return null;

            try
            {
                _context.Entry(dbPerson).CurrentValues.SetValues(person);
                _context.SaveChanges();
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region helpers
        
        #endregion
    }
}
