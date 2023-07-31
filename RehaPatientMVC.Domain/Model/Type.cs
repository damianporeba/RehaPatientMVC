using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Model
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; } //typ skierowanie - ambulatorium czy domowe

        public virtual ICollection<Patient> Patients { get; set;} //do tego moze mieć dostep wielu pacjenów 
        public virtual ICollection<Referral> Referrals { get; set; } //do tego moze miec dostep wiele skierowań
    }
}
