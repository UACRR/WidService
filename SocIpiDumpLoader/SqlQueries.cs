using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader
{
    public static class SqlQueries
    {
        public static readonly string AddIpiBase = $@"
            if not exists (select null from IpiBase where IpBaseNr = @IpBaseNr)
                insert IpiBase (
                      IpBaseNr
                    , IpType
                    , BirthD
                    , DeathD
                    , BirthPlace
                    , BirthState
                    , BirthTisNr
                    , TisNrFromD
                    , BirthTisan
                    , TisanFromD
                    , Sex
                    , AmdDt
                )
                select 
                      @IpBaseNr
                    , @IpType
                    , @BirthD
                    , @DeathD
                    , @BirthPlace
                    , @BirthState
                    , @BirthTisNr
                    , @TisNrFromD
                    , @BirthTisan
                    , @TisanFromD
                    , @Sex
                    , @AmdDt
        ";
        public static readonly string UpdateIpiBase = $@"
            update IpiBase
            set
                  IpBaseNr   = @IpBaseNr
                , IpType     = @IpType
                , BirthD     = @BirthD
                , DeathD     = @DeathD
                , BirthPlace = @BirthPlace
                , BirthState = @BirthState
                , BirthTisNr = @BirthTisNr
                , TisNrFromD = @TisNrFromD
                , BirthTisan = @BirthTisan
                , TisanFromD = @TisanFromD
                , Sex        = @Sex
                , AmdDt      = @AmdDt
            where IpBaseNr =  @IpBaseNr
        ";

        public static readonly string AddIpiName = $@"
            if not exists (select null from IpiName where IpBaseNr = @IpBaseNr and IpNameNr = @IpNameNr)
                insert IpiName(
                      IpNameNr
                    , IpBaseNr
                    , IpNameNrRef
                    , IpBaseNrRef
                    , Name
                    , FstName
                    , NameType
                    , CreDt
                    , AmdDt
                    , IsDeleted
                )
                select
                      @IpNameNr
                    , @IpBaseNr
                    , @IpNameNrRef
                    , @IpBaseNrRef
                    , @Name
                    , @FstName
                    , @NameType
                    , @CreDt
                    , @AmdDt
                    , 0
            ";
        public static readonly string UpdateIpiName = $@"
                update IpiName
                set
                          IpNameNr      = @IpNameNr
                        , IpBaseNr      = @IpBaseNr
                        , IpNameNrRef   = @IpNameNrRef
                        , IpBaseNrRef   = @IpBaseNrRef
                        , Name          = @Name
                        , FstName       = @FstName
                        , NameType      = @NameType
                        , CreDt         = @CreDt
                        , AmdDt         = @AmdDt
                where IpBaseNr = @IpBaseNr and IpNameNr = @IpNameNr
            ";
        public static readonly string DeleteIpiName = $@"
                delete from IpiName
                where IpBaseNr = @IpBaseNr and IpNameNr = @IpNameNr
            ";

        public static readonly string AddIpiNameUsage = $@"
            if not exists ( select null 
                            from IpiNameUsage
                            where 
                                    IpBaseNr =  @IpBaseNr 
                                and IpNameNr =  @IpNameNr
                                and CreClsCde = @CreClsCde
                                and RolCde =  @RolCde
            )
                insert IpiNameUsage(
                      IpNameNr
                    , IpBaseNr
                    , CreClsCde
                    , RolCde
                    , IsDeleted
                )
                select
                      @IpNameNr
                    , @IpBaseNr
                    , @CreClsCde
                    , @RolCde
                    , 1
            ";
        public static readonly string DeleteIpiNameUsage = $@"
            delete from IpiNameUsage 
            where 
                    IpBaseNr =  @IpBaseNr 
                and IpNameNr =  @IpNameNr
                and CreClsCde = @CreClsCde
                and RolCde    = @RolCde
            ";

        public static readonly string AddIpiStatus = $@"
                if not exists (select null 
                    from IpiStatus 
                    where IpBaseNr = @IpBaseNr
                        and FromDt = @FromDt
                        and ToDt   = @ToDt
                )
                insert IpiStatus(
                        IpBaseNr
                      , IpBaseNrRef
                      , SttCde
                      , FromDt
                      , ToDt
                      , AmdDt
                )
                select
	                    @IpBaseNr
                      , @IpBaseNrRef
                      , @SttCde
                      , @FromDt
                      , @ToDt
                      , @AmdDt
            ";
        public static readonly string DeleteIpiStatus = $@"
                delete from IpiStatus 
                where IpBaseNr = @IpBaseNr
                    and FromDt = @FromDt
                    and ToDt   = @ToDt
            ";

        public static readonly string AddIpiAgreement = $@"
                if not exists ( select null 
                                from IpiAgreement 
                                where
                                    IpBaseNr     = @IpBaseNr 
                                and SocCde       = @SocCde
                                and CreClsCde    = @CreClsCde 
                                and RolCde       = @RolCde 
                                and RgtCde       = @RgtCde 
                                and FromDt       = @FromDt
                                and ToDt         = @ToDt
                )
                insert IpiAgreement(
                        IpAgreeNr
                      , IpBaseNr 
                      , SocCde
                      , CreClsCde
                      , RolCde
                      , RgtCde
                      , FromDt
                      , ToDt
                      , SignD
                      , Shr
                      , AmdDt
                      , IsDeleted
                )
                select
                        @IpAgreeNr
                      , @IpBaseNr 
                      , @SocCde    
                      , @CreClsCde
                      , @RolCde
                      , @RgtCde
                      , @FromDt
                      , @ToDt
                      , @SignD
                      , @Shr
                      , @AmdDt
                      , 0
            ";
        public static readonly string UpdateIpiAgreement = $@"
                update IpiAgreement
                set
                        FromDt  = @FromDt
                      , ToDt    = @ToDt
                      , SignD   = @SignD
                      , Shr     = @Shr
                where 
                        IpBaseNr    = @IpBaseNr 
                    and SocCde       = @SocCde
                    and CreClsCde   = @CreClsCde 
                    and RolCde      = @RolCde 
                    and RgtCde      = @RgtCde 
            ";

        public static readonly string DeleteIpiAgreement = $@"
                delete from IpiAgreement
                where 
                        IpBaseNr    = @IpBaseNr 
                    and SocCde       = @SocCde
                    and CreClsCde   = @CreClsCde 
                    and RolCde      = @RolCde 
                    and RgtCde      = @RgtCde
                    and FromDt       = @FromDt
                    and ToDt         = @ToDt
                    and SignD        = @SignD
                    and Shr          = @Shr
            ";

        public static readonly string AddIpiTerritory = $@"
                if not exists ( select null 
                                from IpiTerritory 
                                where
                                    IpAgreeNr   = @IpAgreeNr 
                                and TisNr       = @TisNr
                                and TisNrFromD  = @TisNrFromD 
                                and Tisan       = @Tisan 
                                and TisanFromD  = @TisanFromD 
                                and IncExcInd   = @IncExcInd 
                )
                insert IpiTerritory(
                        IpAgreeNr 
                      , TisNr     
                      , TisNrFromD
                      , Tisan     
                      , TisanFromD
                      , IncExcInd 
                )
                select
                        @IpAgreeNr 
                      , @TisNr     
                      , @TisNrFromD
                      , @Tisan     
                      , @TisanFromD
                      , @IncExcInd 
            ";
        public static readonly string DeleteIpiTerritory = $@"
                delete from IpiTerritory 
                where
                    IpAgreeNr   = @IpAgreeNr 
              ";

        public static readonly string AddIpiNationality = $@"
                if not exists ( select null 
                                from IpiNationality 
                                where
                                    IpBaseNr    = @IpBaseNr 
                                and TisNr       = @TisNr
                                and TisNrFromD  = @TisNrFromD 
                                and Tisan       = @Tisan 
                                and TisanFromD  = @TisanFromD 
                )
                insert IpiNationality(
                        IpBaseNr 
                      , TisNr     
                      , TisNrFromD
                      , Tisan     
                      , TisanFromD
                )
                select
                        @IpBaseNr 
                      , @TisNr     
                      , @TisNrFromD
                      , @Tisan     
                      , @TisanFromD
            ";
        public static readonly string DeleteIpiNationality = $@"
                delete from IpiNationality 
                where
                    IpBaseNr    = @IpBaseNr 
                and TisNr       = @TisNr
                and TisNrFromD  = @TisNrFromD 
                and Tisan       = @Tisan 
                and TisanFromD  = @TisanFromD 
            ";

        public static readonly string AddIpiRemark = $@"
                if not exists ( select null 
                                from IpiRemark 
                                where
                                        IpBaseNr  = @IpBaseNr 
                                    and SocCde    = @SocCde
                                    and SeqNr     = @SeqNr 
                insert IpiRemark(
                        IpBaseNr 
                      , SocCde
                      , SeqNr 
                      , Txt 
                )
                select
                        @IpBaseNr 
                      , @SocCde
                      , @SeqNr 
                      , @Txt 
            ";
        public static readonly string DeleteIpiRemark = $@"
                delete from IpiRemark 
                where
                        IpBaseNr  = @IpBaseNr 
                    and SocCde    = @SocCde
                    and SeqNr     = @SeqNr 
            ";


    }
}
