using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Ipa : TransBase
    {
        // IpiBase
        protected RecBdn RecBdn { get; set; }
        // IpiState
        protected RecStn RecStn { get; set; }
        // IpiName
        protected List<RecNcn> RecNcnList { get; set; }
        // IpiRemarks
        protected List<RecRen> RecRenList { get; set; }
        // IpiNameUsage
        protected List<RecNun> RecNunList { get; set; }
        // IpiMbrAgree with Terr nested
        protected List<MaNew> ManList { get; set; }
        // IpiName related to other IP
        protected List<RecMcn> RecMcnList { get; set; }
        // IpiNameUsage related to other IP
        protected List<RecMun> RecMunList { get; set; }
        // IpiName related to other name
        protected List<RecOnn> RecOnnList { get; set; }
        // IpiNameUsage related to other name
        protected List<RecInn> RecInnList { get; set; }
        // IpiNationality
        protected List<RecNtn> RecNtnList { get; set; }

        protected override void ApplyToIpiBase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiBase;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
            cmd.Parameters.AddWithValue("@IpType", RecBdn.IpType);
            cmd.Parameters.AddWithValue("@BirthD", ParseFromDate(RecBdn.BirthYy, RecBdn.BirthMm, RecBdn.BirthDd));
            cmd.Parameters.AddWithValue("@DeathD", ParseFromDate(RecBdn.DeathYy, RecBdn.DeathMm, RecBdn.DeathDd));
            cmd.Parameters.AddWithValue("@BirthPlace", RecBdn.BirthPlace);
            cmd.Parameters.AddWithValue("@BirthState", RecBdn.BirthState);
            cmd.Parameters.AddWithValue("@BirthTisNr", RecBdn.BirthTisNr);
            cmd.Parameters.AddWithValue("@TisNrFromD", ParseFromDate(RecBdn.TisNrValidFrom));
            cmd.Parameters.AddWithValue("@BirthTisan", RecBdn.BirthTisan);
            cmd.Parameters.AddWithValue("@TisanFromD", ParseFromDate(RecBdn.TisanValidFrom));
            cmd.Parameters.AddWithValue("@Sex", RecBdn.Sex);
            cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(RecBdn.AmdD, RecBdn.AmdT));
            cmd.ExecuteNonQuery();
        }

        protected override void ApplyToIpiName(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiName;

            if (RecNcnList != null)
            {
                RecNcnList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@IpBaseNrRef", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IpNameNrRef", DBNull.Value);
                    cmd.Parameters.AddWithValue("@FstName", x.FstName);
                    cmd.Parameters.AddWithValue("@Name", x.Name);
                    cmd.Parameters.AddWithValue("@NameType", x.NameType);
                    cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                    cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.ExecuteNonQuery();
                });
            }


            if (RecMcnList != null)
            {
                RecMcnList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@IpBaseNrRef", x.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNrRef", DBNull.Value);
                    cmd.Parameters.AddWithValue("@FstName", "");
                    cmd.Parameters.AddWithValue("@Name", x.Name);
                    cmd.Parameters.AddWithValue("@NameType", x.NameType);
                    cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                    cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                    cmd.ExecuteNonQuery();
                });
            }

            if (RecOnnList != null)
            {
                RecOnnList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@IpBaseNrRef", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IpNameNrRef", int.Parse(x.IpNameNrRef));
                    cmd.Parameters.AddWithValue("@FstName", x.FstName);
                    cmd.Parameters.AddWithValue("@Name", x.Name);
                    cmd.Parameters.AddWithValue("@NameType", x.NameType);
                    cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                    cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                    cmd.ExecuteNonQuery();
                });
            }
        }

        protected override void ApplyToIpiNameUsage(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiNameUsage;

            if (RecNunList != null)
            {
                RecNunList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.ExecuteNonQuery();
                });
            }
            if (RecMunList != null)
            {
                RecMunList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.ExecuteNonQuery();
                });
            }
        }

        protected override void ApplyToIpiAgreement(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiAgreement;

            if (ManList != null)
            {
                ManList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpAgreeNr", x.GetIpAgreeNr(UpdTrans.IpBaseNr));
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@SocCde", x.RecMan.SocCde);
                    cmd.Parameters.AddWithValue("@CreClsCde", x.RecMan.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RecMan.RolCde);
                    cmd.Parameters.AddWithValue("@RgtCde", x.RecMan.RgtCde);
                    cmd.Parameters.AddWithValue("@FromDt", ParseFromTs(x.RecMan.ValidFromD, x.RecMan.ValidFromT));
                    cmd.Parameters.AddWithValue("@ToDt", ParseToTs(x.RecMan.ValidToD, x.RecMan.ValidToT));
                    cmd.Parameters.AddWithValue("@SignD", ParseFromDate(x.RecMan.SignD));
                    cmd.Parameters.AddWithValue("@Shr", ParseShare(x.RecMan.Shr));
                    cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.RecMan.AmdD, x.RecMan.AmdT));
                    cmd.ExecuteNonQuery();
                });
            }
        }

        protected override void ApplyToIpiStatus(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiStatus;

            if (RecStn != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpBaseNrRef", RecStn.IpBaseNrRef);
                cmd.Parameters.AddWithValue("@SttCde", RecStn.SttCde);
                cmd.Parameters.AddWithValue("@FromDt", ParseFromTs(RecStn.ValidFromD, RecStn.ValidFromT));
                cmd.Parameters.AddWithValue("@ToDt", ParseToTs(RecStn.ValidToD, RecStn.ValidToT));
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(RecStn.AmdD, RecStn.AmdT));
                cmd.ExecuteNonQuery();
            }
        }

        protected override void ApplyToIpiTerritory(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiTerritory;

            if (ManList != null)
            {
                ManList.ForEach(x =>
                {
                    x.RecTmaList.ForEach(y =>
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IpAgreeNr", x.GetIpAgreeNr(UpdTrans.IpBaseNr));
                        cmd.Parameters.AddWithValue("@TisNr", y.TisNr);
                        cmd.Parameters.AddWithValue("@TisNrFromD", ParseFromDate(y.TisNrValidFrom));
                        cmd.Parameters.AddWithValue("@Tisan", y.Tisan);
                        cmd.Parameters.AddWithValue("@TisanFromD", ParseFromDate(y.TisanValidFrom));
                        cmd.Parameters.AddWithValue("@IncExcInd", y.IncExcInd);
                        cmd.ExecuteNonQuery();
                    });
                });
            }

        }

        protected override void ApplyToIpiRemark(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiRemark;

            if (RecRenList != null)
            {
                RecRenList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@SocCde", x.SocCde);
                    cmd.Parameters.AddWithValue("@SeqNr", int.Parse(x.SeqNr));
                    cmd.Parameters.AddWithValue("@Txt", x.Txt);
                    cmd.ExecuteNonQuery();
                });
            }
        }
        protected override void ApplyToIpiNationality(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiNationality;

            if (RecNtnList != null)
            {
                RecNtnList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@TisNr", x.TisNr);
                    cmd.Parameters.AddWithValue("@TisNrFromD", ParseFromDate(x.TisNrValidFrom));
                    cmd.Parameters.AddWithValue("@Tisan", x.Tisan);
                    cmd.Parameters.AddWithValue("@TisanFromD", ParseFromDate(x.TisanValidFrom));
                    cmd.ExecuteNonQuery();
                });
            }
        }

        public override void AddBulkLoadData(List<string> transLines, Dictionary<string, BulkUploadToSql> bulkLoaders)
        {
            Init(transLines);
            var data = new List<object>();

            // ================= RecBdn
            data = new List<object>();
            data.Add(DBNull.Value);
            data.Add(UpdTrans.IpBaseNr);
            data.Add(RecBdn.IpType);
            data.Add(ParseFromDate(RecBdn.BirthYy, RecBdn.BirthMm, RecBdn.BirthDd));
            data.Add(ParseFromDate(RecBdn.DeathYy, RecBdn.DeathMm, RecBdn.DeathDd));
            data.Add(RecBdn.BirthPlace.Trim());
            data.Add(RecBdn.BirthState.Trim());
            data.Add(RecBdn.BirthTisNr.Trim());
            data.Add(ParseFromDate(RecBdn.TisNrValidFrom));
            data.Add(RecBdn.BirthTisan.Trim());
            data.Add(ParseFromDate(RecBdn.TisanValidFrom));
            data.Add(RecBdn.Sex.Trim());
            data.Add(ParseFromTs(RecBdn.AmdD, RecBdn.AmdT));
            bulkLoaders["IpiBase"].AddData(data);

            // ================= RecStn
            data = new List<object>();
            data.Add(DBNull.Value);
            data.Add(UpdTrans.IpBaseNr);
            data.Add(RecStn.IpBaseNrRef);
            data.Add(RecStn.SttCde);
            data.Add(ParseFromTs(RecStn.ValidFromD, RecStn.ValidFromT));
            data.Add(ParseToTs(RecStn.ValidToD, RecStn.ValidToT));
            data.Add(ParseFromTs(RecStn.AmdD, RecBdn.AmdT));
            bulkLoaders["IpiStatus"].AddData(data);

            // ================= RecNcnList
            if (RecNcnList != null)
            {
                RecNcnList.ForEach(x =>
                {
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(int.Parse(x.IpNameNr));
                    data.Add(UpdTrans.IpBaseNr);
                    data.Add(DBNull.Value); // IpNameNrRef
                    data.Add(DBNull.Value); // IpBaseNrRef
                    data.Add(x.Name);
                    data.Add(x.FstName);
                    data.Add(x.NameType);
                    data.Add(ParseFromTs(x.CreD, x.CreT));
                    data.Add(ParseFromTs(x.AmdD, x.AmdT));
                    data.Add(0);
                    bulkLoaders["IpiName"].AddData(data);
                });
            }

            // ================= RecRenList
            if(RecRenList != null)
            {
                RecRenList.ForEach(x =>
                {
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(UpdTrans.IpBaseNr);
                    data.Add(x.SocCde);
                    data.Add(int.Parse(x.SeqNr));
                    data.Add(x.Txt);
                    bulkLoaders["IpiRemark"].AddData(data);
                });
            }

            // ================= RecNunList
            if(RecNunList != null)
            {
                RecNunList.ForEach(x =>
                {
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(int.Parse(x.IpNameNr));
                    data.Add(DBNull.Value); // IpBaseNr
                    data.Add(x.CreClsCde);
                    data.Add(x.RolCde);
                    data.Add(0);
                    bulkLoaders["IpiNameUsage"].AddData(data);
                });
            }

            // ================= ManList
            if(ManList != null)
            {
                ManList.ForEach(x =>
                {
                    var ipAgreeNr = x.GetIpAgreeNr(UpdTrans.IpBaseNr);
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(ipAgreeNr);
                    data.Add(UpdTrans.IpBaseNr);
                    data.Add(x.RecMan.SocCde);
                    data.Add(x.RecMan.CreClsCde);
                    data.Add(x.RecMan.RolCde);
                    data.Add(x.RecMan.RgtCde);
                    data.Add(ParseFromTs(x.RecMan.ValidFromD, x.RecMan.ValidFromT));
                    data.Add(ParseToTs(x.RecMan.ValidToD, x.RecMan.ValidToT));
                    data.Add(ParseFromDate(x.RecMan.SignD));
                    data.Add(ParseShare(x.RecMan.Shr));
                    data.Add(ParseFromTs(x.RecMan.AmdD, x.RecMan.AmdT));
                    data.Add(0);
                    bulkLoaders["IpiAgreement"].AddData(data);

                    x.RecTmaList.ForEach(y =>
                    {
                        data = new List<object>();
                        data.Add(DBNull.Value);
                        data.Add(ipAgreeNr);
                        data.Add(y.TisNr);
                        data.Add(ParseFromDate(y.TisNrValidFrom));
                        data.Add(y.Tisan);
                        data.Add(ParseFromDate(y.TisanValidFrom));
                        data.Add(y.IncExcInd);
                        bulkLoaders["IpiTerritory"].AddData(data);
                    });
                });
            }

            // ================= RecMcnList
            if(RecMcnList != null)
            {
                RecMcnList.ForEach(x =>
                {
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(int.Parse(x.IpNameNr));
                    data.Add(UpdTrans.IpBaseNr);
                    data.Add(DBNull.Value); // IpNameNrRef
                    data.Add(x.IpBaseNr); // IpBaseNrRef
                    data.Add(x.Name);
                    data.Add(DBNull.Value);
                    data.Add(x.NameType);
                    data.Add(ParseFromTs(x.CreD, x.CreT));
                    data.Add(ParseFromTs(x.AmdD, x.AmdT));
                    data.Add(0);
                    bulkLoaders["IpiName"].AddData(data);
                });
            }

            // ================= RecMunList
            if(RecMunList != null)
            {
                RecMunList.ForEach(x =>
                {
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(int.Parse(x.IpNameNr));
                    data.Add(x.IpBaseNr);
                    data.Add(x.CreClsCde);
                    data.Add(x.RolCde);
                    data.Add(0);
                    bulkLoaders["IpiNameUsage"].AddData(data);
                });
            }

            // ================= RecOnnList
            if(RecOnnList != null)
            {
                RecOnnList.ForEach(x =>
                {
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(int.Parse(x.IpNameNr));
                    data.Add(UpdTrans.IpBaseNr);
                    data.Add(int.Parse(x.IpNameNrRef)); // IpNameNrRef
                    data.Add(DBNull.Value); // IpBaseNrRef
                    data.Add(x.Name);
                    data.Add(x.FstName);
                    data.Add(x.NameType);
                    data.Add(ParseFromTs(x.CreD, x.CreT));
                    data.Add(ParseFromTs(x.AmdD, x.AmdT));
                    data.Add(0);
                    bulkLoaders["IpiName"].AddData(data);
                });
            }

            // ================= RecInnList
            if(RecInnList != null)
            {
                RecInnList.ForEach(x =>
                {
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(int.Parse(x.IpNameNr));
                    data.Add(DBNull.Value);
                    data.Add(x.CreClsCde);
                    data.Add(x.RolCde);
                    data.Add(0);
                    bulkLoaders["IpiNameUsage"].AddData(data);
                });
            }

            // ================= RecNtnList
            if(RecNtnList != null)
            {
                RecNtnList.ForEach(x =>
                {
                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(UpdTrans.IpBaseNr);
                    data.Add(x.TisNr);
                    data.Add(ParseFromDate(x.TisNrValidFrom));
                    data.Add(x.Tisan);
                    data.Add(ParseFromDate(x.TisanValidFrom));
                    bulkLoaders["IpiNationality"].AddData(data);

                });
            }
        }
    }
}
