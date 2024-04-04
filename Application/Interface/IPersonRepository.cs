using DexTg.Entities.Entities;

namespace Application.Interface
{
    public interface IPersonRepository : IRepository<Person>
    {
        public List<CustomField<string>> GetCustomFields();
    }
}
