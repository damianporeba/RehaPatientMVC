using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.ViewModels.ContactDetails
{
    public class NewContactDetailsVm
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set;}
        public int PatientId { get; set; }
    }
}
