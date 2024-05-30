namespace Domain.Entities
{
    public class CustomField<TType> : BaseEntity
    {
        public CustomField()
        {
            
        }

        public string Name { get; set; }
        public TType Value { get; set; }
    }
}
