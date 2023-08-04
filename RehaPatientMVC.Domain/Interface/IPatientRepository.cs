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
        void DeletePatient(int patientId);

        int AddPatient(Patient patient);

        //IEnumerable<Patient> GetPatientByType(int typeId); narazie usunięta 04/08/23r.

        Patient GetPatientById(int patientId);
        
    }
}
