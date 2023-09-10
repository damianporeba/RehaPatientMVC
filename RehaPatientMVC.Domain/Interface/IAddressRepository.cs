using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Domain.Interface
{
    public interface IAddressRepository
    {
        void DeleteAddress(int addressId);
        int AddAddress(Address address);
        int UpdateAddress(Address address);
    }
}
