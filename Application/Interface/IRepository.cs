namespace Application.Interface
{
    public interface IRepository<TType>
    {
        public TType GetById(Guid id);
        public List<TType> GetAll();
        Task<TType> Create(TType person);
        public TType Update(TType person);
        public bool Delete(Guid id);
        public Task SaveChanges();
    }
}
