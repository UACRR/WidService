using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Data.SqlTypes;

namespace RadioStationReports
{
    public class CisNetSingleWorkImporter
    {
        private const string IpNameNrUnknown = "00258374538";

        public class Share
        {
            public string IpName    { get; set; }
            public string IpBaseNr  { get; set; }
            public string IpNameNr  { get; set; }
            public string IpRole    { get; set; }
            public string PerSoc    { get; set; }
            public string PerShr    { get; set; }
            public string MecSoc    { get; set; }
            public string MecShr    { get; set; }
        }

        public class Work
        {
            public int          SingleWorkDownloadId { get; set; }
            public string       SocWorkCode          { get; set; }
            public string       SocCode              { get; set; }
            public string       SourceDb             { get; set; }
            public string       Name                 { get; set; }
            public string       Iswc                 { get; set; }
            public List<string> Iswcs                { get; set; }
            public List<Share>  Shares               { get; set; }
            public List<string> AltNames             { get; set; }
            public List<string> Performers           { get; set; }

            public Work()
            {
                Iswcs = new List<string>();
                Shares = new List<Share>();
                AltNames = new List<string>();
                Performers = new List<string>();
            }
        }

        private Work _work;

        public CisNetSingleWorkImporter()
        {
        }

        #region Обробка файлу
        public Work LoadDownloadedFile()
        {
            // Реєструємо імпортований файл в БД
            var singleWorkDownloadId = LoadFile();
            if(singleWorkDownloadId == 0) return null;
            // Читаємо XML з БД 
            var xDoc = LoadXml(singleWorkDownloadId);
            // Розбираємо XML і заносимо в інформацію про твір у структури в памяті
            ProcessXml(xDoc, singleWorkDownloadId);
            return _work; // Щоб мати змогу показати інформацію зовні
        }

        private int LoadFile()
        {
            // Функцію слід виконувати в захищеному блоці.Це універсальний захист від проблем спричиненим невірним форматом файлу.

            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

           // Вибираємо останні завантажений в інтернет провіднику файл
            var files = new DirectoryInfo(downloadsPath).GetFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .ToList();

            if (files.Count == 0)
            {
                MessageBox.Show("Не знайдено завантажений файл імпорту CisNet", "Імпорт творів із CisNet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            var file = files[0];

            // Читаємо вміст файлу
            var xmlLines = File.ReadAllLines(file.FullName).ToList();
            xmlLines.RemoveAt(0);
            var xmlData = string.Join("\r\n", xmlLines);

            // Виділяємо попередню внформацію із вмісту файлу
            var elRoot = XElement.Parse(xmlData).Element("mwiWorks");
            var elWorkNaturalKey = elRoot.Element("workNaturalKey");
            var socWorkCode = elWorkNaturalKey.Element("societyWorkCode")?.Value;
            var socCode = elWorkNaturalKey.Element("societyCode")?.Value;
            var sourceDb = elWorkNaturalKey.Element("sourceDb")?.Value;
            var iswc = elRoot.Element("iswcPrefered")?.Value;
            var tisan = elRoot.Element("shareTerritories").Element("territoryExpression")?.Value;

            if (socCode == "140")
            {
                MessageBox.Show("Твір опублікований УААСП і не буде розглянутий", "Імпорт творів із CisNet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            //if (sourceDb == "300")
            //{
            //    MessageBox.Show("Твір існує в WID і не буде розглянутий", "Імпорт творів із CisNet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return 0;
            //}

            if (string.IsNullOrEmpty(iswc))
            {
                MessageBox.Show("Твір не містить коду ISWC і не буде розглянутий", "Імпорт творів із CisNet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            //if (string.IsNullOrEmpty(tisan) || (tisan != "2136" && tisan != "+2136"))
            //{
            //    MessageBox.Show("Твір не має прав на весь світ і не буде розглянутий", "Імпорт творів із CisNet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return 0;
            //}

            // Видаляємо реєстрації для яких не було імпортовано твір у СМАРТ
            Helpers.RunSql(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SocCisNet..spDeleteIncompleteDownloads";
                cmd.ExecuteNonQuery();
            });

            // Шукаємо в БД реєстрацію файлу спираючись на XML
            var singleWorkDownloadId = 0;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    create table #Xmldata(
	                      XmlData xml
	                    , XmlDataHash as cast(hashbytes('sha2_256', cast(Xmldata as varchar(max))) as varbinary(32)) persisted
                    )
                    insert #Xmldata(XmlData)
                    values(@xmlData)
                    select t1.Id
                    from SocCisNet..SingleWorkDownloads t1
	                    join #Xmldata t2 on t1.XmlDataHash = t2.XmlDataHash
                ";
                cmd.Parameters.AddWithValue("@xmlData", xmlData);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        r.Read();
                        singleWorkDownloadId = r.GetInt32(0);
                    }
                }
            });

            // Якщо не знайшли створюємо реєстрацію
            if (singleWorkDownloadId == 0)
            {
                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        insert into SocCisNet..SingleWorkDownloads(SocCode, SourceDb, SocWorkCode, XmlData, CreatedAt)
                        values(@SocCode, @SourceDb, @SocWorkCode, @xmlData, @createdAt)
                        select cast(scope_identity() as int)
                    ";
                    cmd.Parameters.AddWithValue("@SocCode", socCode);
                    cmd.Parameters.AddWithValue("@SourceDb", sourceDb);
                    cmd.Parameters.AddWithValue("@SocWorkCode", socWorkCode);
                    cmd.Parameters.AddWithValue("@xmlData", xmlData);
                    cmd.Parameters.AddWithValue("@createdAt", file.LastWriteTime);
                    singleWorkDownloadId = (int)cmd.ExecuteScalar();
                });
            }

            //foreach (string f in Directory.EnumerateFiles(downloadsPath))
            //{
            //    File.Delete(f);
            //}

            // 
            return singleWorkDownloadId;
        }

        private XDocument LoadXml(int singleWorkDownloadId)
        {
            XDocument xDoc = null;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select XmlData from SocCisNet..SingleWorkDownloads where Id = @id
                ";
                cmd.Parameters.AddWithValue("@id", singleWorkDownloadId);
                using (SqlDataReader r = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    if (r.Read())
                    {
                        // Stream the XML column directly into an XmlReader
                        using (XmlReader xmlReader = r.GetXmlReader(0))
                        {
                            xDoc = XDocument.Load(xmlReader);
                        }
                    }
                }
            });
            return xDoc;
        }

        private void ProcessWorkNaturalKey(XElement root)
        {
            foreach (XElement el in root.Descendants())
            {
                if (el.Name == "societyWorkCode")
                {
                    _work.SocWorkCode = el.Value;
                }
                else if (el.Name == "societyCode")
                {
                    _work.SocCode = el.Value;
                }
                else if (el.Name == "sourceDb")
                {
                    _work.SourceDb = el.Value;
                }
            }
        }

        private void ProcessWorkTitles(XElement root)
        {
            var name = root.Element("title").Value;
            var type = root.Element("titleType").Value;
            if (type == "OT") _work.Name = name;
            _work.AltNames.Add(name);
        }

        private void ProcessIswcPrefered(XElement root)
        {
            _work.Iswc = root.Value;
            _work.Iswcs.Add(root.Value);
        }

        private void ProcessIswc(XElement root)
        {
            _work.Iswcs.Add(root.Value);
        }

        private void ProcessInterestedPartyRoles(XElement root)
        {
            var share = new Share();
            foreach (XElement el in root.Descendants())
            {
                if (el.Name == "interestedParty")
                {
                    var firstName = el.Element("firstname")?.Value;
                    var lastName = el.Element("lastname")?.Value;
                    share.IpName = $"{lastName} {firstName}".Trim();
                    share.IpBaseNr = el.Element("ipBaseNumber")?.Value;
                    share.IpNameNr = el.Element("ipNameNumber")?.Value;
                    if(share.IpNameNr == null) share.IpNameNr = IpNameNrUnknown;
                }
                else if (el.Name == "ipRole")
                {
                    share.IpRole = el.Value;
                }
                else if (el.Name == "shares")
                {
                    var rightType = el.Element("rightType")?.Value;
                    if (rightType == "PER")
                    {
                        share.PerSoc = el.Element("affiliationSociety")?.Value;
                        share.PerShr = el.Element("share")?.Value;
                    }
                    else
                    {
                        share.MecSoc = el.Element("affiliationSociety")?.Value;
                        share.MecShr = el.Element("share")?.Value;
                    }
                }
            }
            _work.Shares.Add(share);
        }

        private void ProcessShareTerritories(XElement root)
        {
            foreach (XElement el in root.Descendants())
            {
                if (el.Name == "interestedPartyRoles")
                {
                    ProcessInterestedPartyRoles(el);
                }
            }
        }

        private void ProcessArtists(XElement root)
        {
            var lastName = root.Element("ipReference").Element("lastname")?.Value;
            var name = root.Element("ipReference").Element("firstname")?.Value;
            var fullName = $"{lastName} {name}".Trim();
            _work.Performers.Add(fullName);
        }

        private void ProcessXml(XDocument xDoc, int singleWorkDownloadId)
        {
            _work = new Work();
            _work.SingleWorkDownloadId = singleWorkDownloadId;
            var elRoot = xDoc.Descendants("mwiWorks");
            foreach (XElement el in elRoot.Descendants())
            {
                if (el.Name == "workNaturalKey")
                {
                    ProcessWorkNaturalKey(el);
                }
                else if (el.Name == "workTitles")
                {
                    ProcessWorkTitles(el);
                }
                else if (el.Name == "iswcPrefered")
                {
                    ProcessIswcPrefered(el);
                }
                else if (el.Name == "iswcs")
                {
                    ProcessIswc(el);
                }
                else if (el.Name == "shareTerritories")
                {
                    ProcessShareTerritories(el);
                }
                else if (el.Name == "artists")
                {
                    ProcessArtists(el);
                }
            }
        }
        #endregion

        private int SaveWorkInDb(SqlCommand cmd)
        {
            cmd.CommandText = @"
                insert SocCisNet..Works (
                      SingleWorkDownloadId
	                , SocWorkCode
	                , SocCode    
	                , SourceDb   
	                , Name       
	                , Iswc       
	                , CreatedAt 
                )
                values (
                      @singleWorkDownloadId
	                , @socWorkCode
	                , @socCode    
	                , @sourceDb   
	                , @name       
	                , @iswc       
	                , getdate()
                )
                select cast(scope_identity() as int)
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@singleWorkDownloadId".Trim(), _work.SingleWorkDownloadId  );
            cmd.Parameters.AddWithValue("@socWorkCode         ".Trim(), _work.SocWorkCode           );
            cmd.Parameters.AddWithValue("@socCode             ".Trim(), _work.SocCode               );
            cmd.Parameters.AddWithValue("@sourceDb            ".Trim(), _work.SourceDb              );
            cmd.Parameters.AddWithValue("@name                ".Trim(), _work.Name                  );
            cmd.Parameters.AddWithValue("@iswc                ".Trim(), _work.Iswc                  );
            return (int)cmd.ExecuteScalar();
        }

        private void SaveWorkSharesInDb(SqlCommand cmd, int workId, Share share)
        {
            cmd.CommandText = @"
                insert SocCisNet..WorkShares (
                      WorkId  
	                , IpName  
	                , IpBaseNr
	                , IpNameNr
	                , IpRole  
	                , PerSoc  
	                , PerShr  
	                , MecSoc  
	                , MecShr  
	                , CreatedAt
                )
                values (
                      @workId  
	                , @ipName  
	                , @ipBaseNr
	                , @ipNameNr
	                , @ipRole  
	                , @perSoc  
	                , @perShr  
	                , @mecSoc  
	                , @mecShr  
	                , getdate()
                )
            ";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@workId  ".Trim(), workId                                );
            cmd.Parameters.AddWithValue("@ipName  ".Trim(), share.IpName                          );
            cmd.Parameters.AddWithValue("@ipBaseNr".Trim(), share.IpBaseNr ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ipNameNr".Trim(), share.IpNameNr                        );
            cmd.Parameters.AddWithValue("@ipRole  ".Trim(), share.IpRole                          );
            cmd.Parameters.AddWithValue("@perSoc  ".Trim(), share.PerSoc ?? (object)DBNull.Value  );
            cmd.Parameters.AddWithValue("@perShr  ".Trim(), share.PerShr ?? (object)DBNull.Value  );
            cmd.Parameters.AddWithValue("@mecSoc  ".Trim(), share.MecSoc ?? (object)DBNull.Value  );
            cmd.Parameters.AddWithValue("@mecShr  ".Trim(), share.MecShr ?? (object)DBNull.Value  );
            
            cmd.ExecuteNonQuery();
        }

        private void SaveWorkAltNamesInDb(SqlCommand cmd, int workId, string name)
        {
            cmd.CommandText = @"
                insert SocCisNet..WorkAltNames (
                      WorkId  
	                , Name  
	                , CreatedAt
                )
                values (
                      @workId  
	                , @name  
	                , getdate()
                )
            ";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@workId".Trim(), workId);
            cmd.Parameters.AddWithValue("@name  ".Trim(), name  );
            
            cmd.ExecuteNonQuery();
        }

        private void SaveWorkPerformersInDb(SqlCommand cmd, int workId, string name)
        {
            cmd.CommandText = @"
                insert SocCisNet..WorkPerformers (
                      WorkId  
	                , Name  
	                , CreatedAt
                )
                values (
                      @workId  
	                , @name  
	                , getdate()
                )
            ";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@workId".Trim(), workId);
            cmd.Parameters.AddWithValue("@name  ".Trim(), name  );
            
            cmd.ExecuteNonQuery();
        }

        private int SaveSingleWorkInDb(SqlCommand cmd)
        {
            var workId = SaveWorkInDb(cmd);
            _work.Shares.ForEach(share => {
                SaveWorkSharesInDb(cmd, workId, share);
            });
            _work.AltNames.ForEach(name => {
                SaveWorkAltNamesInDb(cmd, workId, name);
            });
            _work.Performers.ForEach(name => {
                SaveWorkPerformersInDb(cmd, workId, name);
            });

            cmd.CommandText = @"
                update t2
                set t2.IpBaseNr = t3.IpBaseNr
                from SocCisNet..Works t1
	                join SocCisNet..WorkShares t2 on t1.Id = t2.WorkId
	                left join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
                where t1.SocWorkCode = @socWorkCode
	                and t1.SocCode = @socCode
	                and t1.SourceDb = @sourceDb
	                and t2.IpBaseNr is null
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@socWorkCode", _work.SocWorkCode);
            cmd.Parameters.AddWithValue("@socCode", _work.SocCode);
            cmd.Parameters.AddWithValue("@sourceDb", _work.SourceDb);
            cmd.ExecuteNonQuery();

            return workId;
        }

        private int ImportSingleWorkToMs(SqlCommand cmd, int workId)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SocCisNet..spImportWorkFromCisNet";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@workId", workId);
            cmd.Parameters.AddWithValue("@showTrace", false);
            var objIdParam = new SqlParameter("@objId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
            };
            cmd.Parameters.Add(objIdParam);
            
            cmd.ExecuteNonQuery();

            return (int)objIdParam.Value;

        }

        public int ApplyImportedWork()
        {
            if(_work == null )
            {
                MessageBox.Show("Твір не обрано", "Імпорт творів із CisNet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            var objId = 0;
            
            // Перевіряємо чи вже імпортовано
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select ObjId
                    from SocCisNet..Works t1
                        join SocCisNet..SingleWorkDownloads t2 on t1.SingleWorkDownloadId = t2.Id
                    where t2.Id = @singleWorkDownloadId
                ";
                cmd.Parameters.AddWithValue("@singleWorkDownloadId", _work.SingleWorkDownloadId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    if(r.HasRows)
                    {
                        objId = r.GetInt32(0);
                    }
                }
            });

            // Перешкоджаємо подвоєнню
            if(objId != 0) return objId;

            // Імпортуємо
            Helpers.RunSql(cmd =>
            {
                var workId = SaveSingleWorkInDb(cmd);
                objId = ImportSingleWorkToMs(cmd, workId);
            });

            return objId;
        }
    }
}
