﻿using RehaPatientMVC.Application.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RehaPatientMVC.Application.Services.PatientService;

namespace RehaPatientMVC.Application.Interfaces
{
    public interface IPatientService
    {
        public ListPatientForListVm GetAllPatientsForList(int pageSize, int PageNo, string SearchString);
        public int AddPatient(NewPatientVm patient);
        public PatientDetailsVm ViewPatientDetails(int id);
        NewPatientVm GetPatientForEdit(int id);
        void UpdatePatient(NewPatientVm model);
        void DeletePatient(int id);
        int GetPatientIdByPesel(string pesel);
    }
}
