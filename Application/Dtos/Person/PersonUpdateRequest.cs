using Domain.Primitives.Enums;

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
        /// Гендер
        /// </summary>
        public Gender Gender { get; init; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; init; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; init; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; init; }
        /// <summary>
        /// Никнейм в телеграм
        /// </summary>
        public string Telegram { get; init; }
    }
}
