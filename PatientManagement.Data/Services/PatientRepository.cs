using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Data.Domain;

namespace PatientManagement.Data.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _appDbContext;

        public PatientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Patient> Patients
        {
            get
            {
                return _appDbContext.Patients;
            }
        }

        public Patient GetPatient(int id)
        {
            var patient = _appDbContext.Patients
                                .FirstOrDefault(s => s.Id == id);
            return patient;
        }

        public bool CreatePatient(Patient patient)
        {
            _appDbContext.Patients.Add(patient);
            var created = _appDbContext.SaveChanges();

            return created > 0;
        }

        public bool UpdatePatient(Patient patient)
        {
            // set state to modify
            _appDbContext.Entry(patient).State = EntityState.Modified;
            

            var updated = _appDbContext.SaveChanges();
            return updated > 0;
        }
    }
}
