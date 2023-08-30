using AutoMapper;
using RehaPatientMVC.Application.Maping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.Patients
{
    public class PatientForListVM : IMapFrom<RehaPatientMVC.Domain.Model.Patient>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<RehaPatientMVC.Domain.Model.Patient, PatientForListVM>()
                .ForMember(d=>d.Id, opt=>opt.MapFrom(s=>s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.Pesel, opt => opt.MapFrom(s => s.Pesel));
        }
    }
}
