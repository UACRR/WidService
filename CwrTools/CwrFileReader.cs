using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwrTools
{
    public class CwrFileReader
    {
        private Dictionary<string, BulkUploadToSql> _bulkLoaders;

        private int _cwrFileId;
        private string _tranRecordType;

        private void LoadLine(SqlCommand cmd, string line)
        {
            var recType = line.Substring(0, 3);
            var specRecord = MetaData.GetSpecRecord(recType);

            BulkUploadToSql bulkLoader;
            if (_bulkLoaders.ContainsKey(recType))
            {
                bulkLoader = _bulkLoaders[recType];
            }
            else
            {
                bulkLoader = new BulkUploadToSql();
                bulkLoader.conn = cmd.Connection;
                bulkLoader.TableName = specRecord.TableName;
                _bulkLoaders.Add(recType, bulkLoader);
            }

            var data = new List<object>();
            data.Add(DBNull.Value); //Id
            data.Add(_cwrFileId);
            if (string.Compare(recType, "HDR", StringComparison.OrdinalIgnoreCase) != 0)
            {
                data.Add(DBNull.Value); //Ref Field
            }
            var specFiled = specRecord.SpecFields[0];
            if (string.Compare(specFiled.Field, "RecordPrefix", StringComparison.OrdinalIgnoreCase) == 0)
            {
                var recordType = line.Substring(0, 3);
                var tranSeqNr = line.Substring(3, 8);
                var recSeqNr = line.Substring(11, 8);

                if (specRecord.IsTran)
                {
                    _tranRecordType = recordType;
                }

                if (!specRecord.IsTran)
                {
                    data.Add(_tranRecordType); // RecSeqNr
                }

                data.Add(int.Parse(tranSeqNr)); //TranSeqNr
                if (!specRecord.IsTran)
                {
                    data.Add(int.Parse(recSeqNr)); // RecSeqNr
                }
            }

            for (var idx = 1; idx < specRecord.SpecFields.Count; idx++)
            {
                specFiled = specRecord.SpecFields[idx];
                data.Add(specFiled.GetValue(line)); // Spec Field Value
            }

            bulkLoader.AddData(data);
        }

        public void LoadFile(string fileFullName, string direction)
        {
            _bulkLoaders = new Dictionary<string, BulkUploadToSql>();

            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCwrFileRegister";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Direction", direction);
                cmd.Parameters.AddWithValue("@Path", Path.GetDirectoryName(fileFullName));
                cmd.Parameters.AddWithValue("@Name", Path.GetFileName(fileFullName));
                _cwrFileId = (int)cmd.ExecuteScalar();

                using (var fileStream = File.OpenRead(fileFullName))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
                {
                    var line = "";
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line.Trim()))
                        {
                            break;
                        }
                        LoadLine(cmd, line);
                    }
                }

                _bulkLoaders.Values.ToList().ForEach(x =>
                {
                    x.Flush();
                });

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCreateReferences";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cwrFileId", _cwrFileId);
                cmd.ExecuteNonQuery();

            });

        }
        public CwrFile ReadFile(string fileFullName)
        {
            var cwrFile = new CwrFile
            {
                CrwFileId = 0,
                FileFullName = fileFullName,
            };
            RecHdr recHdr = null;
            RecGrh recGrh = null;
            BaseRecTran baseRecTran = null;

            var entityList = new List<BaseRec>();
            using (var fileStream = File.OpenRead(fileFullName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                var line = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line.Trim()))
                    {
                        break;
                    }
                        
                    var recordType = line.Substring(0, 3);
                    var specRecord = MetaData.GetSpecRecord(recordType);
                    var entityType = Type.GetType($"CwrTools.{MetaData.GetClassName(recordType)}");
                    var entity = (BaseRec)Activator.CreateInstance(entityType);
                    entity.FromLine(line);

                    switch(recordType)
                    {
                        case "HDR":
                            recHdr = (RecHdr)entity;
                            cwrFile.RecHdr = recHdr;
                            break;
                        case "TRL":
                            recHdr.RecTrl = (RecTrl)entity;
                            break;
                        case "GRH":
                            recGrh = (RecGrh)entity;
                            if (recHdr.GroupList == null) recHdr.GroupList = new List<RecGrh>();
                            recHdr.GroupList.Add((RecGrh)entity);
                            break;
                        case "GRT":
                            recGrh.RecGrt = (RecGrt)entity;
                            break;
                        default:
                            if(specRecord.IsTran)
                            {
                                baseRecTran = (BaseRecTran)entity;
                                if (recGrh.TranList == null) recGrh.TranList = new List<BaseRecTran>();
                                recGrh.TranList.Add((BaseRecTran)entity);
                            }
                            else if(specRecord.IsDetail)
                            {
                                if (baseRecTran.DetailList == null) baseRecTran.DetailList = new List<BaseRecDetail>();
                                baseRecTran.DetailList.Add((BaseRecDetail)entity);
                            }
                            else
                            {
                                throw new Exception("Невідомий тип запису");
                            }
                            break;
                    }
                    entityList.Add(entity);
                }
            }

            return cwrFile;
        }

    }
}
