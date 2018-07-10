using RestWithAspNETUdemy.Model;
/// <summary>
/// Data model representation
/// </summary>
namespace RestWithAspNETUdemy.Data.VO
{
    public class PersonVO
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
