using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidViewer
{
    static class SqlQueries
    {
        public const string ShareHolders = @"
            ; with per as (
            select t2.IpNameNr ipId, t1.WrkTtl, t2.IpRole, t4.FstName, t4.Name, t4.NameType, t3.RightType, t3.Shares
            from widTitle t1
                join widIntrPty t2 on t1.wic = t2.wic
                join widShares t3 on t2.wic = t3.wic and t2.RolId = t3.IntrPtyRolid
                left join SocIpi..IpiName t4 on t2.IpNameNr = t4.IpNameNr
            where t1.wic = @wic and  t3.RightType = 'PER'
            ),
            mec as (
            select t2.IpNameNr ipId, t1.WrkTtl, t2.IpRole, t4.FstName, t4.Name, t4.NameType, t3.RightType, t3.Shares
            from widTitle t1
                join widIntrPty t2 on t1.wic = t2.wic
                join widShares t3 on t2.wic = t3.wic and t2.RolId = t3.IntrPtyRolid
                left join SocIpi..IpiName t4 on t2.IpNameNr = t4.IpNameNr
            where t1.wic = @wic and  t3.RightType = 'MEC'
            )
            select 
                  isnull(t1.ipId, t2.ipId) ipId
                , isnull(t1.WrkTtl, t2.WrkTtl) WrkTtl
                , isnull(t1.IpRole, t2.IpRole) IpRole
                , isnull(t1.FstName, t2.FstName) FstName
                , isnull(t1.Name, t2.Name) Name
                , isnull(t1.NameType, t2.NameType) NameType
                , isnull(t1.Shares, 0) PerShare
                , isnull(t2.Shares, 0) MecShare
            from per t1
                full join mec t2 on t1.ipId = t2.ipId
        ";

        public const string ShareHolderSocieties = @"
            select t2.SocCde, cast(t2.Shr as varchar(10)) Shr, t2.CreClsCde, t2.RolCde, t2.RgtCde, t3.TisNr, t3.Tisan
            from SocIpi..IpiName t1
                join SocIpi..IpiAgreement t2 on t1.IpBaseNr = t2.IpBaseNr
                join SocIpi..IpiTerritory t3 on t2.IpAgreeNr = t3.IpAgreeNr
            where t1.IpNameNr = @ipNameNr
            order by t2.SocCde
        ";
    }
}
