namespace DexTg.Entities.ValueObjects
{
    /// <summary>
    /// Полное имя
    /// </summary>
    public class FullName : BaseValueObjects
    {
        public FullName(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = null;
    }
}