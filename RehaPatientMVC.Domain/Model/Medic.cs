﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Model
{
    public class Medic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string Degree { get; set; }

        public virtual ICollection<Referral> Referrals { get; set; }
    }
}
