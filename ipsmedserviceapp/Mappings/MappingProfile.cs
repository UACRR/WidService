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
                .AfterMap((source, dest) =>
                {
                    if (source.StageStatus >= 8)
                    {
                        dest.Lic.CustId = dest.ClientCustId.Value;
                        var paidPeriod = dest.Lic.PaidPeriod.First();
                        paidPeriod.CustId = dest.ClientCustId.Value;
                        var registerRatedList = paidPeriod.RegisterRatedList.First();
                        var register = registerRatedList.Register.First();
                        register.CustId = dest.ClientCustId.Value;
                    }
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
                .ForMember(la => la.LicId, opt => opt.Ignore())
                .ForMember(la => la.Agr, opt => opt.Ignore())
                .ForMember(la => la.Fixation, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.LicId == to.LicId);

            CreateMap<AgreementMaster, AgreementMaster>()
                .ForMember(c => c.AgrId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.AgrId == to.AgrId);

            CreateMap<PaidPeriod, PaidPeriod>()
                .ForMember(pp => pp.PeriodId, opt => opt.Ignore())
                .ForMember(pp => pp.Lic, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.PeriodId == to.PeriodId);

            CreateMap<RegisterRatedList, RegisterRatedList>()
                .ForMember(rr => rr.RmId, opt => opt.Ignore())
                .ForMember(rr => rr.Period, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.RmId == to.RmId);

            CreateMap<Register, Register>()
                .ForMember(r => r.RegId, opt => opt.Ignore())
                .ForMember(r => r.Rm, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.RegId == to.RegId);

            CreateMap<RegisterItem, RegisterItem>()
                .ForMember(ri => ri.RegId, opt => opt.Ignore())
                .ForMember(ri => ri.Obj, opt => opt.Ignore())
                //.ForMember(ri => ri.RegIitemId, opt => opt.Ignore()) // becouse RegIitemId in not an autoincrement field, and it value sets on the client side
                .ForMember(ri => ri.Reg, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.RegId == to.RegId && from.RegIitemId == to.RegIitemId);

            CreateMap<RegisterItemFix, RegisterItemFix>()
                .ForMember(rf => rf.RegId, opt => opt.Ignore())
                .ForMember(rf => rf.RegItemId, opt => opt.Ignore())
                .ForMember(rf => rf.RegI, opt => opt.Ignore())
                .ForMember(rf => rf.TimeStart, opt => opt.MapFrom((source) => source.TimeStart == TimeSpan.Zero ? null : source.TimeStart ))
                .ForMember(rf => rf.TimeEnd, opt => opt.MapFrom((source) => source.TimeEnd == TimeSpan.Zero ? null : source.TimeEnd ))
                .EqualityComparison((from, to) => from.RegId == to.RegId && from.RegItemId == to.RegItemId)
                .AfterMap((source, dest) =>
                {
                    if (dest.TimeStart == null && dest.TimeEnd == null)
                    {
                        // remove this record from db
                        dest.RegI = null;
                    }
                });

            CreateMap<RegisterCount, RegisterCount>()
                .ForMember(rc => rc.RegCntId, opt => opt.Ignore())
                .ForMember(rc => rc.RegI, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.RegCntId == to.RegCntId);

            CreateMap<ObjectRight, ObjectRight>()
                .ForMember(o => o.ObjId, opt => opt.Ignore())
                .EqualityComparison((from, to) => from.ObjId == to.ObjId);
        }
    }
}
