using System;
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
        public ActionResult CreatePatient(AddPatientViewModel patientRequest)
        {

            if (patientRequest != null)
            {
                var patient = _mapper.Map<AddPatientViewModel, Patient>(patientRequest);
                var created = _patientRepository.CreatePatient(patient);

                if (created)
                {
                    return RedirectToAction("Index");
                }
            }

            return new HttpStatusCodeResult(Response.StatusCode, "Bad Request");
        }

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


        [HttpPut]
        public ActionResult EditPatient(EditPatientViewModel editPatient)
        {
            if (editPatient != null)
            {
                // check if patient exists
                var exists = _patientRepository.Patients.Any(p => p.Id == editPatient.Id);

                if (exists)
                {
                    // update patient details

                }
            }

            return new HttpStatusCodeResult(Response.StatusCode, "400");
        }
    }
}