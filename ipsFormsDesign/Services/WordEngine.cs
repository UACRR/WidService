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

                if (cust.CustType < 3) // фіз. особа
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
                    reAddress = anketaCompany.JaAddress != null ?
                        $"{countries[anketaCompany.JaCountry ?? "804"].CountryName} {anketaCompany.JaCity} {anketaCompany.JaAddress}" : reAddress;
                    faAddress = anketaCompany.FaAddress != null ?
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
                        case "docNumberR":
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
                            // item.Range.Text = $"{anketa.LastName} {anketa.FirstName} {anketa.SurName ?? string.Empty}";
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
        public void processConsumer(string pathTemplate, Customer cust, AgreementMaster agr, LicenseAgreement lic)
        {
            processConsumer(pathTemplate, cust, lic, lic.LicVersion ?? 1);
        }

        /// <summary>
        /// Друк доп угоди по ліцензійному договору
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="Consumer"></param>
        public void processConsumer(string pathTemplate, Customer cust, LicenseAgreement agr, int version)
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
                var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
                var regions = _dic.region.ToDictionary(rec => rec.CodeI);
                var period = _dic.period.ToDictionary(rec => rec.CodeI);
                var typeVAT = _dic.typeVat.ToDictionary(rec => rec.CodeI);
                    app = new Application();
                innerDoc = app.Documents.Open(docFile);
                // отримати ControlContent
                var list = innerDoc.ContentControls;

                // замінити вміст
                //AgreementAddRh agrRh = agr.AgreementAddRh.Where(item => item.Version == agr.Version).SingleOrDefault();
                // Customer cust = agr.Cust;
                LicenseAgreement licAgr = agr;
                LicenseAgrParam licenseAgrParam = licAgr?.LicenseAgrParam.Where(rec => rec.LicVersion == version).SingleOrDefault();

                PaidPeriod paidPeriod = licAgr?.PaidPeriod.FirstOrDefault();

                AnketaPerson anketaPerson = cust.Person?.AnketaPerson.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
                AnketaCompany anketaCompany = cust.Company?.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
                BankAccount bankacc = cust.BankAccount.FirstOrDefault();
                Employee Employee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault()?.Empl;
                Employee EmployeeCont = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 3).SingleOrDefault()?.Empl;


                var clnBusinessPlaceHotel = cust.Client.ClnBusinessPlace.Where(rec => (rec.PlCode == 1) || (rec.PlCode == 2)).ToList();
                var clnBusinessPlaceMarket = cust.Client.ClnBusinessPlace.Where(rec => rec.PlCode == 8).ToList();              
                var clnBusinessPlaceBar = cust.Client.ClnBusinessPlace.Where(rec => (rec.PlCode == 3) || (rec.PlCode == 4)
                 || (rec.PlCode == 5)).ToList();

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
                string СstPersonReason = string.Empty;
                string DocDate = string.Empty;
                string DocDateEnd = string.Empty;
                string LicNum = string.Empty;
                string prcntInc = string.Empty;
                string minRltGrn = string.Empty;
                string minRltKop = string.Empty;
                string pay_period = string.Empty;
                string pay_period2 = string.Empty;
                string prcntPrl = string.Empty;
                string registerDate = string.Empty;
                string registerNumber = string.Empty;
                string numberVAT = string.Empty;
                string typeVat = string.Empty;
                string cstPerson = string.Empty;
                string cstContPerson = string.Empty;
                string cstContPersonPhone = string.Empty;
                string СPaidPeriod = string.Empty;
                string CPaidData = string.Empty;
                string fop = String.Empty;
                string vOsobi = String.Empty;
                string naPidstavi = String.Empty;

                if (cust.CustType < 3) // фіз. особа
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
                    cstPerson = customerName;
                    cstContPerson = customerName;
                    cstContPersonPhone = phoneWork;
                    if (cust.CustType == 2)
                    {
                        fop = " Фізична особа - підприємець ";
                    }
                }
                else // юр. особа
                {
                    customerName = anketaCompany.Name;
                    leAddress = anketaCompany.LeAddress != null ?
                        $"{countries[anketaCompany.LeCountry ?? "804"].CountryName} {anketaCompany.LeCity} {anketaCompany.LeAddress}" : leAddress;
                    reAddress = anketaCompany.JaAddress != null ?
                        $"{countries[anketaCompany.JaCountry ?? "804"].CountryName} {anketaCompany.JaCity} {anketaCompany.JaAddress}" : reAddress;
                    faAddress = anketaCompany.FaAddress != null ?
                        $"{countries[anketaCompany.FaCountry ?? "804"].CountryName} {anketaCompany.FaCity} {anketaCompany.FaAddress}" : faAddress;


                    var bossEmployee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault();
                    phoneWork = bossEmployee?.Empl.PhoneNumber ?? string.Empty;
                    eMail = bossEmployee?.Empl.Email ?? string.Empty;
                    createDate = anketaCompany.RegistrDate;
                    Okpo = anketaCompany.Okpo;
                    СstPersonReason = bossEmployee?.RelDocument;
                    cstPerson = $"{Employee?.LastName} {Employee?.FirstName} {Employee?.SurName ?? string.Empty}";
                    cstContPerson = $"{EmployeeCont?.LastName ?? string.Empty} {EmployeeCont?.FirstName ?? string.Empty} {EmployeeCont?.SurName ?? string.Empty}";
                    cstContPersonPhone = $"{EmployeeCont?.PhoneNumber ?? string.Empty}";
                    vOsobi = " в особі ";
                    naPidstavi = " = що діє на підставі ";
                }

 
                DocDate = $"{licAgr?.LicDate:dd.mm.yyyy}";
                LicNum = licAgr?.LicNum;
                prcntInc = licenseAgrParam?.RateAmount.ToString();
                minRltGrn = licenseAgrParam?.MinAmount.ToString();
                minRltKop = ((int)((licenseAgrParam?.MinAmount ?? 0 - (int)(licenseAgrParam?.MinAmount ?? 0)) * 100)).ToString();
                pay_period = $"{period[licenseAgrParam?.PeriodCode ?? 1].Name}";
                pay_period2 = $"{period[licenseAgrParam?.PeriodCode ?? 1].NameR}";
                DocDateEnd = $"{licenseAgrParam?.DateEnd:dd.MM.yyyy}";
                prcntPrl = licenseAgrParam?.AddRate?.ToString();
                registerDate = $"{anketaCompany?.RegistrDate:dd.MM.yyyy}";
                registerNumber = anketaCompany?.RegistrNumber?.ToString();
                numberVAT = anketaCompany?.NumberVat.ToString();
                typeVat = $"{typeVAT[anketaCompany?.TypeVat ?? 2].Name}";


                foreach (ContentControl item in list)
                {
                    item.LockContentControl = false;
                    item.Temporary = true;
                    string title = item.Title.Trim();

                    switch (title)

                    {

                        case "docNumberC":
                            item.Range.Text = LicNum;
                            break;
                        case "docDate":
                            item.Range.Text = DocDate;
                            break;
                        case "docNumberYear":
                            item.Range.Text = $"{licAgr.LicDate:yy}";
                            break;
                        case "docDateBegin":
                            item.Range.Text = $"{licenseAgrParam?.DateBegin:dd.MM.yyyy}";
                            break;


                        case "fop":
                            item.Range.Text = fop;
                            break;
                        case "vOsobi":
                            item.Range.Text = vOsobi;
                            break;
                        case "naPidstavi":
                            item.Range.Text = naPidstavi;
                            break;




                        case "СstName":
                            item.Range.Text = customerName;
                            break;


                        case "CstPerson":
                            item.Range.Text = cstPerson;
                            break;
                        case "CstPersonReason":
                            item.Range.Text = СstPersonReason;
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
                        case "TablePLh":
                            formTableBuisnessPlases(item.Range.Tables, clnBusinessPlaceHotel);
                            break;
                        case "TablePLsm":
                            formTableMarketPlases(item.Range.Tables, clnBusinessPlaceMarket);
                            break;
                        case "TablePLfe":
                            formTableBarPlases(item.Range.Tables, clnBusinessPlaceBar);
                            break;
                        case "prcntInc":
                            item.Range.Text = prcntInc;
                            break;
                        case "prcntIncText":
                            item.Range.Text = Utils.NumPhraseL(Convert.ToUInt32(licenseAgrParam.RateAmount), true);
                            break;
                        case "minRltGrn":
                            item.Range.Text = minRltGrn;
                            break;
                        case "minRltGrnText":
                            item.Range.Text = Utils.NumPhraseL(Convert.ToUInt32(licenseAgrParam.MinAmount), true); ;
                            break;
                        case "minRltKop":
                            item.Range.Text = minRltKop;
                            break;
                        case "rltPayPeriod":
                            item.Range.Text = pay_period;
                            break;
                        case "rltPayPeriod2":
                            item.Range.Text = pay_period2;
                            break;
                        case "docDateEnd":
                            item.Range.Text = DocDateEnd;
                            break;
                        case "prcntPrl":
                            item.Range.Text = prcntPrl;
                            break;
                        case "prcntPrlText":
                            item.Range.Text = Utils.NumPhraseL(Convert.ToUInt32(licenseAgrParam.AddRate), true);
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

                        case "СstEDRPOU":
                            item.Range.Text = Okpo;
                            break;
                        case "СstBankName":
                            item.Range.Text = $"{bankacc?.MfoName ?? string.Empty}";
                            break;
                        case "СstBankMFO":
                            item.Range.Text = $"{bankacc?.Mfo.ToString() ?? string.Empty}";
                            break;
                        case "СstAcc":
                            item.Range.Text = $"{bankacc?.AccountNumber ?? string.Empty}";
                            break;
                        case "СstRegNumber":
                            item.Range.Text = registerNumber;
                            break;
                        case "СstRegData":
                            item.Range.Text = registerDate;
                            break;
                        case "СstVAT":
                            item.Range.Text = numberVAT;
                            break;
                        case "СstVATType":
                            item.Range.Text = typeVat;
                            break;

                        case "СstContPerson":
                            item.Range.Text = cstContPerson;
                            break;

                        case "СstContPersonPhone":
                            item.Range.Text = cstContPersonPhone;
                            break;

                        case "СPaidPeriod":
                            item.Range.Text = СPaidPeriod;
                            break;

                        case "СPaidData":
                            item.Range.Text = CPaidData;
                            break;



                        case "СstPasport":
                            item.Range.Text = $"{anketaPerson.PUseries} {anketaPerson.PUnumber}";
                            break;
                        case "СstPasportIssued":
                            item.Range.Text = $"{anketaPerson.PUissuedWho} {anketaPerson.PUissuedWhen:dd.MM.yyyy}";
                            break;
                        case "СstBankEDRPOU":
                            item.Range.Text = $"{bankacc?.MfoOkpo ?? string.Empty}";
                            break;
                        case "СstBankAcc":
                            item.Range.Text = $"{bankacc?.TransitNumber ?? string.Empty}";
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

        public void processConsumerBR(string pathTemplate, Customer cust, AgreementMaster agr)
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
                var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
                var regions = _dic.region.ToDictionary(rec => rec.CodeI);
                var period = _dic.period.ToDictionary(rec => rec.CodeI);
                var typeVAT = _dic.typeVat.ToDictionary(rec => rec.CodeI);
                app = new Application();
                innerDoc = app.Documents.Open(docFile);
                // отримати ControlContent
                var list = innerDoc.ContentControls;

                // замінити вміст
 
                AnketaPerson anketaPerson = cust.Person?.AnketaPerson.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
                AnketaCompany anketaCompany = cust.Company?.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
                BankAccount bankacc = cust.BankAccount.FirstOrDefault();
                Employee Employee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault()?.Empl;
                Employee EmployeeCont = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 3).SingleOrDefault()?.Empl;
                var clnBusinessPlaceTheater = cust.Client.ClnBusinessPlace.Where(rec => rec.PlCode == 6).ToList();
                AgreementAddBr agreementAddBr;
                agreementAddBr = agr.AgreementAddBr?.Where(rec => rec.IsCurrent == 1)?.SingleOrDefault();

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
                string СstPersonReason = string.Empty;
                string registerDate = string.Empty;
                string registerNumber = string.Empty;
                string numberVAT = string.Empty;
                string typeVat = string.Empty;
                string cstPerson = string.Empty;
                string cstContPerson = string.Empty;
                string cstContPersonPhone = string.Empty;
                string fop = String.Empty;
                string vOsobi = String.Empty;
                string naPidstavi = String.Empty;
                string GdocNumber = String.Empty;
                string GdocDateC = String.Empty;
                string GdocDateBeginC = String.Empty;
                string GdocDateEndC = String.Empty;

                if (cust.CustType < 3) // фіз. особа
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
                    cstPerson = customerName;
                    cstContPerson = customerName;
                    cstContPersonPhone = phoneWork;
                    if (cust.CustType == 2)
                    {
                        fop = " Фізична особа - підприємець ";
                    }
                }
                else // юр. особа
                {
                    customerName = anketaCompany.Name;
                    leAddress = anketaCompany.LeAddress != null ?
                        $"{countries[anketaCompany.LeCountry ?? "804"].CountryName} {anketaCompany.LeCity} {anketaCompany.LeAddress}" : leAddress;
                    reAddress = anketaCompany.JaAddress != null ?
                        $"{countries[anketaCompany.JaCountry ?? "804"].CountryName} {anketaCompany.JaCity} {anketaCompany.JaAddress}" : reAddress;
                    faAddress = anketaCompany.FaAddress != null ?
                        $"{countries[anketaCompany.FaCountry ?? "804"].CountryName} {anketaCompany.FaCity} {anketaCompany.FaAddress}" : faAddress;


                    var bossEmployee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault();
                    phoneWork = bossEmployee?.Empl.PhoneNumber ?? string.Empty;
                    eMail = bossEmployee?.Empl.Email ?? string.Empty;
                    createDate = anketaCompany.RegistrDate;
                    Okpo = anketaCompany.Okpo;
                    СstPersonReason = bossEmployee?.RelDocument;
                    cstPerson = $"{Employee?.LastName} {Employee?.FirstName} {Employee?.SurName ?? string.Empty}";
                    cstContPerson = $"{EmployeeCont?.LastName ?? string.Empty} {EmployeeCont?.FirstName ?? string.Empty} {EmployeeCont?.SurName ?? string.Empty}";
                    cstContPersonPhone = $"{EmployeeCont?.PhoneNumber ?? string.Empty}";
                    vOsobi = " в особі ";
                    naPidstavi = "  що діє на підставі ";
                }

                GdocDateC = $"{agreementAddBr?.AddDate:dd.MM.yyyy}";
                GdocDateBeginC = $"{agreementAddBr?.DateBegin:dd.MM.yyyy}";
                GdocDateEndC = $"{agreementAddBr?.DateEnd:dd.MM.yyyy}";
                GdocNumber = agreementAddBr?.AddNumber?.ToString() ?? agr.AgrNumber?.ToString();

                registerDate = $"{anketaCompany?.RegistrDate:dd.MM.yyyy}";
                registerNumber = anketaCompany?.RegistrNumber?.ToString();
                numberVAT = anketaCompany?.NumberVat.ToString();
                typeVat = $"{typeVAT[anketaCompany?.TypeVat ?? 2].Name}";


                foreach (ContentControl item in list)
                {
                    item.LockContentControl = false;
                    item.Temporary = true;
                    string title = item.Title.Trim();

                    switch (title)

                    {
                        case "GdocNumberC":
                            item.Range.Text = GdocNumber;
                            break;
                        case "GdocDateC":
                            item.Range.Text = GdocDateC;
                            break;
                        case "fop":
                            item.Range.Text = fop;
                            break;
                        case "СstName":
                            item.Range.Text = customerName;
                            break;
                        case "vOsobi":
                            item.Range.Text = vOsobi;
                            break;
                        case "CstPerson":
                            item.Range.Text = cstPerson;
                            break;
                        case "naPidstavi":
                            item.Range.Text = naPidstavi;
                            break;
                        case "CstPersonReason":
                            item.Range.Text = СstPersonReason;
                            break;
                        case "TablePLk":
                            formTableTheaterPlases(item.Range.Tables, clnBusinessPlaceTheater);
                            break;
                        case "GdocDateBeginC":
                            item.Range.Text = GdocDateBeginC;
                            break;
                        case "GdocDateEndC":
                            item.Range.Text = GdocDateEndC;
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
                        case "СstPhone":
                            item.Range.Text = phone;
                            break;
                        case "CstEDRPOU":
                            item.Range.Text = Okpo;
                            break;
                        case "СstBankName":
                            item.Range.Text = $"{bankacc?.MfoName ?? string.Empty}";
                            break;
                        case "СstBankMFO":
                            item.Range.Text = $"{bankacc?.Mfo.ToString() ?? string.Empty}";
                            break;
                        case "СstAcc":
                            item.Range.Text = $"{bankacc?.AccountNumber ?? string.Empty}";
                            break;
                        case "СstRegNumber":
                            item.Range.Text = registerNumber;
                            break;
                        case "СstRegData":
                            item.Range.Text = registerDate;
                            break;
                        case "СstVAT":
                            item.Range.Text = numberVAT;
                            break;
                        case "СstVATType":
                            item.Range.Text = typeVat;
                            break;
                        case "СstEmail":
                            item.Range.Text = eMail;
                            break;
                        case "СstContPerson":
                            item.Range.Text = cstContPerson;
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
        /// <param name="cust"></param>
        /// <param name="licAgr"></param>
        /// <param name="period"></param>
        public void processAction(string pathTemplate, Customer cust, LicenseAgreement licAgr, PaidPeriod period)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var docFile = tempFileName + ".docx";

            if (File.Exists(docFile))
                File.Delete(docFile);

            File.Copy(pathTemplate, docFile);
            // відкрити шаблон
            AnketaCompany anketaCompany = cust.Company?.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
            BankAccount bankacc = cust.BankAccount.FirstOrDefault();
            Employee Employee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault()?.Empl;
            Employee EmployeeBooker = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 2).SingleOrDefault()?.Empl;
            try
            {
                var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
                var regions = _dic.region.ToDictionary(rec => rec.CodeI);
                var typeVAT = _dic.typeVat.ToDictionary(rec => rec.CodeI);
                var bossEmployee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault();


                app = new Application();
                innerDoc = app.Documents.Open(docFile);
                // отримати ControlContent
                var list = innerDoc.ContentControls;

                string LicNum = licAgr.LicNum;
                string CPaidPeriod = string.Empty;
                string CPaidData = string.Empty;
                string DocDate = string.Empty;
                string customerName = string.Empty;
                string CstPerson = string.Empty;
                string CstPersonReason = string.Empty;
                string CstCorrespAddress = string.Empty;
                string phoneHome = string.Empty;
                string phoneWork = string.Empty;
                string phone = string.Empty;
                string eMail = string.Empty;
                string CstBooker = string.Empty;
                string CPaidAmountGrn = string.Empty;
                string CPaidAmountGrnText = string.Empty;
                string CPaidAmountKop = string.Empty;
                string CPaidAmountKopText = string.Empty;
                string CstEDRPOU = anketaCompany.Okpo;

                LicNum = licAgr.LicNum;
                DocDate = $"{licAgr.LicDate:dd.MM.yyyy}";
                CPaidPeriod = period.PeriodName;
                CPaidData = $"{ DateTime.Today:dd.MM.yyyy}";
                customerName = anketaCompany.Name;
                CstPersonReason = bossEmployee?.RelDocument;
                CstPerson = $"{Employee.LastName} {Employee.FirstName} {Employee.SurName ?? string.Empty}";
                CstBooker = $"{EmployeeBooker.LastName} {EmployeeBooker.FirstName} {EmployeeBooker.SurName ?? string.Empty}";
                CPaidAmountGrn = period.Amount.ToString();
                CPaidAmountGrnText = Utils.NumPhraseL(Convert.ToUInt32(period.Amount), false);
                CPaidAmountKop = ((int)((period.Amount - (int)period.Amount) * 100)).ToString();
                CPaidAmountKopText = Utils.NumPhraseL(Convert.ToUInt32(((int)((period.Amount - (int)period.Amount) * 100))), false);
                CstCorrespAddress = anketaCompany.LeAddress != null ?
                    $"{countries[anketaCompany.LeCountry ?? "804"].CountryName} {anketaCompany.LeCity} {anketaCompany.LeAddress}" : CstCorrespAddress;


                foreach (ContentControl item in list)
                {
                    item.LockContentControl = false;
                    item.Temporary = true;
                    string title = item.Title.Trim();
                    switch (title)
                    {
                        case "docNumberC":
                            item.Range.Text = LicNum;
                            break;
                        case "docDate":
                            item.Range.Text = DocDate;
                            break;
                        case "CPaidPeriod":
                            item.Range.Text = CPaidPeriod;
                            break;
                        case "CPaidData":
                            item.Range.Text = CPaidData;
                            break;
                        case "CstName":
                            item.Range.Text = customerName;
                            break;
                        case "CstPerson":
                            item.Range.Text = CstPerson;
                            break;
                        case "CstPersonReason":
                            item.Range.Text = CstPersonReason;
                            break;
                        case "CstBooker":
                            item.Range.Text = CstBooker;
                            break;
                        case "CPaidAmountGrn":
                            item.Range.Text = CPaidAmountGrn;
                            break;
                        case "CPaidAmountGrnText":
                            item.Range.Text = CPaidAmountGrnText;
                            break;
                        case "CPaidAmountKop":
                            item.Range.Text = CPaidAmountKop;
                            break;
                        case "CPaidAmountKopText":
                            item.Range.Text = CPaidAmountKopText;
                            break;
                        case "CstEDRPOU":
                            item.Range.Text = CstEDRPOU;
                            break;
                        case "CstCorrespAddress":
                            item.Range.Text = CstCorrespAddress;
                            break;


                    } // for each
                }
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


        private void formTableBuisnessPlases(Tables tables, ICollection<ClnBusinessPlace> BuisnessPlace)
        {
            ClnBusinessPlace places;
            if (tables.Count == 0) return;
            Table table = tables[1];
            //    var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            Row curRow = null;
            int index = 1;
            foreach (var item in BuisnessPlace)
            {
                places = item;

                curRow = table.Rows.Add();
                curRow.Cells[1].Range.Text = index.ToString();
                index++;

                curRow.Cells[2].Range.Text = places.PlaceName + "," + places.PlaceCity + "," + places.PlaceAddress;
                foreach (var place in item.ClnPlaceHoll)
                {
                    curRow = table.Rows.Add();
                    curRow.Cells[3].Range.Text = place.HollName;
                    curRow.Cells[4].Range.Text = place.SqHoll.ToString();
                    curRow.Cells[5].Range.Text = place.HollNum.ToString();
                }
            }
        }

        private void formTableMarketPlases(Tables tables, ICollection<ClnBusinessPlace> BuisnessPlace)
        {
            ClnBusinessPlace places;
            if (tables.Count == 0) return;
            Table table = tables[1];
            //    var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            Row curRow = null;
            int index = 1;
            foreach (var item in BuisnessPlace)
            {
                places = item;
                curRow = table.Rows.Add();
                index++;
                var place = item.ClnPlaceHoll.FirstOrDefault();
                curRow.Cells[1].Range.Text = index.ToString();
                curRow.Cells[2].Range.Text = places.PlaceCity + "," + places.PlaceAddress;
                curRow.Cells[3].Range.Text = places.PlaceName;
                curRow.Cells[4].Range.Text = place.SqHoll.ToString();

            }
        }

        private void formTableTheaterPlases(Tables tables, ICollection<ClnBusinessPlace> BuisnessPlace)
        {
            ClnBusinessPlace places;
            if (tables.Count == 0) return;
            Table table = tables[1];
            //    var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            Row curRow = null;
            int index = 1;
            foreach (var item in BuisnessPlace)
            {
                places = item;

                curRow = table.Rows.Add();
                curRow.Cells[1].Range.Text = index.ToString();
                index++;

                curRow.Cells[2].Range.Text = places.PlaceName;
                curRow.Cells[5].Range.Text = places.PlaceCity + "," + places.PlaceAddress;
                foreach (var place in item.ClnPlaceHoll)
                {
                    curRow = table.Rows.Add();
                    curRow.Cells[3].Range.Text = place.HollName;
                    curRow.Cells[4].Range.Text = place.HollNum.ToString();
                }
            }
        }

        private void formTableBarPlases(Tables tables, ICollection<ClnBusinessPlace> BuisnessPlace)
        {
            ClnBusinessPlace places;
            if (tables.Count == 0) return;
            Table table = tables[1];
            //    var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            Row curRow = null;
            int index = 1;
            foreach (var item in BuisnessPlace)
            {
                places = item;
                curRow = table.Rows.Add();
                index++;
                var place = item.ClnPlaceHoll.FirstOrDefault();
                curRow.Cells[1].Range.Text = index.ToString();
                curRow.Cells[2].Range.Text = places.PlaceCity + "," + places.PlaceAddress;
                curRow.Cells[3].Range.Text = places.PlaceName;


            }
        }


        private void formTableExclude(Tables tables, RightHolder rightHolder)
        {
            if (tables.Count == 0) return;
            Table table = tables[1];
            if (table.Rows.Count > 0)
                table.Rows.Delete();
            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            Row curRow = null;
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

