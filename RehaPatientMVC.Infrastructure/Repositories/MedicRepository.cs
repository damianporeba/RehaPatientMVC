using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class MedicRepository : IMedicRepository
    {
        private readonly Context _context;
        public MedicRepository(Context context)
        {
            _context = context;
        }

        public int AddMedic(Medic medic)
        {
            _context.medics.Add(medic);
            _context.SaveChanges();
            return medic.Id;
        }

        public IQueryable<Medic> GetAllMedics()
        {
            var medics = _context.medics;
            return medics;
        }

        public IEnumerable<Medic> GetMedicsByDegree(string medicDegree)
        {
            var medics = _context.medics.Where(i => i.Degree == medicDegree);
            return medics;
        }

        public Medic GetMedicById(int id)
        {
            var medic = _context.medics.FirstOrDefault(i => i.Id == id);
            return medic;
        }

        public void RemoveMedic(int id)
        {
            var medicToRemove = _context.medics.FirstOrDefault(i => i.Id == id); 
            if (medicToRemove != null)
            {
                _context.medics.Remove(medicToRemove);
                _context.SaveChanges();
            }
        }

        public void UpdateMedic(Medic medic)
        {
            _context.Attach(medic);
            _context.Entry(medic).Property("Name").IsModified = true;
            _context.Entry(medic).Property("LastName").IsModified = true;
            _context.Entry(medic).Property("Degree").IsModified = true;
            _context.Entry(medic).Property("Profession").IsModified = true;
            _context.SaveChanges();
        }
        public List<Medic> GetAllMedicsForDropDownList()
        {
            var medicToList = _context.medics.ToList();
            foreach (var medic in medicToList)
            {
                medic.Name = medic.Name + " " + medic.LastName + " " + medic.Profession;
            }
            return medicToList;
        }
    }
}
