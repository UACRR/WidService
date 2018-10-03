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
                .ForMember(f => f.FixId, opt => opt.Ignore())
                .ForPath(f => f.Lic.Agr.LicenseAgreement, opt => opt.Ignore())
                .AfterMap((source, dest, context) => {

                    if (source.FixId == 0)
                    {
                        dest.Lic = context.Mapper.Map<LicenseAgreement>(source.Lic);
                    }

                    dest.Lic.CustId = dest.ClientCustId.Value;
                    dest.Lic.Agr.CustId = dest.ClientCustId.Value;
                    var paidPeriod = dest.Lic.PaidPeriod.First();
                    paidPeriod.CustId = dest.ClientCustId.Value;
                    var registerRatedList = paidPeriod.RegisterRatedList.First();
                    var register = registerRatedList.Register.First();
                    register.CustId = dest.ClientCustId.Value;
                });

            CreateMap<FixFile, FixFile>()
                .ForMember(ff => ff.FileId, opt => opt.Ignore())
                .ForMember(ff => ff.Fix, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.FileId == to.FileId);

            CreateMap<FixStorageDevice, FixStorageDevice>()
                .ForMember(sd => sd.StorageId, opt => opt.Ignore())
                .ForMember(sd => sd.Fix, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.StorageId == to.StorageId);

            CreateMap<Customer, Customer>()
                .ForMember(c => c.CustId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.CustId == to.CustId);

            CreateMap<LicenseAgreement, LicenseAgreement>()
                .ForMember(c => c.LicId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.LicId == to.LicId);

            CreateMap<AgreementMaster, AgreementMaster>()
                .ForMember(c => c.AgrId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.AgrId == to.AgrId);

            CreateMap<PaidPeriod, PaidPeriod>()
                .ForMember(c => c.PeriodId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.PeriodId == to.PeriodId);

            CreateMap<RegisterRatedList, RegisterRatedList>()
                .ForMember(c => c.RmId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.RmId == to.RmId);

            CreateMap<Register, Register>()
                .ForMember(c => c.RegId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.RegId == to.RegId);

            CreateMap<RegisterItem, RegisterItem>()
                .ForMember(c => c.RegId, opt => opt.Ignore())
                .ForMember(c => c.RegIitemId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.RegId == to.RegId && from.RegIitemId == to.RegIitemId);

            CreateMap<RegisterCount, RegisterCount>()
                .ForMember(c => c.RegCntId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.RegCntId == to.RegCntId);
        }
    }
}
