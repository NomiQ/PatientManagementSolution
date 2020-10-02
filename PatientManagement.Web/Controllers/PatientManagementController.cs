﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using PatientManagement.Data.Domain;
using PatientManagement.Data.Services;
using PatientManagement.Web.ViewModels;

namespace PatientManagement.Web.Controllers
{
    public class PatientManagementController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientManagementController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var patients = _patientRepository.Patients.ToList();
            var model = new PatientViewModel()
            {
                AllPatients = patients
            };

            return View(model);
        }

        public ActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPatient(AddPatientViewModel patientRequest)
        {

            if (ModelState.IsValid)
            {
                var patient = _mapper.Map<AddPatientViewModel, Patient>(patientRequest);
                var created = _patientRepository.Create(patient);

                if (created)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(patientRequest);
        }

        [HttpGet]
        public ActionResult EditPatient(int id)
        { 
            // get patient details
            var patient = _patientRepository.GetPatient(id);
            
            if (patient != null)
            {
                // map to view model
                var editPatient = _mapper.Map<Patient, EditPatientViewModel>(patient);

                return View(editPatient);
            }

            return HttpNotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPatient(EditPatientViewModel editPatient)
        {
            if (ModelState.IsValid)
            {
                var patient = _mapper.Map<EditPatientViewModel, Patient>(editPatient);
                var updated = _patientRepository.Update(patient);

                if (updated)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(editPatient);
        }

        [HttpGet]
        public ActionResult DeletePatient(int id)
        {
            var patient = _patientRepository.GetPatient(id);
            if (patient != null)
            {
                var deleted = _patientRepository.Delete(patient);
                
                if (deleted)
                {
                    return RedirectToAction("Index");
                }

                return new HttpStatusCodeResult(400);
            }

            return HttpNotFound();
        }
    }
}