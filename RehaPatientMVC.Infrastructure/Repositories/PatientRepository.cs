using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Context _context;
        public PatientRepository(Context context)
        {
            context = _context;
        }

        public void DeletePatient(int patientId)
        {
            var patient = _context.patients.Find(patientId);
            if (patient != null)
            {
                _context.patients.Remove(patient);
                _context.SaveChanges();
            }
        }
        public int AddPatient (Patient patient)
        {
            _context.patients.Add(patient);
            _context.SaveChanges();
            return patient.Id;
        }

        public IEnumerable<Patient> GetPatientByType(int typeId)
        {
            var patients = _context.patients.Where(i => i.Id == typeId);
            return patients;
        }

        public Patient GetPatientById(int patientId)
        {
            var patient = _context.patients.FirstOrDefault(i=>i.Id == patientId);
            return patient;
        }

        public IQueryable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }
    }

}
