using System;
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
        public string Proffession { get; set; }

        public Patient Patient { get; set; }

    }
}
