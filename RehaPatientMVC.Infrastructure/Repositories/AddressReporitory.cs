using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class AddressReporitory
    {
        private readonly Context _context;
        public AddressReporitory(Context context)
        {
            context = _context;
        }
    }
}
