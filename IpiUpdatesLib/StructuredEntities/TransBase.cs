using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class TransBase
    {
        protected UpdTrans UpdTrans { get; set; }

        public virtual void Apply(List<string> lines)
        {
            if (lines[0].StartsWith("NUD000000000000000020220916205904058SACEM"))
            {
                int a = 100;
            }
            Init(lines);

            SqlTransaction tran = null;
            SqlCommand cmd;
            TryCatch.RunT(() =>
            {
                var dbContext = new IpiUpdatesDbContext();
                using (var conn = new SqlConnection(dbContext.GetConnectionString()))
                using (cmd = conn.CreateCommand())
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        cmd.Transaction = tran;
                        UpdateDatabase(cmd);
                        tran.Commit();
                    }
                }
            }, ex =>
            {
                tran.Rollback();
            });
        }

        public virtual void AddBulkLoadData(List<string> transLines, Dictionary<string, BulkUploadToSql> bulkLoaders)
        {
            Init(transLines);
        }

        public void Init(List<string> lines)
        {
            UpdTrans = (UpdTrans)CreateEntity(lines[0]);
            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            var thisType = GetType();
            var props = thisType.GetProperties(flags);
            for (int i = 1; i < lines.Count; i++)
            {
                var line = lines[i];
                var entity = CreateEntity(line);
                var recType = line.Substring(0, 3);
                var propRootName = char.ToUpper(recType[0]) + recType.Substring(1).ToLower();
                var pi = props.ToList().SingleOrDefault(x => x.Name == ($"Rec{propRootName}"));
                if (pi != null)
                {
                    pi.SetValue(this, entity);
                }
                else
                {
                    //pi = thisType.GetProperty($"Rec{propRootName}List");
                    pi = props.ToList().SingleOrDefault(x => x.Name == ($"Rec{propRootName}List"));
                    if (pi != null)
                    {
                        AddToList(pi, entity);
                    }
                    else if (recType == "MAN")
                    {
                        i = CreateMaNew(lines, i);
                    }
                    else if (recType == "MAO")
                    {
                        i = CreateMaOld(lines, i);
                    }
                }
            }
        }

        private object CreateEntity(string line)
        {
            var recCode = line.Substring(0, 3);
            var info = EntityInfo.GetEntityInfoEntry(recCode);
            var entity = Activator.CreateInstance(info.entityType);
            info.entityPropInfoList.ForEach(x =>
            {
                string value = "";
                if (x.start - 1 < line.Length)
                {
                    value = line.Substring(x.start - 1, x.size).Trim();
                    x.propertyInfo.SetValue(entity, value);
                }
            });
            return entity;
        }

        private void AddToList(PropertyInfo pi, object entity)
        {
            var methodAdd = pi.PropertyType.GetMethod("Add");
            if (pi.GetValue(this) == null)
            {
                var listType = typeof(List<>);
                var constructedListType = listType.MakeGenericType(entity.GetType());
                var instance = Activator.CreateInstance(constructedListType);
                pi.SetValue(this, instance);
            }
            methodAdd.Invoke(pi.GetValue(this), new object[] { entity });
        }

        private int CreateMaNew(List<string> lines, int startIndex)
        {
            var maNew = new MaNew();
            var entity = CreateEntity(lines[startIndex]);
            maNew.RecMan = (RecMan)entity;
            var i = startIndex + 1;
            for (; i < lines.Count; i++)
            {
                var line = lines[i];
                if (line.Substring(0, 3) != "TMA")
                {
                    break;
                }
                entity = CreateEntity(lines[i]);
                maNew.RecTmaList.Add((RecTma)entity);
            }
            var pi = GetType().GetProperty("ManList", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            AddToList(pi, maNew);

            return i - 1;
        }

        private int CreateMaOld(List<string> lines, int startIndex)
        {
            var maOld = new MaOld();
            var entity = CreateEntity(lines[startIndex]);
            maOld.RecMao = (RecMao)entity;
            var i = startIndex + 1;
            for (; i < lines.Count; i++)
            {
                var line = lines[i];
                if (line.Substring(0, 3) != "TMA")
                {
                    break;
                }
                entity = CreateEntity(lines[i]);
                maOld.RecTmaList.Add((RecTma)entity);
            }
            var pi = GetType().GetProperty("MaoList", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            AddToList(pi, maOld);

            return i - 1;
        }
        protected DateTime ParseFromTs(string date)
        {
            if(date.CompareTo("19000101") == -1 || date == "10000101" || date == "        " || date == "00000000" || date == "")
            {
                date = "19000101";
            }
            return new DateTime(
                int.Parse(date.Substring(0, 4)),
                int.Parse(date.Substring(4, 2)),
                int.Parse(date.Substring(6, 2)),
                0,
                0,
                0
            );
        }
        protected DateTime ParseFromTs(string date, string time)
        {
            if (date.CompareTo("19000101") == -1 || date == "10000101" || date == "        " || date == "00000000" || date == "")
            {
                date = "19000101";
            }
            return new DateTime(
                int.Parse(date.Substring(0, 4)),
                int.Parse(date.Substring(4, 2)),
                int.Parse(date.Substring(6, 2)),
                int.Parse(time.Substring(0, 2)),
                int.Parse(time.Substring(2, 2)),
                int.Parse(time.Substring(4, 2))
            );
        }
        protected DateTime ParseFromDate(string yy, string mm, string dd)
        {
            if (yy.CompareTo("1900") == -1 || yy == "    " || yy == "0000" || yy == "")
            {
                yy = "1900";
                mm = "01";
                dd = "01";
            }
            else
            {
                if (mm == "  " || mm == "00" || mm == "")
                {
                    mm = "01";
                }
                if (dd == "  " || dd == "00" || dd == "")
                {
                    dd = "01";
                }
            }

            try
            {
                return new DateTime(
                    int.Parse(yy),
                    int.Parse(mm),
                    int.Parse(dd)
                );

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        protected DateTime ParseFromDate(string date)
        {
            if (date.CompareTo("19000101") == -1 || date == "10000101" || date == "        " || date == "")
            {
                date = "19000101";
            }
            return new DateTime(
                int.Parse(date.Substring(0, 4)),
                int.Parse(date.Substring(4, 2)),
                int.Parse(date.Substring(6, 2))
            );
        }
        protected DateTime ParseToTs(string date)
        {
            if (date.CompareTo("19000101") == -1 || date == "10000101" || date == "        " || date == "00000000" || date == "")
            {
                date = "99991231";
            }
            return new DateTime(
                int.Parse(date.Substring(0, 4)),
                int.Parse(date.Substring(4, 2)),
                int.Parse(date.Substring(6, 2)),
                0,
                0,
                0
            );
        }
        protected DateTime ParseToTs(string date, string time)
        {
            if (date.CompareTo("19000101") == -1 || date.CompareTo("99991231") == 1 || date == "10000101" || date == "        " || date == "00000000" || date == "")
            {
                date = "99991231";
            }
            return new DateTime(
                int.Parse(date.Substring(0, 4)),
                int.Parse(date.Substring(4, 2)),
                int.Parse(date.Substring(6, 2)),
                int.Parse(time.Substring(0, 2)),
                int.Parse(time.Substring(2, 2)),
                int.Parse(time.Substring(4, 2))
            );
        }
        protected DateTime ParseToDate(string yy, string mm, string dd)
        {
            if (yy.CompareTo("1900") == -1 || yy.CompareTo("9999") == 1 || yy == "    " || yy == "0000" || yy == "")
            {
                yy = "9999";
            }
            if (mm == "  " || mm == "00" || mm == "")
            {
                mm = "12";
            }
            if (dd == "  " || dd == "00" || dd == "")
            {
                dd = "01";
            }

            try
            {
                return new DateTime(
                    int.Parse(yy),
                    int.Parse(mm),
                    int.Parse(dd)
                );
            }
            catch(Exception ex)
            {
                throw;
            }

        }
        protected DateTime ParseToDate(string date)
        {
            if (date.CompareTo("19000101") == -1 || date.CompareTo("99991231") == 1 || date == "10000101" || date == "        " || date == "")
            {
                date = "99991231";
            }
            return new DateTime(
                int.Parse(date.Substring(0, 4)),
                int.Parse(date.Substring(4, 2)),
                int.Parse(date.Substring(6, 2))
            );
        }
        protected decimal ParseShare(string share)
        {
            return decimal.Parse(share.Substring(0, 3)) +
                   decimal.Parse(share.Substring(3, 2)) * (decimal)0.01;
        }

        protected virtual void UpdateDatabase(SqlCommand cmd)
        {
            ApplyToIpiBase(cmd);
            ApplyToIpiName(cmd);
            ApplyToIpiNameUsage(cmd);
            ApplyToIpiAgreement(cmd);
            ApplyToIpiStatus(cmd);
            ApplyToIpiTerritory(cmd);
            ApplyToIpiRemark(cmd);
            ApplyToIpiNationality(cmd);
        }

        protected virtual void ApplyToIpiBase(SqlCommand cmd)
        {

        }

        protected virtual void ApplyToIpiName(SqlCommand cmd)
        {

        }

        protected virtual void ApplyToIpiNameUsage(SqlCommand cmd)
        {

        }

        protected virtual void ApplyToIpiAgreement(SqlCommand cmd)
        {

        }
        protected virtual void ApplyToIpiStatus(SqlCommand cmd)
        {

        }
        protected virtual void ApplyToIpiTerritory(SqlCommand cmd)
        {

        }

        protected virtual void ApplyToIpiRemark(SqlCommand cmd)
        {

        }
        protected virtual void ApplyToIpiNationality(SqlCommand cmd)
        {

        }
    }
}
