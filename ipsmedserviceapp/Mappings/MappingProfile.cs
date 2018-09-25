using AutoMapper;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fixation, Fixation>()
                .ForMember(f => f.FixId, opt => opt.Ignore());
        }
    }
}
