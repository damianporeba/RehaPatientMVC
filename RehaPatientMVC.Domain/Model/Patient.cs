using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }       

        public virtual ICollection<Address> Addresses { get; set; } //dostęp do adresów pacjenta
        public virtual ICollection<ContactDetails> Contacts { get; set; } //dostep do sposobów kontaktów pacjenta
        public virtual ICollection<Referral> Referrals { get; set; } //dostęp do skierowania danego pacjenta ??? sprawdzić
    }
}
