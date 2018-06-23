using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            return new ActivityType { CodeI = test.CodeI, Name = test.Name,
                ActivityTypeTr = new ObservableListSource<ActivityTypeTr>( test.DictTrI.Select(rec => new ActivityTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList()) };
        }
        public static implicit operator DictBaseTypeI(ActivityType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI =  new ObservableListSource<DictTrI>( test.ActivityTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList()) };
        }

        // CustomerStatus
        public static implicit operator CustomerStatus(DictBaseTypeI test)
        {
            return new CustomerStatus { CodeI = test.CodeI, Name = test.Name, CustomerStatusTr = new ObservableListSource<CustomerStatusTr>( test.DictTrI.Select(rec => new CustomerStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList()) };
        }
        public static implicit operator DictBaseTypeI(CustomerStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CustomerStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }

        // CustomerType
        public static implicit operator CustomerType(DictBaseTypeI test)
        {
            return new CustomerType { CodeI = test.CodeI, Name = test.Name, CustomerTypeTr = new ObservableListSource<CustomerTypeTr>( test.DictTrI.Select(rec => new CustomerTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList()) };
        }
        public static implicit operator DictBaseTypeI(CustomerType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CustomerTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // Region
        public static implicit operator Region(DictBaseTypeI test)
        {
            return new Region { CodeI = test.CodeI, Name = test.Name, RegionTr = new ObservableListSource<RegionTr> (test.DictTrI.Select(rec => new RegionTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList()) };
        }
        public static implicit operator DictBaseTypeI(Region test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.RegionTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // ResidentType
        public static implicit operator ResidentType(DictBaseTypeI test)
        {
            return new ResidentType { CodeI = test.CodeI, Name = test.Name, ResidentTypeTr = new ObservableListSource<ResidentTypeTr>( test.DictTrI.Select(rec => new ResidentTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() ) };
        }
        public static implicit operator DictBaseTypeI(ResidentType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ResidentTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // SexType
        public static implicit operator SexType(DictBaseTypeI test)
        {
            return new SexType { CodeI = test.CodeI, Name = test.Name, SexTypeTr = new ObservableListSource<SexTypeTr>( test.DictTrI.Select(rec => new SexTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList()) };
        }
        public static implicit operator DictBaseTypeI(SexType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.SexTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // TypePlace
        public static implicit operator TypePlace(DictBaseTypeI test)
        {
            return new TypePlace { CodeI = test.CodeI, Name = test.Name, TypePlaceTr = new ObservableListSource<TypePlaceTr>( test.DictTrI.Select(rec => new TypePlaceTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList()) };
        }
        public static implicit operator DictBaseTypeI(TypePlace test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.TypePlaceTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // TypeVAT
        public static implicit operator TypeVat(DictBaseTypeI test)
        {
            return new TypeVat { CodeI = test.CodeI, Name = test.Name, TypeVattr = new ObservableListSource<TypeVattr>( test.DictTrI.Select(rec => new TypeVattr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList()) };
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
