namespace Application.Dtos.Person
{
    public class PersonItemList
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; init; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; init; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? MiddleName { get; init; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; init; }
    }
}
