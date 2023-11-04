using RehaPatientMVC.Application.MappingProfile.Medic;
using RehaPatientMVC.Application.MappingProfile.Patient;
using RehaPatientMVC.Application.MappingProfile;
using RehaPatientMVC.Domain.MappingProfile;
using AutoMapper;
using RehaPatientMVC.Application.MappingProfile.Referral;
using RehaPatientMVC.Application.MappingProfile.AppUser;

namespace RehaPatientMVC.Web.Configuration
{
    public static class MappingProfile
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PatientDetailsMappingProfile));
            services.AddAutoMapper(typeof(PatientToListMappingProfile));
            services.AddAutoMapper(typeof(AddNewPatientMappingProfile));
            services.AddAutoMapper(typeof(PatientVmtoPatientsMappingProfile));

            services.AddAutoMapper(typeof(AddNewMedicMappingProfile));
            services.AddAutoMapper(typeof(MedicDetailsMappingProfile));
            services.AddAutoMapper(typeof(MedicToListMappingProfile));
            services.AddAutoMapper(typeof(MedicVmToMedicMappingProfile));

            services.AddAutoMapper(typeof(ReferralToListMappingProfile));
            services.AddAutoMapper(typeof(AddNewReferralMappingProfile));
            services.AddAutoMapper(typeof(ReferratVmToRefferalMappingProfile));

            services.AddAutoMapper(typeof(AppUserVmToAppUserMappingProfile));
            services.AddAutoMapper(typeof(NewAppUserMappingProfile));

            return services;
        }
    }
}
