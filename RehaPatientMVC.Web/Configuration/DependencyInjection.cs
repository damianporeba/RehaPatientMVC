using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;

namespace RehaPatientMVC.Web.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPatientService, PatientService>();
            return services;
        }
    }
}
