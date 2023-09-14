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
        public int MedicId { get; set;}
        public int PatientId { get; set;}

        public virtual Patient Patient { get; set; } //relacja z pacjentem 
        public virtual Medic Medic { get; set; }
    }
}
