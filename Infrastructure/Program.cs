using Application.Interface;
using Application.Mapping;
using Application.Mappings;
using Application.Sevices;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();

            //��������� ������ ����������� �� ����������������� �����
            var connectionString = builder.Configuration.GetConnectionString("TelegramBotDataBase");
            builder.Services.AddDbContext<TelegramBotDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IPersonRepository, IPersonRepository>();

            // ����������� ������� AutoMapper
            builder.Services.AddAutoMapper(typeof(PersonMappingProfile));
            builder.Services.AddAutoMapper(typeof(CustomFieldListConverter));

            //builder.Services.AddAutoMapper(typeof(Program));
            // ����������� �������� AutoMapper
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            ///todo ����������� � �������, ���������� ���, ����������� � ����������. � �� �������������� ��������� � ���������� ������ ������ � ��������������.
            /// ����� ������� ���������� �������
            ///  !!!! ���
            /// ����������� �������� ���� �������� ������� ����� ��������� ����� ������, ����� �� � ������ �����-�� �������� ���� �����
            /// �� ���� ������� ��� ����� ��������
            /// �� ����� ���� *

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
        }
    }
}
