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
        public int AddMedic(Medic medic);
        public void RemoveMedic(int medicId);
        public int UpdateMedic (Medic medic);
        public IEnumerable<Medic> GetMedicsByDegree(string medicDegree);
        public IQueryable<Medic> GetAllMedics();
    }
}
