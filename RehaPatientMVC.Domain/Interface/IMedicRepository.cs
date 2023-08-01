using Microsoft.VisualBasic.FileIO;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Interface
{
    public interface IMedicRepository
    {
        int AddMedic(Medic medic);
        void RemoveMedic(int medicId);
        int UpdateMedic (Medic medic);
        IEnumerable<Medic> GetMedicsByDegree(string medicDegree);
    }
}
