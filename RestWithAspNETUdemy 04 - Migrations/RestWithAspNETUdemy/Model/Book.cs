using RestWithAspNETUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNETUdemy.Model
{
    public class Book : BaseEntity
    {
        public string TextKey { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }

    }
}
