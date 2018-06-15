using ipsFormsDesign.Model;
using Microsoft.Office.Interop.Word;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ipsFormsDesign.Interfaces;

namespace ipsFormsDesign.Services
{
    public class WordEngine
    {

        private static Application app;
        private Microsoft.Office.Interop.Word.Document innerDoc;
        private string tempFileName = string.Empty;
        private AnketaDictionaties _dic = null;

        public WordEngine(AnketaDictionaties dic)
        {
            app = null;
            _dic = dic;
        }

        private void clearFiles()
        {
            if (tempFileName == null) return;

                var docFile = tempFileName + ".docx";
            if (File.Exists(docFile))
                File.Delete(docFile);

            docFile = tempFileName + ".pdf";
            if (File.Exists(docFile))
                File.Delete(docFile);
        }
        ~WordEngine()
        {
            clearFiles();
        }

        public string Pdf { get { return tempFileName + ".pdf"; } }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="rightHolder"></param>
        public void processRightHolder(string pathTemplate, Customer cust, AgreementMaster agr)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            clearFiles();

            var docFile = tempFileName + ".docx";

            File.Copy(pathTemplate, docFile);
            // відкрити шаблон

            try
            {
                var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
                var regions = _dic.region.ToDictionary(rec => rec.CodeI);
                app = new Application();
                innerDoc = app.Documents.Open(docFile);
                // отримати ControlContent
                var list = innerDoc.ContentControls;

                // замінити вміст
                AgreementAddRh agrRh = agr.AgreementAddRh.Where(item => item.Version == agr.Version).SingleOrDefault();
                // Customer cust = agr.Cust;
                AnketaPerson anketaPerson = cust.Person?.AnketaPerson.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
                AnketaCompany anketaCompany = cust.Company?.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
                BankAccount bankacc = cust.BankAccount.FirstOrDefault();
             //   AnketaCompany anketaComp = cust.Company.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();

                string customerName = string.Empty;
                string leAddress = string.Empty;
                string reAddress = string.Empty;
                string faAddress = string.Empty;
                string phoneHome = string.Empty;
                string phoneWork = string.Empty;
                string phone = string.Empty;
                string eMail = string.Empty;
                DateTime? createDate = DateTime.Today;
                string Okpo = string.Empty;
                
                if( cust.CustType < 3 ) // фіз. особа
                {
                    customerName = $"{anketaPerson.LastName} {anketaPerson.FirstName} {anketaPerson.SurName ?? string.Empty}";
                    leAddress = anketaPerson.LeAddress != null ?
                        $"{countries[anketaPerson.LeCountry ?? "804"].CountryName} {anketaPerson.LeCity} {anketaPerson.LeAddress}" : leAddress;
                    reAddress = anketaPerson.ReAddress != null ?
                        $"{countries[anketaPerson.ReCountry ?? "804"].CountryName} {anketaPerson.ReCity} {anketaPerson.ReAddress}" : reAddress;
                    faAddress = anketaPerson.FaAddress != null ?
                        $"{countries[anketaPerson.FaCountry ?? "804"].CountryName} {anketaPerson.FaCity} {anketaPerson.FaAddress}" : faAddress;

                    phoneHome = anketaPerson.PhoneHome;
                    phoneWork = anketaPerson.PhoneMobileExtra;
                    phone = anketaPerson.PhoneMobileMain;
                    eMail = anketaPerson.EMail;
                    createDate = anketaPerson.BirthDate;
                    Okpo = anketaPerson.Inn;

                }
                else // юр. особа
                {
                    customerName = anketaCompany.Name;
                    leAddress = anketaCompany.LeAddress != null ?
                        $"{countries[anketaCompany.LeCountry ?? "804"].CountryName} {anketaCompany.LeCity} {anketaCompany.LeAddress}" : leAddress;
                    reAddress = anketaPerson.ReAddress != null ?
                        $"{countries[anketaCompany.JaCountry ?? "804"].CountryName} {anketaCompany.JaCity} {anketaCompany.JaAddress}" : reAddress;
                    faAddress = anketaPerson.FaAddress != null ?
                        $"{countries[anketaCompany.FaCountry ?? "804"].CountryName} {anketaCompany.FaCity} {anketaCompany.FaAddress}" : faAddress;

                    var bossEmployee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault();
                    phoneWork = bossEmployee?.Empl.PhoneNumber ?? string.Empty;
                    eMail = bossEmployee?.Empl.Email ?? string.Empty;
                    createDate = anketaCompany.RegistrDate;
                    Okpo = anketaCompany.Okpo;

                }


                foreach (ContentControl item in list)
                {
                    item.LockContentControl = false;
                    item.Temporary = true;
                    string title = item.Title.Trim();


                    switch (title)
                    {
                        case "docNumberC":
                            item.Range.Text = agr.AgrNumber;
                            break;
                        case "docDate":
                            item.Range.Text = $"{agr.AgrDate:dd.MM.yyyy}";
                            break;
                        case "docNumberYear":
                            item.Range.Text = $"{agr.AgrDate:yy}";
                            break;
                        case "docDateBegin":
                            item.Range.Text = $"{agrRh.DateBegin:dd.MM.yyyy}";
                            break;
                        case "docDateEnd":
                            item.Range.Text = $"{agrRh.DateEnd:dd.MM.yyyy}";
                            break;
                        case "СstName":
                            item.Range.Text = customerName;
                            break;
                        case "СstPerson":
                            item.Range.Text = $"{anketa.LastName} {anketa.FirstName} {anketa.SurName ?? string.Empty}";
                            break;


                        case "СstNikName":
                            item.Range.Text = $"{anketaPerson?.NikName ?? string.Empty}";
                            break;
                        case "TableKind":
                            formTermUse(item.Range.Tables, cust.RightHolder.TermsOfService);
                            break;
                        case "TableTrrUse":
                            formTableInUse(item.Range.Tables, cust.RightHolder);
                            break;
                        case "TableTrrNotUse":
                            formTableExclude(item.Range.Tables, cust.RightHolder);
                            //if (cust.RightHolder.TerritoryExclude.Count == 0)
                            //    item.Delete();
                            break;
                        case "prcntARlt":
                            item.Range.Text = $"{agrRh.RateCommiss:0}";
                            break;
                        case "prcntARltText":
                            item.Range.Text = Utils.NumPhrase(Convert.ToUInt32(agrRh.RateCommiss), true);
                            break;
                        case "prcntARltJ":
                            item.Range.Text = $"{agrRh.RateCourt:0}";
                            break;
                        case "prcntARltJText":
                            item.Range.Text = Utils.NumPhrase(Convert.ToUInt32(agrRh.RateCourt), true); ;
                            break;
                        case "СstLegalAddress":
                            item.Range.Text = reAddress;
                            break;
                        case "СstResidentialAddress":
                            item.Range.Text = faAddress;
                            break;
                        case "СstCorrespAddress":
                            item.Range.Text = leAddress;
                            break;
                        case "СstBDate":
                            item.Range.Text = createDate == null ? string.Empty : $"{createDate:dd.MM.yyyy}";
                            break;
                        case "СstINN":
                            item.Range.Text = Okpo;
                            break;
                        case "СstPasport":
                            item.Range.Text = $"{anketaPerson.PUseries} {anketaPerson.PUnumber}";
                            break;
                        case "СstPasportIssued":
                            item.Range.Text = $"{anketaPerson.PUissuedWho} {anketaPerson.PUissuedWhen:dd.MM.yyyy}";
                            break;
                        case "СstBankName":
                            item.Range.Text = $"{bankacc?.MfoName ?? string.Empty}";
                            break;
                        case "СstBankMFO":
                            item.Range.Text = $"{bankacc?.Mfo.ToString() ?? string.Empty}";
                            break;
                        case "СstBankEDRPOU":
                            item.Range.Text = $"{bankacc?.MfoOkpo ?? string.Empty}";
                            break;
                        case "СstBankAcc":
                            item.Range.Text = $"{bankacc?.TransitNumber ?? string.Empty}";
                            break;
                        case "СstAcc":
                            item.Range.Text = $"{bankacc?.AccountNumber ?? string.Empty}";
                            break;
                        case "СstPhoneHome":
                            item.Range.Text = phoneHome;
                            break;
                        case "СstPhone":
                            item.Range.Text = phone;
                            break;
                        case "СstPhoneWork":
                            item.Range.Text = phoneWork;
                            break;
                        case "СstEmail":
                            item.Range.Text = eMail;
                            break;
                        default:
                            item.Delete();
                            break;

                    }

                } // for each
                innerDoc.Save();
                innerDoc.SaveAs2(tempFileName + ".pdf", WdSaveFormat.wdFormatPDF);
                innerDoc.Close();
            }
            finally
            {
                if (app != null)
                    app.Quit();
                app = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="Consumer"></param>
        public void processConsumer(string pathTemplate, Customer cust, AgreementMaster agr)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var docFile = tempFileName + ".docx";

            if (File.Exists(docFile))
                File.Delete(docFile);

            File.Copy(pathTemplate, docFile);
            // відкрити шаблон

            try
            {
                app = new Application();
                innerDoc = app.Documents.Open(docFile);
                // отримати ControlContent
                var list = innerDoc.ContentControls;

                // замінити вміст
                AgreementAddRh agrRh = agr.AgreementAddRh.Where(item => item.Version == agr.Version).SingleOrDefault();
                // Customer cust = agr.Cust;
       //         AnketaPerson anketa = cust.Person.AnketaPerson.Where(rec => rec.Version == cust.AnkVersion).First();  
                BankAccount bankacc = cust.BankAccount.FirstOrDefault();
                   AnketaCompany anketaComp = cust.Company.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
                Employee Employee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault()?.Empl;

                foreach (ContentControl item in list)
                {
                    item.LockContentControl = false;
                    item.Temporary = true;
                    string title = item.Title.Trim();
                    switch (title)
                    {
                        case "docNumberC":
                            item.Range.Text = agr.AgrNumber;
                            break;
                        case "docNumberYear":
                            item.Range.Text = $"{agr.AgrDate:yy}";
                            break;
                        case "docDateBegin":
                            item.Range.Text = $"{agr.AgrDate:dd.MM.yyyy}";
                            break;
                        case "СstName":
                            item.Range.Text = $"{anketaComp.Name} ";
                            break;
 /*                      case "СstPerson":
                            item.Range.Text = $"{anketaComp.C} {anketa.FirstName} {anketa.SurName ?? string.Empty}";
                            break;


                        case "СstNikName":
                            item.Range.Text = $"{anketa.NikName ?? string.Empty}";
                            break;
   */                     case "TableKind":
                            formTermUse(item.Range.Tables, cust.RightHolder.TermsOfService);
                            break;
                        case "TableTrrUse":
                            formTableInUse(item.Range.Tables, cust.RightHolder);
                            break;
                        case "TableTrrNotUse":
                            formTableExclude(item.Range.Tables, cust.RightHolder);
                            break;
                        case "prcntARlt":
                            item.Range.Text = $"{agrRh.RateCommiss:0}";
                            break;
                        case "prcntARltText":
                            item.Range.Text = Utils.NumPhrase(Convert.ToUInt32(agrRh.RateCommiss), true);
                            break;
                        case "prcntARltJ":
                            item.Range.Text = $"{agrRh.RateCourt:0}";
                            break;
                        case "prcntARltJText":
                            item.Range.Text = Utils.NumPhrase(Convert.ToUInt32(agrRh.RateCourt), true); ;
                            break;
 /*                       case "СstLegalAddress":
                            item.Range.Text = anketa.LeAddress;
                            break;
                        case "СstResidentialAddress":
                            item.Range.Text = anketa.ReAddress;
                            break;
                        case "СstBDate":
                            item.Range.Text = $"{anketa.BirthDate:dd.MM.yyyy}";
                            break;
                        case "СstINN":
                            item.Range.Text = anketa.Inn;
                            break;
                        case "СstPasport":
                            item.Range.Text = $"{anketa.PUseries} {anketa.PUnumber}";
                            break;
                        case "СstPasportIssued":
                            item.Range.Text = $"{anketa.PUissuedWho} {anketa.PUissuedWhen:dd.MM.yyyy}";
                            break;
 */                       case "СstBankName":
                            item.Range.Text = $"{bankacc?.MfoName ?? string.Empty}";
                            break;
                        case "СstBankMFO":
                            item.Range.Text = $"{bankacc?.Mfo.ToString() ?? string.Empty}";
                            break;
                        case "СstBankEDRPOU":
                            item.Range.Text = $"{bankacc?.MfoOkpo ?? string.Empty}";
                            break;
                        case "СstBankAcc":
                            item.Range.Text = $"{bankacc?.TransitNumber ?? string.Empty}";
                            break;
                        case "СstAcc":
                            item.Range.Text = $"{bankacc?.AccountNumber ?? string.Empty}";
                            break;
  /*                      case "СstPhoneHome":
                            item.Range.Text = $"{anketa.PhoneHome}";
                            break;
                        case "СstPhone":
                            item.Range.Text = $"{anketa.PhoneMobileMain}";
                            break;
                        case "СstPhoneWork":
                            item.Range.Text = $"{anketa.PhoneMobileExtra}";
                            break;
                        case "СstEmail":
                            item.Range.Text = $"{anketa.EMail}";
                            break;
*/                        default:
                            item.Delete();
                            break;

                    }

                } // for each
                innerDoc.Save();
                innerDoc.SaveAs2(tempFileName + ".pdf", WdSaveFormat.wdFormatPDF);
                innerDoc.Close();
            }
            finally
            {
                if (app != null)
                    app.Quit();
                app = null;
            }
        }


        private void formTableExclude(Tables tables, RightHolder rightHolder)
        {
            if (tables.Count == 0) return;
            Table table = tables[1];
            if(table.Rows.Count > 0)
            table.Rows.Delete();
            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            foreach (var item in rightHolder.TerritoryExclude)
            {
                curRow = curRow == null ? table.Rows[1] : table.Rows.Add();
                curRow.Cells[1].Range.Text = countries[item.CountryCode].CountryName;
            }
        }

        private void formTableInUse(Tables tables, RightHolder rightHolder)
        {
            if (tables.Count == 0) return;
            Table table = tables[1];

            var list = rightHolder.TerritoryInclude;

            if (list.Count == 0)
            {
                table.Rows.Delete();
                return;
            }

            for (int i = table.Rows.Count; i > 2; i--)
                table.Rows[i].Delete();

            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);

            Row curRow = null;
            if (rightHolder.AroundWord == true)
            {
                curRow = curRow == null ? table.Rows[1] : table.Rows.Add();
                curRow.Cells[1].Range.Text = "Всіх країн світу";
            }
            else
                foreach (var item in rightHolder.TerritoryInclude)
                {

                    curRow = curRow == null ? table.Rows[1] : table.Rows.Add();
                    curRow.Cells[1].Range.Text = countries[item.CountryCode].CountryName;
                }
        }

        private void formTermUse(Tables tables, ICollection<TermsOfService> termsOfServices)
        {
            if (tables.Count == 0) return;
            Table table = tables[1];
            Dictionary<int, List<TermsOfService>> body = new Dictionary<int, List<TermsOfService>>();
            Dictionary<int, string> group = new Dictionary<int, string>();



            foreach (var item in termsOfServices)
            {
                int groupId = item.CrkindCodeNavigation.CrGroupCodeNavigation.CodeI;
                if (!group.Keys.Contains(groupId))
                {
                    group.Add(groupId, item.CrkindCodeNavigation.CrGroupCodeNavigation.Name);
                    body.Add(groupId, new List<TermsOfService>());
                }
                body[groupId].Add(item);
            }

            foreach (var groupId in group.Keys)
            {
                var groupName = group[groupId];
                var curRow = table.Rows.Add();
                Range cellRng = curRow.Cells[1].Range;

                cellRng.Text = groupName;
                //cellRng.Bold = 1;
                //cellRng.Font.Size = cellRng.Font.Size + 1;
                //cellRng.
                var listTerm = body[groupId];
                foreach (var item in listTerm)
                {
                    curRow = table.Rows.Add();
                    curRow.Cells[1].Range.Text = item.CrkindCodeNavigation.Name;
                    curRow.Cells[2].Range.Text = item.OurService == true ? "Tak" : "Ні";
                }
            }
        }

        // зберігти


    }
}

