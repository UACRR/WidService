using AutoMapper;
using AutoMapper.EquivalencyExpression;
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

            CreateMap<FixFile, FixFile>()
                .ForMember(ff => ff.FileId, opt => opt.Ignore())
                .ForMember(ff => ff.Fix, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.FileId == to.FileId);

            CreateMap<FixStorageDevice, FixStorageDevice>()
                .ForMember(sd => sd.StorageId, opt => opt.Ignore())
                .ForMember(sd => sd.Fix, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.StorageId == to.StorageId);
        }
    }
}
