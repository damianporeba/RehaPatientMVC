using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class PatientRepository
    {
        private readonly Context _context;
        public PatientRepository(Context context)
        {
            context = _context;
        }


    }
}
