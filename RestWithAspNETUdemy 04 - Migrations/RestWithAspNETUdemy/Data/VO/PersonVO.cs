using RestWithAspNETUdemy.Data.VO.Base;
using RestWithAspNETUdemy.Model;
/// <summary>
/// Data model representation
/// </summary>
namespace RestWithAspNETUdemy.Data.VO
{
    public class PersonVO : BaseVO
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
