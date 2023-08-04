using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Model
{
    public class Referral
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Pesel { get; set; }
        public string ICD10 { get; set; }
        public string TypeRefferal { get; set; }
        public int RefferalId { get; set;}
        public int PatientId { get; set;}

            //public virtual Type Type { get; set; } //relacja z typem skierowania (domowe czy stacjonarne)
        public virtual Patient Patient { get; set; } //relacja z pacjentem 
        //public Type Type { get; set; }
    }
}
