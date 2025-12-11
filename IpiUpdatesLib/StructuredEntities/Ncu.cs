using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Ncu: TransBase
    {
        protected RecNco RecNco { get; set; }
        protected List<RecNuo> RecNuoList { get; set; }
        protected RecNcn RecNcn { get; set; }
        protected List<RecNun> RecNunList { get; set; }
        protected RecMco RecMco { get; set; }
        protected List<RecMuo> RecMuoList { get; set; }
        protected RecMcn RecMcn { get; set; }
        protected List<RecMun> RecMunList { get; set; }
        protected List<RecIno> RecInoList { get; set; }
        protected List<RecImo> RecImoList { get; set; }
        protected RecOno RecOno { get; set; }
        protected RecOnn RecOnn { get; set; }
        protected List<RecInn> RecInnList { get; set; }
        protected List<RecImn> RecImnList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
            // OLD
            cmd.CommandText = SqlQueries.DeleteIpiName;
            if (RecNco != null)
            {
                var x = RecNco;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = SqlQueries.DeleteIpiNameUsage;
            if (RecNuoList != null)
            {
                RecNuoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.DeleteIpiName;
            if (RecMco != null)
            {
                var x = RecMco;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.Parameters.AddWithValue("@FstName", "");
                cmd.Parameters.AddWithValue("@Name", x.Name);
                cmd.Parameters.AddWithValue("@NameType", x.NameType);
                cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = SqlQueries.DeleteIpiNameUsage;
            if (RecMuoList != null)
            {
                RecMuoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.DeleteIpiName;
            if (RecInoList != null)
            {
                RecInoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.DeleteIpiName;
            if (RecImoList != null)
            {
                RecImoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.DeleteIpiName;
            if (RecOno != null)
            {
                var x = RecOno;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.ExecuteNonQuery();
            }

            // NEW
            cmd.CommandText = SqlQueries.AddIpiName;
            if (RecNcn != null)
            {
                var x = RecNcn;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.Parameters.AddWithValue("@IpNameNrRef", DBNull.Value);
                cmd.Parameters.AddWithValue("@IpBaseNrRef", DBNull.Value);
                cmd.Parameters.AddWithValue("@FstName", x.FstName);
                cmd.Parameters.AddWithValue("@Name", x.Name);
                cmd.Parameters.AddWithValue("@NameType", x.NameType);
                cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                cmd.ExecuteNonQuery();
            }

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

            cmd.CommandText = SqlQueries.AddIpiName;
            if (RecMcn != null)
            {
                var x = RecMcn;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.Parameters.AddWithValue("@IpNameNrRef", DBNull.Value);
                cmd.Parameters.AddWithValue("@IpBaseNrRef", x.IpBaseNr);
                cmd.Parameters.AddWithValue("@FstName", "");
                cmd.Parameters.AddWithValue("@Name", x.Name);
                cmd.Parameters.AddWithValue("@NameType", x.NameType);
                cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = SqlQueries.AddIpiNameUsage;
            if (RecMunList != null)
            {
                RecMunList.ForEach(x =>
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

            cmd.CommandText = SqlQueries.AddIpiName;
            if (RecOnn != null)
            {
                var x = RecOnn;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.Parameters.AddWithValue("@IpNameNrRef", int.Parse(x.IpNameNrRef));
                cmd.Parameters.AddWithValue("@IpBaseNrRef", DBNull.Value);
                cmd.Parameters.AddWithValue("@FstName", x.FstName);
                cmd.Parameters.AddWithValue("@Name", x.Name);
                cmd.Parameters.AddWithValue("@NameType", x.NameType);
                cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = SqlQueries.AddIpiNameUsage;
            if (RecInnList != null)
            {
                RecInnList.ForEach(x =>
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

            cmd.CommandText = SqlQueries.AddIpiNameUsage;
            if (RecImnList != null)
            {
                RecImnList.ForEach(x =>
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
        }
    }
}
