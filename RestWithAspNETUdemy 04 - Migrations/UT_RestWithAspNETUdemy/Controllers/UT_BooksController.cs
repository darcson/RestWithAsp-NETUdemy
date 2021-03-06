﻿using Microsoft.AspNetCore.Mvc;
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
    public class UT_BoksController
    {
        BooksController _booksController = BuildControllerController();

        [Fact]
        public void Get_Ok()
        {
            Assert.IsType<OkObjectResult>(_booksController.Get());
        }

        [Fact]
        public void GetById_Ok()
        {
            var book = BuildBookVO();
            book = ((_booksController.Post(book) as ObjectResult).Value as BookVO);
            Assert.IsType<OkObjectResult>(_booksController.Get(book.Id.GetValueOrDefault()));
        }

        [Fact]
        public void GetById_NotFound()
        {
            Assert.IsType<NotFoundResult>(_booksController.Get(long.MinValue));
        }

        [Fact]
        public void Post_Ok()
        {
            var book = BuildBookVO();
            book = ((_booksController.Post(book) as ObjectResult).Value as BookVO);
            Assert.True(book?.Id > 0);
        }

        [Fact]
        public void Post_BadRequest()
        {
            Assert.IsType<BadRequestResult>(_booksController.Post(null));
        }

        [Fact]
        public void Put_Ok()
        {
            var book = BuildBookVO();
            book = ((_booksController.Post(book) as ObjectResult).Value as BookVO);
            book.Author += " UPDATED VALUE";
            var result = _booksController.Put(book);
            Assert.True(((result as ObjectResult).Value as BookVO).Id > 0);
        }

        [Fact]
        public void Put_BadRequest()
        {
            Assert.IsType<BadRequestResult>(_booksController.Put(null));
        }

        [Fact]
        public void Put_NotFound()
        {
            Assert.IsType<NotFoundResult>(_booksController.Put(new BookVO { Id = long.MinValue }));
        }

        [Fact]
        public void Delete()
        {
            var person = BuildBookVO();
            _booksController.Post(person);
            Assert.IsType<NoContentResult>(_booksController.Delete(person.Id.GetValueOrDefault()));
        }

        #region helper
        private static BookVO BuildBookVO()
        {
            var bookNumber = new Random().Next();
            return new BookVO
            {
                Author = $"Author number {bookNumber}",
                LaunchDate = DateTime.Now,
                Price = Convert.ToDecimal(new Random().NextDouble() * 100),
                TextKey = $"this was supose to be a hash numver {bookNumber}"
            };
        }

        private static BooksController BuildControllerController()
        {
            var stringConnection = @"Data Source=DESKTOP-DFVE2G8;Initial Catalog=rest_with_asp_net_udemy;Integrated Security=False;User ID=darcson;Password=admin";
            var dbContextOption = new DbContextOptionsBuilder<SQLContext>();
            dbContextOption.UseSqlServer(stringConnection);
            var sqlContext = new SQLContext(dbContextOption.Options);
            IRepository<Book> repository = new GenericRepository<Book>(sqlContext);
            IBookBusiness bookBusiness = new BookBusinessImpl(repository);
            BooksController booksController = new BooksController(bookBusiness);
            return booksController;
        }
        #endregion
    }
}
