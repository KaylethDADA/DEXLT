using Application.Interface;
using Quartz;

namespace Infrastructure.Jobs
{
    public class PersonFindBirthdaysJob : IJob
    {
        private readonly IPersonRepository _personRepository;

        public PersonFindBirthdaysJob(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var persons = _personRepository.GetBirthdaysToday();

            foreach (var person in persons)
            {
                Console.WriteLine($"У {person.FullName.LastName} {person.FullName.FirstName} сегодня др");
            }

            return Task.CompletedTask;
        }
    }
}
