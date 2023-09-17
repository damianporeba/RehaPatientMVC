using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.Patients;
using RehaPatientMVC.Application.ViewModels.Referral;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class ReferralService : IReferralService
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IMapper _mapper;

        public ReferralService(IReferralRepository referralRepository, IMapper mapper)
        {
            _referralRepository = referralRepository;
            _mapper = mapper;
        }

        public int AddReferral(NewReferralVm referral)
        {
            var newRef = _mapper.Map<Referral>(referral);
            var id = _referralRepository.AddReferral(newRef);
            return id;
        }
        public int GetPatientIdByPesel(string pesel)
        {
            var patientId = _referralRepository.GetPatientIdByPesel(pesel);
            return patientId;
        }
        public void DeleteReferral(int id)
        {
            _referralRepository.DeleteReferral(id);
        }

        public List<Medic> GetAllMedicsForList()
        {
            var medicList = _referralRepository.GetAllMedics();

            return medicList;
        }

        public ListReferralForListVm GetAllReferralsForList(int pageSize, int pageNo, string searchString)
        {
            var referrals = _referralRepository.GetAllReferrals().Where(p => p.Pesel.StartsWith(searchString)).ProjectTo<ReferralForListVm>(_mapper.ConfigurationProvider).ToList();
            var referralsToShow = referrals.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var referralList = new ListReferralForListVm()
            {
                PageNo = pageNo,
                PageSize = pageSize,
                SearchString = searchString,
                Referrals = referralsToShow,
            };
            return referralList;
        }
    }
}
