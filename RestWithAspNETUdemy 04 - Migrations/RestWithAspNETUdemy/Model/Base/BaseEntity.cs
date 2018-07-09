using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestWithAspNETUdemy.Model.Base
{
    //Contrato entre os atributos da entidade e a estrutura da tabela
    //[DataContract]
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public long? Id { get; set; }
    }
}
