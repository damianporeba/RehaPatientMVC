using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class ContactDetailsRepository
    {
        private readonly Context _context;
        public ContactDetailsRepository(Context context)
        {
            context = _context;
        }
    }
}
