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

        public void DeletePatient(int id)
        {
            _patientRepo.DeletePatient(id);
        }

        public ListPatientForListVm GetAllPatientsForList(int pageSize, int PageNo, string searchString)
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

        public NewPatientVm GetPatientForEdit(int id)
        {
            var patient = _patientRepo.GetPatientById(id);
            var patientVm = _mapper.Map<NewPatientVm>(patient);
            return patientVm;
        }

        public void UpdatePatient(NewPatientVm model)
        {
            var patient = _mapper.Map<Patient>(model);
            _patientRepo.UpdatePatient(patient);
        }

        public PatientDetailsVm ViewPatientDetails(int id)
        {
            var patient = _patientRepo.GetPatientById(id);
            var patientVm = _mapper.Map<PatientDetailsVm>(patient);
            return patientVm;
        }
        public int GetPatientIdByPesel(string pesel)
        {
            var patientId = _patientRepo.GetPatientIdByPesel(pesel);
            return patientId;
        }
    }
}
