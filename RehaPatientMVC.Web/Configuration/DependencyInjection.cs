using AutoMapper;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Infrastructure.Repositories;
using System.Reflection;

namespace RehaPatientMVC.Web.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IMedicService, MedicService>();
            return services;
        }

        public static IServiceCollection AddInterface(this IServiceCollection services)
        {
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IContactDetailsRepository, ContactDetailsRepository>();
            services.AddTransient<IAddressRepository, AddressReporitory>();
            return services;
        }
    }
}
