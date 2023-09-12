using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.Medics;
using RehaPatientMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatientMVC.Application.Services
{
    public class MedicService : IMedicService
    {
        private readonly IMapper _mapper;
        private readonly IMedicRepository _medicRepo;

        public MedicService(IMapper mapper, IMedicRepository medicRepository)
        {
            _mapper = mapper;
            _medicRepo = medicRepository;
        }
        public int AddMedic(NewMedicVm medic)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedic(int id)
        {
            throw new NotImplementedException();
        }

        public ListMedicForListVm GetAllMedicsForList(int pageSize, int pageNo, string searchString)
        {
            var medics = _medicRepo.GetAllMedics().Where(p=>p.Name.StartsWith(searchString)).ProjectTo<MedicForListVm>(_mapper.ConfigurationProvider).ToList();
            var medicToShow = medics.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var medicsList = new ListMedicForListVm()
            {
                Medics = medicToShow,
                PageNo = pageNo,
                PageSize = pageSize,
                Count = medicToShow.Count()
            };
            return medicsList;
        }

        public NewMedicVm GetMedicForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMedic(NewMedicVm model)
        {
            throw new NotImplementedException();
        }

        public MedicDetailsVm ViewMedicDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
