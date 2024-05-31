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


            return Task.CompletedTask;
        }
    }
}
