using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.Patients
{
    public class ListPatientForListVm //robimy to zeby mieć dobry schemat paginacji pacjentów na strony
    {
        public List<PatientForListVM> Patients { get; set; }
        public int Count { get; set; }
    }
}
