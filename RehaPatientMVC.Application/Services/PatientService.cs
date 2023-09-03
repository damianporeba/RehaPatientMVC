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
            _mapper = mapper;
        }

        public int AddPatient(NewPatientVm patient)
        {
            int i = 0;
            return  i = 0;
        }

        public ListPatientForListVm GetAllPatientsForList()  //to samo co niżej ale z wykorzystaniem mappera
        {
          
            var patients = _patientRepo.GetAllPatients().ProjectTo<PatientForListVm>(_mapper.ConfigurationProvider).ToList();

            var patientsList = new ListPatientForListVm()
            {
                Patients = patients,
                Count = patients.Count()
            };
            return patientsList;
        }

        //var patients = _patientRepo.GetAllPatients(); //odwołanie do metody z patientrepository która zwraca pacjentów z bazydanych
        //ListPatientForListVm result = new ListPatientForListVm(); //tworzenie obiektu VM który bedzie zwracany z metody na samym końcu
        //result.Patients = new List<PatientForListVM>(); //inicjalizacja listy z obiektu wyżej 
        //foreach (var patient in patients) //pętla iterująca po wynikach listy z repo
        //{
        //    var patientVm = new PatientForListVM() //tworzenie w każdej pętli z listy obiektu PatientForListVM, określamy właściwości obiektu takie jak w odpowiedzi z BD
        //    {
        //        Id = patient.Id,
        //        LastName = patient.LastName,
        //        Name = patient.Name,
        //        Pesel = patient.Pesel
        //    };
        //    result.Patients.Add(patientVm); //dodawanie obiektu do listy w tej metodzie
        //}
        //result.Count = result.Patients.Count; //przypisujemy wartość jaką jest ilość wyników na liście na właściwość count w klasie ListPatientForListVm
        //return result; //zwrot całej listy wszystkich pacjentów



        public PatientDetailsVm ViewPatientDetails(int patientId)
        {
            var patient = _patientRepo.GetPatientById(patientId);
            var patientVm = new PatientDetailsVm();

            patientVm.Pesel = patient.Pesel;
            patientVm.Name = patient.Name;
            patientVm.LastName = patient.LastName;
            patientVm.Id = patient.Id;

            patientVm.Contacts = new List<ContactDetailsListVm>();
            foreach (var contacts in patient.Contacts)
            {
                var patientContact = new ContactDetailsListVm()
                {
                    PhoneNumber = contacts.PhoneNumber,
                    Email = contacts.Email,
                };

                patientVm.Contacts.Add(patientContact);
            }
            return patientVm;
        }

       
    }
}
