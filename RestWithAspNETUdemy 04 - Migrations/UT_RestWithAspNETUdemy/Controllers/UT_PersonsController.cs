using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestWithAspNETUdemy.Business;
using RestWithAspNETUdemy.Business.Implementations;
using RestWithAspNETUdemy.Controllers;
using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Model.Context;
using RestWithAspNETUdemy.Repository.Generic;
using System;
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
            var person = BuildPersonVO();
            person = ((_personsController.Post(person) as ObjectResult).Value as PersonVO);
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
            var person = BuildPersonVO();
            person = ((_personsController.Post(person) as ObjectResult).Value as PersonVO);
        }

        [Fact]
        public void Post_BadRequest()
        {
            Assert.IsType<BadRequestResult>(_personsController.Post(null));
        }

        [Fact]
        public void Put_Ok()
        {
            var person = BuildPersonVO();
            person = ((_personsController.Post(person) as ObjectResult).Value as PersonVO);
            person.FirstName += " UPDATED VALUE";
            var result = _personsController.Put(person);
            Assert.True(((result as ObjectResult).Value as PersonVO).Id > 0);
        }

        [Fact]
        public void Put_BadRequest()
        {
            Assert.IsType<BadRequestResult>(_personsController.Put(null));
        }

        [Fact]
        public void Put_NotFound()
        {
            Assert.IsType<NotFoundResult>(_personsController.Put(new PersonVO { Id = long.MinValue }));
        }

        [Fact]
        public void Delete()
        {
            var person = BuildPersonVO();
            _personsController.Post(person);
            Assert.IsType<NoContentResult>(_personsController.Delete(person.Id.GetValueOrDefault()));
        }

        #region helper
        private static PersonVO BuildPersonVO()
        {
            var personNumber = new Random().Next();
            return new PersonVO
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
            IRepository<Person> repository = new GenericRepository<Person>(sqlContext);
            IPersonBusiness personBusiness = new PersonBusinessImpl(repository);
            PersonsController personsController = new PersonsController(personBusiness);
            return personsController;
        }
        #endregion
    }
}
