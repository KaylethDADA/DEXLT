using Application.Sevices;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Регистрация сервисов
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<PersonService>();

            return services;
        }
    }
}
