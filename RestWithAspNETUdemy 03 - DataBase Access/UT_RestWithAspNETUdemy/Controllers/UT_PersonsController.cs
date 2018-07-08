using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestWithAspNETUdemy.Controllers;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Model.Context;
using RestWithAspNETUdemy.Services;
using RestWithAspNETUdemy.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UT_RestWithAspNETUdemy.Controllers
{
    public class UT_PersonsController
    {
        PersonsController _personsController = BuildPersonsController();

        [Fact]
        public void Get_Ok()
        {
            Assert.IsType<OkObjectResult>(_personsController.Get());
        }

        [Fact]
        public void GetById_Ok()
        {
            var person = BuildPerson();
            _personsController.Post(person);
            Assert.IsType<OkObjectResult>(_personsController.Get(person.Id.GetValueOrDefault()));
        }

        [Fact]
        public void GetById_NotFound()
        {
            Assert.IsType<NotFoundResult>(_personsController.Get(long.MinValue));
        }

        [Fact]
        public void Post_Ok()
        {
            var person = BuildPerson();
            var result = _personsController.Post(person);
            var resultStatus = (result as ObjectResult).StatusCode.GetValueOrDefault();
            Assert.True(((result as ObjectResult).Value as Person)?.Id > 0);
        }

        [Fact]
        public void Post_BadRequest()
        {
            Assert.IsType<BadRequestResult>(_personsController.Post(null));
        }

        [Fact]
        public void Put_Ok()
        {
            var person = BuildPerson();
            _personsController.Post(person);
            person.FirstName += " UPDATED VALUE";
            var result = _personsController.Put(person);
            Assert.True(((result as ObjectResult).Value as Person)?.Id > 0);
        }

        [Fact]
        public void Put_BadRequest()
        {
            Assert.IsType<BadRequestResult>(_personsController.Put(null));
        }

        [Fact]
        public void Put_NotFound()
        {
            Assert.IsType<NotFoundResult>(_personsController.Put(new Person { Id = long.MinValue }));
        }

        [Fact]
        public void Delete()
        {
            var person = BuildPerson();
            _personsController.Post(person);
            Assert.IsType<NoContentResult>(_personsController.Delete(person.Id.GetValueOrDefault()));
        }

        #region helper
        private static Person BuildPerson()
        {
            var personNumber = new Random().Next();
            return new Person
            {
                FirstName = $"First name - Person Nr. {personNumber}",
                LastName = $"Last Name - Person Nr. {personNumber}",
                Address = $"Address - Person Nr. {personNumber}",
                Gender = GenderEnum.Male
            };
        }

        private static PersonsController BuildPersonsController()
        {
            var stringConnection = @"Data Source=DESKTOP-DFVE2G8;Initial Catalog=rest_with_asp_net_udemy;Integrated Security=False;User ID=darcson;Password=admin";
            var dbContextOption = new DbContextOptionsBuilder<SQLContext>();
            dbContextOption.UseSqlServer(stringConnection);
            var sqlContext = new SQLContext(dbContextOption.Options);
            IPersonService personService = new PersonServiceImpl(sqlContext);
            PersonsController personsController = new PersonsController(personService);
            return personsController;
        }
        #endregion
    }
}
