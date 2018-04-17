using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ipsFormsDesign.Dictionary
{
    public class DictBaseTypeI
    {
        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<DictTrI> DictTrI { get; set; }
        #region convert to dictionary objects and 
        // ActivityType
        public static implicit operator ActivityType(DictBaseTypeI test)
        {
            return new ActivityType { CodeI = test.CodeI, Name = test.Name, ActivityTypeTr = test.DictTrI.Select(rec => new ActivityTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(ActivityType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ActivityTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator AnketaStatus(DictBaseTypeI test)
        {
            return new AnketaStatus { CodeI = test.CodeI, Name = test.Name, AnketaStatusTr = test.DictTrI.Select(rec => new AnketaStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(AnketaStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.AnketaStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CategoryStatusType(DictBaseTypeI test)
        {
            return new CategoryStatusType { CodeI = test.CodeI, Name = test.Name, CategoryStatusTypeTr = test.DictTrI.Select(rec => new CategoryStatusTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CategoryStatusType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CategoryStatusTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CopyrightType(DictBaseTypeI test)
        {
            return new CopyrightType { CodeI = test.CodeI, Name = test.Name, CopyrightTypeTr = test.DictTrI.Select(rec => new CopyrightTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CopyrightType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CopyrightTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CustomerStatus(DictBaseTypeI test)
        {
            return new CustomerStatus { CodeI = test.CodeI, Name = test.Name, CustomerStatusTr = test.DictTrI.Select(rec => new CustomerStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CustomerStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CustomerStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CustomerType(DictBaseTypeI test)
        {
            return new CustomerType { CodeI = test.CodeI, Name = test.Name, CustomerTypeTr = test.DictTrI.Select(rec => new CustomerTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CustomerType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CustomerTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DocumentKind(DictBaseTypeI test)
        {
            return new DocumentKind { CodeI = test.CodeI, Name = test.Name, DocumentKindTr = test.DictTrI.Select(rec => new DocumentKindTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(DocumentKind test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.DocumentKindTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator LegalBasis(DictBaseTypeI test)
        {
            return new LegalBasis { CodeI = test.CodeI, Name = test.Name, LegalBasisTr = test.DictTrI.Select(rec => new LegalBasisTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(LegalBasis test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.LegalBasisTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator LicenseType(DictBaseTypeI test)
        {
            return new LicenseType { CodeI = test.CodeI, Name = test.Name, LicenseTypeTr = test.DictTrI.Select(rec => new LicenseTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(LicenseType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.LicenseTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator ObjectStatus(DictBaseTypeI test)
        {
            return new ObjectStatus { CodeI = test.CodeI, Name = test.Name, ObjectStatusTr = test.DictTrI.Select(rec => new ObjectStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(ObjectStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ObjectStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PaymentKind(DictBaseTypeI test)
        {
            return new PaymentKind { CodeI = test.CodeI, Name = test.Name, PaymentKindTr = test.DictTrI.Select(rec => new PaymentKindTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PaymentKind test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PaymentKindTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PaymentStatus(DictBaseTypeI test)
        {
            return new PaymentStatus { CodeI = test.CodeI, Name = test.Name, PaymentStatusTr = test.DictTrI.Select(rec => new PaymentStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PaymentStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PaymentStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PayMethodType(DictBaseTypeI test)
        {
            return new PayMethodType { CodeI = test.CodeI, Name = test.Name, PayMethodTypeTr = test.DictTrI.Select(rec => new PayMethodTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PayMethodType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PayMethodTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator Period(DictBaseTypeI test)
        {
            return new Period { CodeI = test.CodeI, Name = test.Name, PeriodTr = test.DictTrI.Select(rec => new PeriodTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(Period test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PeriodTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PositionType(DictBaseTypeI test)
        {
            return new PositionType { CodeI = test.CodeI, Name = test.Name, PositionTypeTr = test.DictTrI.Select(rec => new PositionTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PositionType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PositionTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator Region(DictBaseTypeI test)
        {
            return new Region { CodeI = test.CodeI, Name = test.Name, RegionTr = test.DictTrI.Select(rec => new RegionTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(Region test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.RegionTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator RegisterStatus(DictBaseTypeI test)
        {
            return new RegisterStatus { CodeI = test.CodeI, Name = test.Name, RegisterStatusTr = test.DictTrI.Select(rec => new RegisterStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(RegisterStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.RegisterStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator ResidentType(DictBaseTypeI test)
        {
            return new ResidentType { CodeI = test.CodeI, Name = test.Name, ResidentTypeTr = test.DictTrI.Select(rec => new ResidentTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(ResidentType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ResidentTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator SexType(DictBaseTypeI test)
        {
            return new SexType { CodeI = test.CodeI, Name = test.Name, SexTypeTr = test.DictTrI.Select(rec => new SexTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(SexType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.SexTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator TypePlace(DictBaseTypeI test)
        {
            return new TypePlace { CodeI = test.CodeI, Name = test.Name, TypePlaceTr = test.DictTrI.Select(rec => new TypePlaceTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(TypePlace test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.TypePlaceTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator TypeVat(DictBaseTypeI test)
        {
            return new TypeVat { CodeI = test.CodeI, Name = test.Name, TypeVattr = test.DictTrI.Select(rec => new TypeVattr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(TypeVat test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.TypeVattr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }



        #endregion 

    }


    public class DictBaseTypeS
    {
        public string CodeS { get; set; }
        public string Name { get; set; }

        public ICollection<DictTrS> RegionTr { get; set; }

        // Lang
        #region 
        //public static implicit operator Lang(DictBaseTypeI test)
        //{
        //    return new Lang { CodeS = test.CodeS, Name = test.Name, Langtr = test.DictTrI.Select(rec => new Langtr { CodeS = rec.CodeS, Name = rec.Name, Lang = rec.Lang }).ToList() };
        //}
        //public static implicit operator DictBaseTypeI(Lang test)
        //{
        //    return new DictBaseTypeI { CodeS = test.CodeS, Name = test.Name, DictTrI = test.Langtr.Select(rec => new DictTrI { CodeI = rec.CodeS, Name = rec.Name, Lang = rec.Lang }).ToList() };
        //}
#endregion
    }

}
