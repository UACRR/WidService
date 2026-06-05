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
        public class Share
        {
            public string IpName { get; set; }
            public string IpBaseNr { get; set; }
            public string IpNameNr { get; set; }
            public string IpRole { get; set; }
            public string PerSoc { get; set; }
            public string PerShr { get; set; }
            public string MecSoc { get; set; }
            public string MecShr { get; set; }
        }

        public class Work
        {
            public string SocWorkCode { get; set; }
            public string SocCode { get; set; }
            public string SourceDb { get; set; }
            public string Name { get; set; }
            public string Iswc { get; set; }
            public List<string> Iswcs { get; set; }
            public List<Share> Shares { get; set; }
            public List<string> AltNames { get; set; }
            public List<string> Performers { get; set; }

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

        public Work LoadDownloadedFile()
        {
            var xmlDataId = LoadFile();
            var xDoc = LoadXml(xmlDataId);
            ProcessXml(xDoc);
            return _work;
        }

        private int LoadFile()
        {
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            var files = new DirectoryInfo(downloadsPath).GetFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .ToList();

            if (files.Count == 0)
            {
                MessageBox.Show("Не знайдено завантажений файл імпорту CisNet", "Імпорт творів із CisNet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            var file = files[0];

            var xmlLines = File.ReadAllLines(file.FullName).ToList();
            xmlLines.RemoveAt(0);
            var xmlData = string.Join("\r\n", xmlLines);

            XElement elWorkNaturalKey = XElement.Parse(xmlData).Element("mwiWorks").Element("workNaturalKey");
            var socWorkCode = elWorkNaturalKey.Element("societyWorkCode")?.Value;
            var socCode = elWorkNaturalKey.Element("societyCode")?.Value;
            var sourceDb = elWorkNaturalKey.Element("sourceDb")?.Value;

            var xmlDataId = 0;
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
                    from SocCisNet..SingleWorkDownload t1
	                    join #Xmldata t2 on t1.XmlDataHash = t2.XmlDataHash
                ";
                cmd.Parameters.AddWithValue("@xmlData", xmlData);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        r.Read();
                        xmlDataId = r.GetInt32(0);
                    }
                }
            });

            if (xmlDataId == 0)
            {
                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        insert into SocCisNet..SingleWorkDownload(SocCode, SourceDb, SocWorkCode, XmlData, CreatedAt)
                        values(@SocCode, @SourceDb, @SocWorkCode, @xmlData, @createdAt)
                        select cast(scope_identity() as int)
                    ";
                    cmd.Parameters.AddWithValue("@SocCode", socCode);
                    cmd.Parameters.AddWithValue("@SourceDb", sourceDb);
                    cmd.Parameters.AddWithValue("@SocWorkCode", socWorkCode);
                    cmd.Parameters.AddWithValue("@xmlData", xmlData);
                    cmd.Parameters.AddWithValue("@createdAt", file.LastWriteTime);
                    xmlDataId = (int)cmd.ExecuteScalar();
                });
            }

            //foreach (string f in Directory.EnumerateFiles(downloadsPath))
            //{
            //    File.Delete(f);
            //}

            return xmlDataId;
        }

        private XDocument LoadXml(int xmlDataId)
        {
            XDocument xDoc = null;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select XmlData from CisNetImport where Id = @id
                ";
                cmd.Parameters.AddWithValue("@id", xmlDataId);
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
            var name = root.Element("ipReference").Element("name")?.Value;
            var fullName = $"{lastName} {name}".Trim();
            _work.Performers.Add(fullName);
        }

        private void ProcessXml(XDocument xDoc)
        {
            _work = new Work();
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
    }
}
