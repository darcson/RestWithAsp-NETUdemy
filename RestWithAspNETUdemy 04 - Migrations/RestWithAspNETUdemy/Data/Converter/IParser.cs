using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNETUdemy.Data.Converter
{
    public interface IParser<Origin, Destination>
    {
        Destination Parse(Origin origin);
        IEnumerable<Destination> Parse(IEnumerable<Origin> originColl);
    }
}
