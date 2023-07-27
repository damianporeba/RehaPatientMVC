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
        public string Pesel { get; set; }
        public int TypeId { get; set; }
       
        public string PhoneNumber { get; set; }
        public string Email { get; set; }




        public virtual Patient patient { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
