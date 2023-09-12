using RehaPatientMVC.Application.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IMedicService
    {
        public ListMedicForList GetAllMedicsForList(int pageSize, int PageNo, string SearchString);
        public int AddMedic(NewMedicVm medic);
        public MedicDetailsVm ViewMedicDetails(int id);
        NewMedicVm GetMedicForEdit(int id);
        void UpdateMedic(NewMedicVm model);
        void DeleteMedic(int id);
    }
}
