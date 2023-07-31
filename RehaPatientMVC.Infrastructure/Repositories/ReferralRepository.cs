using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class ReferralRepository
    {
        private readonly Context _context;
        public ReferralRepository(Context context)
        {
            context = _context;
        }
    }
}
