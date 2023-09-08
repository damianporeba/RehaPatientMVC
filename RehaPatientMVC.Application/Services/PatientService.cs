using AutoMapper;
using AutoMapper.QueryableExtensions;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.Patients;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class PatientService : IPatientService

    {
        private readonly IPatientRepository _patientRepo;
        private readonly IMapper _mapper;
       

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepo= patientRepository;
            _mapper= mapper;
        }

        public int AddPatient(NewPatientVm patient)
        {
            var pat = _mapper.Map<Patient>(patient);
            var id = _patientRepo.AddPatient(pat);
            return id;
        }

        public ListPatientForListVm GetAllPatientsForList(int pageSize, int PageNo, string searchString)  //to samo co niżej ale z wykorzystaniem mappera
        {
          
            var patients = _patientRepo.GetAllPatients().Where(p=>p.Name.StartsWith(searchString)).ProjectTo<PatientForListVm>(_mapper.ConfigurationProvider).ToList();
            var patientsToShow = patients.Skip(pageSize * (PageNo - 1)).Take(pageSize).ToList();
            var patientsList = new ListPatientForListVm()
            {
                PageNo = PageNo,
                PageSize = pageSize,
                SearchString = searchString,
                Patients = patientsToShow,
                Count = patients.Count()
            };
            return patientsList;
        }

        public PatientDetailsVm ViewPatientDetails(int patientId)
        {
            var patient = _patientRepo.GetPatientById(patientId);
            var patientVm = _mapper.Map<PatientDetailsVm>(patient);

            return patientVm;
        }

       
    }
}
