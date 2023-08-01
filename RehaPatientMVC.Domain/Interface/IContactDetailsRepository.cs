using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Interface
{
    public interface IContactDetailsRepository
    {
        int AddContact(ContactDetails contactDetails);
        void DeleteContact(int contactId);
       
    }
}
