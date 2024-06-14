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

//��������� ������ ����������� �� ����������������� �����
var connectionString = builder.Configuration.GetConnectionString("TelegramBotDataBase");
builder.Services.AddDbContext<TelegramBotDbContext>(options => options.UseNpgsql(connectionString));
// ������ ������ ������������ � ����������� �������
builder.Services.Configure<CronExpressions>(builder.Configuration.GetSection(CronExpressions.Configuration));
// ���������� ���������� �����
var serviceProvider = builder.Services.BuildServiceProvider();
// ��������� ������� CronExpressions �� ���������� �����
var cronExpressions = serviceProvider.GetRequiredService<IOptions<CronExpressions>>().Value;

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// ����������� ������� AutoMapper
builder.Services.AddAutoMapper(typeof(PersonMappingProfile));
builder.Services.AddAutoMapper(typeof(CustomFieldListConverter));

// ����������� �������� AutoMapper
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
    endpoints.MapControllers(); // ���� ����� ���������� �������� ��� ������������, ������� �� ���������� � ����� ����������
});*/

app.UseHttpsRedirection();

app.Run();
