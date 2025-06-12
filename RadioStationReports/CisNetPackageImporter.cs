using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System;
using System.Globalization;
using System.Text;

namespace RadioStationReports
{
    public class CisNetPackageImporter
    {
        public void ImportWorks(string fileFullName)
        {
            var xDoc = new XmlDocument();
            xDoc.LoadXml(PreProcessPackage(fileFullName));
            //xDoc.Load(fileFullName);
            var xRoot = xDoc.DocumentElement;

            Helpers.RunSqlT(cmd =>
            {
                AddPackage(cmd, xRoot);
            });
        }

        private string PreProcessPackage(string fileFullName)
        {
            var sbRetVal = new StringBuilder();
            using (var fileStream = File.OpenRead(fileFullName))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
                {
                    String line = streamReader.ReadLine();
                    sbRetVal.AppendLine(line);
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var idx = line.IndexOf("<?");
                        if (idx >= 0)
                        {
                            sbRetVal.AppendLine(line.Substring(0, idx));
                            break;
                        }
                        else
                        {
                            sbRetVal.AppendLine(line);
                        }
                    }
                }
            }
            var retVal = sbRetVal.ToString();
            return sbRetVal.ToString(); 
        }

        private void AddPackage(SqlCommand cmd, XmlElement xRoot)
        {
            var packageId = 0;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SocCisNet..spInsertPackage";
            cmd.Parameters.Clear();
            var parPackageId = cmd.Parameters.AddWithValue("@PackageId", DBNull.Value);
            var parCreatedAt = cmd.Parameters.AddWithValue("@CreatedAt", DBNull.Value);
            var parLoadedAt  = cmd.Parameters.AddWithValue("@LoadedAt" , DateTime.Now);

            foreach (XmlElement el in xRoot)
            {
                switch (el.Name)
                {
                    case "packageId":
                        packageId = int.Parse(el.InnerText);
                        parPackageId.Value = packageId;
                        break;
                    case "creationDate":
                        parCreatedAt.Value = DateTime.Parse(el.InnerText);
                        break;
                }
            }

            cmd.ExecuteNonQuery();

            AddWorks(cmd, xRoot, packageId);
        }

        private void AddWorks(SqlCommand cmd, XmlElement xRoot, int packageId)
        {
            foreach (XmlElement el in xRoot)
            {
                switch (el.Name)
                {
                    case "mwiItemDetails":
                        AddWork(cmd, el, packageId);
                        break;
                 }
            }
       }

        private void AddWork(SqlCommand cmd, XmlElement elMwiItemDetails, int packageId)
        {
            var workId = 0;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SocCisNet..spInsertWork";
            cmd.Parameters.Clear();
            var parWorkId		= cmd.Parameters.AddWithValue("@WorkId"     , DBNull.Value);
            var parName			= cmd.Parameters.AddWithValue("@Name"       , DBNull.Value);
            var parIswc			= cmd.Parameters.AddWithValue("@Iswc"       , DBNull.Value);
            var parSrcWorkId	= cmd.Parameters.AddWithValue("@SrcWorkId"  , DBNull.Value);
            var parSrcSocCde	= cmd.Parameters.AddWithValue("@SrcSocCde"  , DBNull.Value);
            var parSrcDbCde		= cmd.Parameters.AddWithValue("@SrcDbCde"   , DBNull.Value);
            var parRefWorkCde	= cmd.Parameters.AddWithValue("@RefWorkCde" , DBNull.Value);
            var parSubmittedAt  = cmd.Parameters.AddWithValue("@SubmittedAt", DBNull.Value);
            var parCreatedAt	= cmd.Parameters.AddWithValue("@CreatedAt"  , DBNull.Value);
            var parUpdatedAt	= cmd.Parameters.AddWithValue("@UpdatedAt"  , DBNull.Value);
            var parLoadedAt		= cmd.Parameters.AddWithValue("@LoadedAt"   , DateTime.Now);

            foreach (XmlElement elMwiItemDetail in elMwiItemDetails)
            {
                switch (elMwiItemDetail.Name)
                {
                    case "itemId":
                        workId = int.Parse(elMwiItemDetail.InnerText);
                        parWorkId.Value = workId;
                        break;
                     case "originalTitle":
                        parName.Value = elMwiItemDetail.InnerText;
                        break;
                    case "preferedIswc":
                        parIswc.Value = elMwiItemDetail.InnerText;
                        break;
                    case "referenceNumbers":
                        parRefWorkCde.Value = int.Parse(elMwiItemDetail.InnerText);
                        break;
                    case "workDetail":
                        {
                            foreach (XmlElement elWorkDetail in elMwiItemDetail)
                            {
                                switch(elWorkDetail.Name)
                                {
                                    case "postDate":
                                        parSubmittedAt.Value = DateTime.Parse(elWorkDetail.InnerText);
                                        break;
                                    case "lastUpdateDate":
                                        parUpdatedAt.Value = DateTime.Parse(elWorkDetail.InnerText);
                                        break;
                                    case "createDate":
                                        parCreatedAt.Value = DateTime.Parse(elWorkDetail.InnerText);
                                        break;
                                    case "workNaturalKey":
                                        {
                                            foreach (XmlElement elWorkNaturalKey in elWorkDetail)
                                            {
                                                switch(elWorkNaturalKey.Name)
                                                {
                                                    case "societyWorkCode":
                                                        parSrcWorkId.Value = int.Parse(elWorkNaturalKey.InnerText);
                                                        break;
                                                    case "societyCode":
                                                        parSrcSocCde.Value = int.Parse(elWorkNaturalKey.InnerText);
                                                        break;
                                                    case "sourceDb":
                                                        parSrcDbCde.Value = int.Parse(elWorkNaturalKey.InnerText);
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
            cmd.ExecuteNonQuery();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SocCisNet..spInsertPackageWork";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PackageId", packageId);
            cmd.Parameters.AddWithValue("@WorkId"  , workId);
            cmd.ExecuteNonQuery();

            foreach (XmlElement elMwiItemDetail in elMwiItemDetails)
            {
                switch (elMwiItemDetail.Name)
                {
                    case "workDetail":
                        {
                            foreach (XmlElement elWorkDetail in elMwiItemDetail)
                            {
                                switch(elWorkDetail.Name)
                                {
                                    case "workTitles":
                                        AddAltName(cmd, elWorkDetail, workId);
                                        break;
                                    case "artists":
                                        AddPerformer(cmd, elWorkDetail, workId);
                                        break;
                                    case "shareTerritories":
                                        AddRightHolders(cmd, elWorkDetail, workId);
                                        break;
                                    case "submissions":
                                        AddSubmission(cmd, elWorkDetail, workId);
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
        }

        private void AddAltName(SqlCommand cmd, XmlElement elWorkTitles, int workId)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SocCisNet..spInsertWorkAltName";
            cmd.Parameters.Clear();
            var parName = cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            var parNameType = cmd.Parameters.AddWithValue("@NameType", DBNull.Value);
            var parLen = cmd.Parameters.AddWithValue("@Lan", DBNull.Value);
            cmd.Parameters.AddWithValue("@WorkId"  , workId);

            foreach (XmlElement el in elWorkTitles)
            {
                switch (el.Name)
                {
                    case "languageCode":
                        parLen.Value = el.InnerText;   
                        break;
                    case "title":
                        parName.Value = el.InnerText;   
                        break;
                    case "titleType":
                        parNameType.Value = el.InnerText;   
                        break;
                }
            }
            cmd.ExecuteNonQuery();
        }

        private void AddPerformer(SqlCommand cmd, XmlElement elArtists, int workId)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SocCisNet..spInsertWorkPerformer";
            cmd.Parameters.Clear();
            var parFstName = cmd.Parameters.AddWithValue("@FstName", "");
            var parLstName = cmd.Parameters.AddWithValue("@LstName", "");
            cmd.Parameters.AddWithValue("@WorkId"  , workId);

            foreach (XmlElement el in elArtists.ChildNodes[0].ChildNodes)
            {
                switch (el.Name)
                {
                    case "lastname":
                        parLstName.Value = el.InnerText;   
                        break;
                    case "firstname":
                        parFstName.Value = el.InnerText;   
                        break;
                }
            }
            cmd.ExecuteNonQuery();
        }

        private void AddSubmission(SqlCommand cmd, XmlElement elSubmissions, int workId)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SocCisNet..spInsertWorkSubmission";
            cmd.Parameters.Clear();
            var parSrcWorkId = cmd.Parameters.AddWithValue("@SrcWorkId", DBNull.Value);
            var parSrcSocCde = cmd.Parameters.AddWithValue("@SrcSocCde", DBNull.Value);
            var parTranCde = cmd.Parameters.AddWithValue("@TranCde", DBNull.Value);
            var parUpdatedAt = cmd.Parameters.AddWithValue("@UpdatedAt", DBNull.Value);
            cmd.Parameters.AddWithValue("@WorkId", workId);

            foreach (XmlElement el in elSubmissions.ChildNodes)
            {
                switch (el.Name)
                {
                    case "societyWorkCode":
                        parSrcWorkId.Value = int.Parse(el.InnerText);   
                        break;
                    case "societyCode":
                        parSrcSocCde.Value = int.Parse(el.InnerText);   
                        break;
                    case "lastUpdateDate":
                        parUpdatedAt.Value = DateTime.Parse(el.InnerText);   
                        break;
                    case "transactionCode":
                        parTranCde.Value = el.InnerText;   
                        break;
                }
            }
            cmd.ExecuteNonQuery();
        }

        private void AddRightHolders(SqlCommand cmd, XmlElement elShareTerritories, int workId)
        {
            foreach (XmlElement elInterestedPartyRole in elShareTerritories.GetElementsByTagName("interestedPartyRoles"))
            {
                AddRightHolder(cmd, elInterestedPartyRole, workId);
            }
        }

        private void AddRightHolder(SqlCommand cmd, XmlElement elInterestedPartyRole, int workId)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SocCisNet..spInsertWorkRightHolder";
            cmd.Parameters.Clear();
            var parSeqNr				 = cmd.Parameters.AddWithValue("@SeqNr"                 , DBNull.Value);
            var parIpBaseNr				 = cmd.Parameters.AddWithValue("@IpBaseNr"              , "");
            var parIpNameNr			     = cmd.Parameters.AddWithValue ("@IpNameNr"             , DBNull.Value);
            var parIpRole				 = cmd.Parameters.AddWithValue("@IpRole"                , DBNull.Value);
            var parFstName				 = cmd.Parameters.AddWithValue("@FstName"               , "");
            var parLstName				 = cmd.Parameters.AddWithValue("@LstName"               , "");
            var parIsLeadingPublisher	 = cmd.Parameters.AddWithValue("@IsLeadingPublisher"    , DBNull.Value);
            var parPerSocCde			 = cmd.Parameters.AddWithValue("@PerSocCde"             , DBNull.Value);
            var parPerShr				 = cmd.Parameters.AddWithValue("@PerShr"                , DBNull.Value);
            var parMecSocCde			 = cmd.Parameters.AddWithValue("@MecSocCde"             , DBNull.Value);
            var parMecShr				 = cmd.Parameters.AddWithValue("@MecShr"                , DBNull.Value);
            cmd.Parameters.AddWithValue("@WorkId", workId);

                foreach (XmlElement elInterestedPartyRolesChild in elInterestedPartyRole)
                {
                switch(elInterestedPartyRolesChild.Name)
                {
                    case "interestedParty":
                        {
                            foreach (XmlElement elInterestedParty in elInterestedPartyRolesChild)
                            {
                                switch (elInterestedParty.Name)
                                {
                                    case "firstname":
                                        parFstName.Value = elInterestedParty.InnerText;   
                                        break;
                                    case "ipBaseNumber":
                                        parIpBaseNr.Value = elInterestedParty.InnerText;   
                                        break;
                                    case "ipNameNumber":
                                        parIpNameNr.Value = int.Parse(elInterestedParty.InnerText);   
                                        break;
                                    case "lastname":
                                        parLstName.Value = elInterestedParty.InnerText;   
                                        break;
                                }
                            }

                        }
                        break;
                    case "ipRole":
                        parIpRole.Value = elInterestedPartyRolesChild.InnerText;
                        break;
                    case "ipRoleSequence":
                        parSeqNr.Value = int.Parse(elInterestedPartyRolesChild.InnerText);
                        break;
                    case "leadingPublisher":
                        parIsLeadingPublisher.Value = elInterestedPartyRolesChild.InnerText == "true" ? true : false;
                        break;
                    case "shares":
                        {
                            var rightType = elInterestedPartyRolesChild
                                .GetElementsByTagName("rightType")[0]
                                .InnerText;
                            var affiliationSociety = int.Parse(elInterestedPartyRolesChild
                                .GetElementsByTagName("affiliationSociety")[0]
                                .InnerText);
                            var share = decimal.Parse(
                                    elInterestedPartyRolesChild
                                        .GetElementsByTagName("share")[0]
                                        .InnerText
                                , new CultureInfo("en-US"));
                            if (rightType == "PER")
                            {
                                parPerSocCde.Value = affiliationSociety;
                                parPerShr.Value = share;
                            }
                            else
                            {
                                parMecSocCde.Value = affiliationSociety;
                                parMecShr.Value = share;
                            }
                        }
                        break;
                }
            }

            cmd.ExecuteNonQuery();
        }
    }
}
