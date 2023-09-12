using RehaPatientMVC.Application.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.Medics
{
    public class ListMedicForListVm
    {
        public List<MedicForListVm> Medics { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public int CurrentPage { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
