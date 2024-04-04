using Domain.Primitives.Enums;

namespace Application.Dtos.Person
{
    /// <summary>
    /// Базовое дто для Person
    /// </summary>
    public class BasePerson
    {
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
        public int Age => DateTime.Now.Year - BirthDate.Year;

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
