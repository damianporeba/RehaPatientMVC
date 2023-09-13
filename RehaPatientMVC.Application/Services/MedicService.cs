using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehaPatientMVC.Application.Interfaces;
using RehaPatientMVC.Application.ViewModels.Medics;
using RehaPatientMVC.Domain.Interface;
using RehaPatientMVC.Domain.Model;
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
            var med = _mapper.Map<Medic>(medic);
            var id = _medicRepo.AddMedic(med);
            return id;
        }

        public void DeleteMedic(int id)
        {
            _medicRepo.RemoveMedic(id);
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
            var medic = _medicRepo.GetMedicById(id);
            var medicVm = _mapper.Map<NewMedicVm>(medic);
            return medicVm;
        }

        public void UpdateMedic(NewMedicVm model)
        {
            var medic = _mapper.Map<Medic>(model);
            _medicRepo.UpdateMedic(medic);
        }

        public MedicDetailsVm ViewMedicDetails(int id)
        {
            var medic = _medicRepo.GetMedicById(id);
            var medicVm = _mapper.Map<MedicDetailsVm>(medic);
            return medicVm;
        }
    }
}
