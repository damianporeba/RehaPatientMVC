using Microsoft.Extensions.DependencyInjection;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application
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
