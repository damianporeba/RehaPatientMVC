using AutoMapper;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.ContactDetails;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class ContactDetailsService : IContactDetailsService
    {
        private readonly IMapper _mapper;
        private readonly IContactDetailsRepository _contactDetailsRepository;

        public ContactDetailsService(IMapper mapper, IContactDetailsRepository contactDetailsRepository)
        {
            _mapper = mapper;
            _contactDetailsRepository = contactDetailsRepository;
        }
        public int AddContactDetails(NewContactDetailsVm contactDetailsVm)
        {
            var contact = _mapper.Map<ContactDetails>(contactDetailsVm);
            var contactId = _contactDetailsRepository.AddContact(contact);
            return contactId;
        }

        public void DeleteContactDetails(int id)
        {
            _contactDetailsRepository.DeleteContact(id);
        }
    }
}
