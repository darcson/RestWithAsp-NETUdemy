using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNETUdemy.Model
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public GenderEnum Gender { get; set; }
    }

    public enum GenderEnum
    {
        Masculino,
        Feminino
    }
}
