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

        public string Method()
        {
            Name = "Implementacja stringu imię z interfejsu IPatientService";
            return Name;
        }
    }
}
