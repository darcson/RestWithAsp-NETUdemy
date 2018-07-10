using RestWithAspNETUdemy.Data.Converter;
using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNETUdemy.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
    {
        if (origin == null)
            return null;

        return new Book
        {
            Id = origin.Id,
            Author = origin.Author,
            LaunchDate = origin.LaunchDate,
            Price = origin.Price,
            TextKey = origin.TextKey
        };
    }

    public BookVO Parse(Book origin)
    {
        if (origin == null)
            return null;

        return new BookVO
        {
            Id = origin.Id,
            Author = origin.Author,
            LaunchDate = origin.LaunchDate,
            Price = origin.Price,
            TextKey = origin.TextKey
        };
    }

    public IEnumerable<Book> Parse(IEnumerable<BookVO> originColl)
        => originColl?.Select(origin => Parse(origin));

    public IEnumerable<BookVO> Parse(IEnumerable<Book> originColl)
        => originColl?.Select(origin => Parse(origin));
}
}
