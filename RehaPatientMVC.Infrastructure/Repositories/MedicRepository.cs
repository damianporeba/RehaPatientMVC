﻿using RehaPatientMVC.Domain.Interface;
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
            context = _context;
        }

        public int AddMedic(Medic medic)
        {
            _context.medics.Add(medic);
            _context.SaveChanges();
            return medic.Id;
        }

        public IEnumerable<Medic> GetMedicsByDegree(string medicDegree)
        {
            var medics = _context.medics.Where(i => i.Degree == medicDegree);
            return medics;
        }

        public void RemoveMedic(int medicId)
        {
            var medicToRemove = _context.medics.FirstOrDefault(i => i.Id == medicId); 
            if (medicToRemove != null)
            {
                _context.medics.Remove(medicToRemove);
                _context.SaveChanges();
            }
        }

        public int UpdateMedic(Medic medic)
        {
            var medicUpdate = _context.medics.FirstOrDefault(i=>i.Id== medic.Id);
            if (medicUpdate != null)
            {
                medicUpdate = medic;
            }
            return medicUpdate.Id;
        }
    }
}