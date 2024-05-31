using Application.Interface;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositoryes
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TelegramBotDbContext db;

        public PersonRepository(TelegramBotDbContext _db)
        {
            db = _db;
        }

        public async Task<Person> Create(Person person)
        {
            await db.Persons.AddAsync(person);
            await db.SaveChangesAsync();
            return person;
        }

        public Person Update(Person person)
        {
            db.Persons.Update(person);
            db.SaveChanges();
            return person;
        }

        public Person GetById(Guid id)
        {
            var person = db.Persons.FirstOrDefault(x => x.Id == id);
            return person;
        }

        public List<CustomField<string>> GetCustomFields(Guid personId)
        {
            var personWithCustomFields = db.Persons
                .Include(p => p.CustomFields)
                .FirstOrDefault(p => p.Id == personId);

            return personWithCustomFields!.CustomFields.ToList() ?? new List<CustomField<string>>();
        }

        public List<Person> GetAll()
        {
            var persons = db.Persons.ToList();
            return persons;
        }

        public bool Delete(Guid id)
        {
            var person = GetById(id);
            if (person == null)
                return false;

            db.Persons.Remove(person);
            db.SaveChanges();
            return true;
        }

        public async Task SaveChanges()
        {
            await db.SaveChangesAsync();
        }
    }
}
