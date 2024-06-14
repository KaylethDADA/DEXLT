using Application.Interface;
using Application.Mapping;
using Application.Sevices;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositoryes;
using Infrastructure.Jobs;
using Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Quartz;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

//получение строки подключения из конфигурационного файла
var connectionString = builder.Configuration.GetConnectionString("TelegramBotDataBase");
builder.Services.AddDbContext<TelegramBotDbContext>(options => options.UseNpgsql(connectionString));
// Чтение данных конфигурации и регистрация сервиса
builder.Services.Configure<CronExpressions>(builder.Configuration.GetSection(CronExpressions.Configuration));
// Построение поставщика служб
var serviceProvider = builder.Services.BuildServiceProvider();
// Получение сервиса CronExpressions из поставщика служб
var cronExpressions = serviceProvider.GetRequiredService<IOptions<CronExpressions>>().Value;

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Регистрация профиля AutoMapper
builder.Services.AddAutoMapper(typeof(PersonMappingProfile));
builder.Services.AddAutoMapper(typeof(CustomFieldListConverter));

// Регистрация профилей AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Quartz
builder.Services.AddQuartz(x =>
{
    x.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey("TestJob");
    x.AddJob<PersonFindBirthdaysJob>(opts => opts.WithIdentity(jobKey));

    var triggerKey = new TriggerKey("TestJobTrigger");
    x.AddTrigger(opts => opts.ForJob(jobKey)
    .WithIdentity(triggerKey)
    .WithCronSchedule(cronExpressions.StartPersonJob));
});

builder.Services.AddQuartzHostedService(x =>
{
    x.WaitForJobsToComplete = true;
});

builder.Services.AddScoped<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Этот метод определяет маршруты для контроллеров, которые вы определили в вашем приложении
});*/

app.UseHttpsRedirection();

app.Run();
