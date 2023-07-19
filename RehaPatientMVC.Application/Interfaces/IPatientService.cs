using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RehaPatientMVC.Application.Services.PatientService;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IPatientService
    {
        public string Name { get; set; }
        public string Method();
    }
}
