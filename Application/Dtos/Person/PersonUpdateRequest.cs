namespace Application.xs.Person
{
    /// <summary>
    /// Дто для обновления Person
    /// </summary>
    public abstract class PersonUpdateRequest : BasePerson
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; init; }
    }
}
