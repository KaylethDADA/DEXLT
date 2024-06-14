using Application;
using Application.Interface;
using Application.Mapping;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositoryes;
using Infrastructure.Jobs;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Регистрация сервисов
builder.Services.AddServiceApplication();

builder.Services.AddControllers();

// Получение строки подключения из конфигурационного файла
var connectionString = builder.Configuration.GetConnectionString("TelegramBotDataBase");
builder.Services.AddDbContext<TelegramBotDbContext>(options => options.UseNpgsql(connectionString));

// Регистрации настроек
builder.Services.Configure<CronExpressionsSettings>(builder.Configuration.GetSection(nameof(CronExpressionsSettings)));
builder.Services.Configure<TelegramSettings>(builder.Configuration.GetSection(nameof(TelegramSettings)));

// Получение CronExpressions из поставщика служб
var cronExpressions = builder.Configuration.GetSection(nameof(CronExpressionsSettings)).Get<CronExpressionsSettings>();

// Регистрация repositoryes
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Регистрация профиля AutoMapper
builder.Services.AddAutoMapper(typeof(PersonMappingProfile));
builder.Services.AddAutoMapper(typeof(CustomFieldListConverter));
// Регистрация профилей AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Quartz
builder.Services.AddQuartz(x =>
{
    x.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey("PersonFindBirthdaysJob");
    x.AddJob<PersonFindBirthdaysJob>(opts => opts.WithIdentity(jobKey));

    var triggerKey = new TriggerKey("PersonFindBirthdaysJob");
    x.AddTrigger(opts => opts.ForJob(jobKey)
    .WithIdentity(triggerKey)
    .WithCronSchedule(cronExpressions.StartPersonJob));
});

builder.Services.AddQuartzHostedService(x =>
{
    x.WaitForJobsToComplete = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
