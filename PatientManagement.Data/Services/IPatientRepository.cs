using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientManagement.Data.Domain;

namespace PatientManagement.Data.Services
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> Patients { get; }
        Patient GetPatient(int id);
        bool Create(Patient patient);
        bool Update(Patient patient);
        bool Delete(Patient patient);
    }
}