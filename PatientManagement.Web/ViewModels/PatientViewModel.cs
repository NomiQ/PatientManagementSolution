using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagement.Data.Domain;

namespace PatientManagement.Web.ViewModels
{
    public class PatientViewModel
    {
        public IEnumerable<Patient> AllPatients { get; set; }
    }
}