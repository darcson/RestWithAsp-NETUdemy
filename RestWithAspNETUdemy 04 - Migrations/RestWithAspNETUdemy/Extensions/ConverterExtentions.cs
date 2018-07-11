using RestWithAspNETUdemy.Data.Converter;
using RestWithAspNETUdemy.Data.Converters;
using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Data.VO.Base;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestWithAspNETUdemy.Extensions
{
    public static class ConverterExtentions
    {
        private static readonly PersonConverter _personConverter = new PersonConverter();
        private static readonly BookConverter _bookConverter = new BookConverter();

        public static Person AsEntity (this PersonVO origin)
         => _personConverter.Parse(origin);

        public static PersonVO AsVO(this Person origin)
            => _personConverter.Parse(origin);

        public static Book AsEntity(this BookVO origin)
         => _bookConverter.Parse(origin);

        public static BookVO AsVO(this Book origin)
            => _bookConverter.Parse(origin);
    }
}
