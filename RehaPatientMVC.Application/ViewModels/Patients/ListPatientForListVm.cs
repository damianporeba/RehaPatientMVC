using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.Patients
{
    public class ListPatientForListVm //robimy to zeby mieć dobry schemat paginacji pacjentów na strony
    {
        public List<PatientForListVm> Patients { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public int CurrentPage { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
