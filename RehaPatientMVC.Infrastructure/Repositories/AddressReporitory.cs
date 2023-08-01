using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Infrastructure.Repositories
{
    public class AddressReporitory : IAddressRepository
    {
        private readonly Context _context;
        public AddressReporitory(Context context)
        {
            context = _context;
        }

        public int AddAddress(Address address)
        {
            _context.addresses.Add(address);
            _context.SaveChanges();
            return address.Id;
        }

        public void DeleteAddress(int addressId)
        {
            var address = _context.addresses.Find(addressId);
            if (address != null)
            {
                _context.addresses.Remove(address);
                _context.SaveChanges();
            }

        }

        public int UpdateAddress(Address address)
        {
            var addressUpdate = _context.addresses.FirstOrDefault(i=>i.Id == address.Id);
            if (address != null)
            {
                addressUpdate = address;
            }
            return addressUpdate.Id;

            
        }
    }
}
