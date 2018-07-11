using System.Collections.Generic;
using System.Linq;
using RestWithAspNETUdemy.Data.Converters;
using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Extensions;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Repository.Generic;

namespace RestWithAspNETUdemy.Business.Implementations
{
    /// <summary>
    /// services are responsable for the business Rules/validations and call the Database
    /// </summary>
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IRepository<Person> _repository;
        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public PersonVO Create(PersonVO PersonVO)
        {
            return _repository.Create(PersonVO.AsEntity()).AsVO();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<PersonVO> FindAll()
        {
            return _repository.FindAll().Select(p => p.AsVO());
        }

        public PersonVO FindById(long id)
        {
            return _repository.FindById(id).AsVO();
        }

        public PersonVO Update(PersonVO PersonVO)
        {
            return _repository.Update(PersonVO.AsEntity()).AsVO();
        }

        #region helpers
        
        #endregion
    }
}
