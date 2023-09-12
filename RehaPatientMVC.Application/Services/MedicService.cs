using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.Medics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class MedicService : IMedicService
    {
        public int AddMedic(NewMedicVm medic)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedic(int id)
        {
            throw new NotImplementedException();
        }

        public ListMedicForListVm GetAllMedicsForList(int pageSize, int PageNo, string SearchString)
        {
            throw new NotImplementedException();
        }

        public NewMedicVm GetMedicForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMedic(NewMedicVm model)
        {
            throw new NotImplementedException();
        }

        public MedicDetailsVm ViewMedicDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
