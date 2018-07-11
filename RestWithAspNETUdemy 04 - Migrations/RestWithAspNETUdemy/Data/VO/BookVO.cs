using RestWithAspNETUdemy.Data.VO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNETUdemy.Data.VO
{
    public class BookVO : BaseVO
    {
        public string TextKey { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
