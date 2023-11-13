using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class ContactDetailsRepository : IContactDetailsRepository
    {
        private readonly Context _context;
        public ContactDetailsRepository(Context context)
        {
            _context = context;
        }

        public int AddContact(ContactDetails contactDetails)
        {
            _context.contactDetails.Add(contactDetails);
            _context.SaveChanges();
            return contactDetails.Id;
        }

        public void DeleteContact(int contactId)
        {
            var contact = _context.contactDetails.Find(contactId);
            if (contactId != null)
            {
                _context.contactDetails.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}
