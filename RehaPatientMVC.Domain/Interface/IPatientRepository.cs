using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Interface
{
    public interface IPatientRepository
    {
        void DeletePatient(int id);
        int AddPatient(Patient patient);
        IQueryable<Patient> GetAllPatients();
        Patient GetPatientById(int patientId);
        void UpdatePatient(Patient patient);
        int GetPatientIdByPesel(string pesel);
    }
}
