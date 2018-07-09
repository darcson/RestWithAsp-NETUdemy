using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNETUdemy.Model.Context
{
    public class SQLContext : DbContext
    {
        #region constructors
        public SQLContext()
        {

        }

        public SQLContext(DbContextOptions<SQLContext> options)
            : base(options){}

        #endregion
        /// <summary>
        /// Give access to the Person table.
        /// </summary>
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
