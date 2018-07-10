using RestWithAspNETUdemy.Data.Converter;
using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNETUdemy.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null)
                return null;

            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null)
                return null;

            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public IEnumerable<Person> Parse(IEnumerable<PersonVO> originColl) 
            => originColl?.Select(origin => Parse(origin));

        public IEnumerable<PersonVO> Parse(IEnumerable<Person> originColl)
            => originColl?.Select(origin => Parse(origin));
    }
}
