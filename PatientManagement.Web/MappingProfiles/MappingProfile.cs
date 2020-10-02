using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PatientManagement.Data.Domain;
using PatientManagement.Web.ViewModels;

namespace PatientManagement.Web.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddPatientViewModel, Patient>();
            CreateMap<EditPatientViewModel, Patient>();
        }
    }
}