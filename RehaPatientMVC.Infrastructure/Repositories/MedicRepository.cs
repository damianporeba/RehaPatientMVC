using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class MedicRepository
    {
        private readonly Context _context;
        public MedicRepository(Context context)
        {
            context = _context;
        }
    }
}
