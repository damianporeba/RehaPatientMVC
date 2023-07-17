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
        public string ID { get ; set ; }

        public string Method()
        {
            ID = "string z implementacji IPatientService";
            return ID;
        }
    }
}
