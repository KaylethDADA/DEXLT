namespace Application.Dtos.Person
{
    /// <summary>
    /// Запрос для обновления Person
    /// </summary>
    public class PersonUpdateRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Имя
        /// </summary>
        public string? FirstName { get; init; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string? LastName { get; init; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? MiddleName { get; init; }
    }
}
