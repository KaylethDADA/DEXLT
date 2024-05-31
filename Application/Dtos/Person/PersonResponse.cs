using Domain.Primitives.Enums;

namespace Application.Dtos.Person
{
    public class PersonResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
    }
}
