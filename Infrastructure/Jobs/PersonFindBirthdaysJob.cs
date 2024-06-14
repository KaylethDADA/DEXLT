using Application.Interface;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Quartz;
using Telegram.Bot;

namespace Infrastructure.Jobs
{
    public class PersonFindBirthdaysJob : IJob
    {
        private readonly IPersonRepository _personRepository;
        private readonly TelegramSettings _telegramSettings;
        private readonly TelegramBotClient _telegramBotClient;

        public PersonFindBirthdaysJob(IPersonRepository personRepository, IOptions<TelegramSettings> telegramSettings)
        {
            _personRepository = personRepository;
            _telegramSettings = telegramSettings.Value;
            _telegramBotClient = new TelegramBotClient(_telegramSettings.BotToken);
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await SendMesssageAsync(DateTime.Now.ToString());
        }

        public async Task SendMesssageAsync(string message)
        {
            try
            {
                var persons = _personRepository.GetBirthdaysToday();
                foreach (var person in persons)
                {
                    await _telegramBotClient.SendTextMessageAsync(_telegramSettings.ChatId, $"У {person.Telegram} сегодня др");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
