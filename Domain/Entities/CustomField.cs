namespace Domain.Entities
{
    public class CustomField<TType> : BaseEntity
    {
        public string Name { get; set; }
        public TType Value { get; set; }
    }
}
