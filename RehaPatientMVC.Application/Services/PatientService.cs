using RehaPatientMVC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class PatientService : IPatientService

    {
        public string Name { get ; set ; }

        public static object AddPatient( )
        {
            throw new NotImplementedException();
        }

        public static object GetAllPatientsForList()
        {
            throw new NotImplementedException();
        }

        public static object GetPatientById(int patientId)
        {
            throw new NotImplementedException();
        }

        public string Method()
        {
            Name = "dupa";
            return Name;
        }
    }
}
