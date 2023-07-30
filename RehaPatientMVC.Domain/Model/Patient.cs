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
       
        




        public virtual Patient patient { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Medic> Medics { get; set; }
        
    }
}
