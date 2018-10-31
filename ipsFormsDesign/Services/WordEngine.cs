using ipsFormsDesign.Model;
using Microsoft.Office.Interop.Word;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Dictionary;
using System.Runtime.InteropServices;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.Fixations;

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

        // Запуск Word
        internal Application StartWordApp()
        {
            if (app == null)
                app = new Application();

            return app;
        }

        /// <summary>
        /// Видалення тимчасових файлів
        /// </summary>
        private void ClearFiles()
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
            ClearFiles();
            if (app != null)
            {
                app.Quit();
                Marshal.ReleaseComObject(app);
                app = null;
            }
        }

        public string Pdf { get { return tempFileName + ".pdf"; } }
        public string Docx { get { return tempFileName + ".docx"; } }

        /// <summary>
        /// Формування Генерального договору з Правовласником 
        /// </summary>
        /// <param name="streamTemplate"></param>
        /// <param name="cust"></param>
        /// <param name="agr"></param>
        public async System.Threading.Tasks.Task ProcessRightHolder(Stream streamTemplate, Customer cust, AgreementMaster agr)
        {
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            ClearFiles();

            var docFile = tempFileName + ".docx";
            using (var docStream = new FileStream(docFile, FileMode.CreateNew))
            {
                streamTemplate.CopyTo(docStream);
            }

            await System.Threading.Tasks.Task.Run(() => innerProcesRightHolder(cust, agr));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="rightHolder"></param>
        public void processRightHolder(string pathTemplate, Customer cust, AgreementMaster agr)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            ClearFiles();

            var docFile = tempFileName + ".docx";

            File.Copy(pathTemplate, docFile);
            // відкрити шаблон

            innerProcesRightHolder(cust, agr);
        }
        /// <summary>
        /// Формування документу (внутріній метод)
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="agr"></param>
        private void innerProcesRightHolder(Customer cust, AgreementMaster agr)
        {


            var docFile = tempFileName + ".docx";


            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            var regions = _dic.region.ToDictionary(rec => rec.CodeI);
            app = StartWordApp();
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
            RightHolder rightHolder = cust.RightHolder;

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
            string СstRegNumber = string.Empty;
            string CstRegData = string.Empty;
            string CstVAT = string.Empty;
            string CstVATType = string.Empty;

            string fop = string.Empty;
            string CstName = string.Empty;
            string vOsobi = string.Empty;
            string CstPerson = string.Empty;
            string naPidstavi = string.Empty;
            string CstPersonReason = string.Empty;

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
                СstRegNumber = $"{anketaPerson.BuisNumberRegistration}";
                CstRegData = $"{anketaPerson.BuisDateRegistration:dd.MM.yyyy}";
                CstVAT = $"{anketaPerson.BuisNumberPayer}";
                CstVATType = "є платником";
                if ( $"{anketaPerson.TypeVat}".ToString() == "2")
                    CstVATType = "не є платником";
                if (cust.CustType == 2)
                    fop = "Фізична особа-підприємець ";
                vOsobi = " в особі ";
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
                СstRegNumber = $"{anketaCompany.RegistrNumber}";

                var bossEmployee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault();
                phoneWork = bossEmployee?.Empl.PhoneNumber ?? string.Empty;
                eMail = bossEmployee?.Empl.Email ?? string.Empty;
                createDate = anketaCompany.RegistrDate;
                Okpo = anketaCompany.Okpo;
                CstRegData = $"{anketaCompany.RegistrDate:dd.MM.yyyy}";
                CstVAT = $"{anketaCompany.NumberVat}";
                CstVATType = "є платником";
                if ($"{anketaCompany.TypeVat}".ToString() == "2")
                    CstVATType = "не є платником";

                Employee Employee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault()?.Empl;
                Employee EmployeeCont = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 3).SingleOrDefault()?.Empl;

                CstPerson = $"{Employee?.LastName} {Employee?.FirstName} {Employee?.SurName ?? string.Empty}";
                naPidstavi = " ,що діє на підставі";
                CstPersonReason = bossEmployee?.RelDocument;


            }

   
            string prcntARlt = string.Empty;
            string prcntARltText = string.Empty;

          
            decimal RateComiiss = Convert.ToDecimal(agrRh?.RateCommiss);
            prcntARlt = RateComiiss.ToString("F");
            prcntARltText = Utils.PrcnPhrase(RateComiiss);

            string prcntARltJ = string.Empty;
            string prcntARltJText = string.Empty;
            decimal RateCourt = Convert.ToDecimal($"{agrRh.RateCourt:0}");
            prcntARltJ = RateCourt.ToString("F");
            prcntARltJText = Utils.PrcnPhrase(RateCourt);

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = true;
                string title = item.Title.Trim();


                switch (title)
                {
                    case "docNumberC":
                        item.Range.Text = agrRh.AgrNumber;
                        break;
                    case "docNumberR":
                        item.Range.Text = agrRh.AgrNumber;
                        break;
                    case "docDate":
                        item.Range.Text = $"{agrRh.AgrDate:dd.MM.yyyy}";
                        break;
                    case "docNumberYear":
                        item.Range.Text = $"{agrRh.AgrDate:yy}";
                        break;
                    case "docDateBegin":
                        item.Range.Text = $"{agrRh.DateBegin:dd.MM.yyyy}";
                        break;
                    case "docDateEnd":
                        item.Range.Text = $"{agrRh.DateEnd:dd.MM.yyyy}";
                        break;
                    case "CstName":
                        item.Range.Text = customerName;
                        break;
                    case "СstPerson":
                        item.Range.Text = CstPerson;
                        break;
                    case "fop":
                        item.Range.Text = fop;
                        break;
                    case "naPidstavi":
                        item.Range.Text = naPidstavi;
                        break;

                    case "CstPersonReason":
                        item.Range.Text = CstPersonReason;
                        break;
                        


                    case "СstNikName":
                        item.Range.Text = $"{anketaPerson?.NikName ?? string.Empty}";
                        break;
                    case "TableKind":
                        formTermUse(item.Range.Tables, cust.RightHolder.TermsOfService);
                        break;
                    case "TableTrrUse":
                        if (rightHolder.AroundWord == true)
                            item.Range.Text = "Всіх країн світу"; 
                        else
                            formTableInUse(item.Range.Tables, cust.RightHolder);
                        break;
                    case "TableTrrNotUs":
                        if (rightHolder.AroundWord == false)
                            item.Range.Text = "";
                        else
                            formTableExclude(item.Range.Tables, cust.RightHolder);
                        break;
                    case "prcntARlt":
                        item.Range.Text = prcntARlt;
                        break;
                    case "prcntARltText":
                        item.Range.Text = prcntARltText;
                        break;
                    case "prcntARltJ":
                        item.Range.Text = prcntARltJ;
                        break;
                    case "prcntARltJText":
                        item.Range.Text = prcntARltJText;
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
                    case "СstEDRPOU":
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

                    case "СstRegNumber":
                        item.Range.Text = СstRegNumber;
                        break;

                    case "CstRegData":
                        item.Range.Text = CstRegData;
                        break;
                    case "CstVAT":
                        item.Range.Text = CstVAT;
                        break;
                    case "CstVATType":
                        item.Range.Text = CstVATType;
                        break;



                    default:
                        item.Delete();
                        break;

                }

            } // for each
            innerDoc.Save();
            innerDoc.SaveAs2(tempFileName + ".pdf", WdSaveFormat.wdFormatPDF);
            innerDoc.Close();
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;
        }
        /// <summary>
        /// Друк доп угоди по ліцензійному договору with Stream
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="cust"></param>
        /// <param name="agr"></param>
        /// <param name="lic"></param>
        public void ProcessConsumer(string pathTemplate, Customer cust, AgreementMaster agr, LicenseAgreement lic)
        {
            ProcessConsumer(pathTemplate, cust, lic, lic.LicVersion ?? 1);
            //  await ProcessConsumer(pathTemplate, cust, lic, lic.LicVersion );
        }
        /// <summary>
        /// Друк доп угоди по ліцензійному договору with FileName
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="Consumer"></param> 
        public void ProcessConsumer(string pathTemplate, Customer cust, LicenseAgreement agr, int version)
        {
            string docFile = PrepareWork();
            System.IO.File.Copy(pathTemplate, docFile);

            // відкрити шаблон

            InnerProcessConsumer(cust, agr, version, docFile);
        }

        /// <summary>
        /// Друк доп угоди по ліцензійному договору
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="Consumer"></param>
        public async System.Threading.Tasks.Task ProcessConsumer(Stream streamTemplate, Customer cust, LicenseAgreement agr, int version)
        {
            string docFile = PrepareWork();

            using (var fileDoc = new FileStream(docFile, FileMode.CreateNew))
            {
                streamTemplate.CopyTo(fileDoc);
            }

            // відкрити шаблон

            await System.Threading.Tasks.Task.Run(() => InnerProcessConsumer(cust, agr, version, docFile));
        }
        /// <summary>
        /// Внутрішній метод формування договору з Споживачем
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="agr"></param>
        /// <param name="version"></param>
        /// <param name="docFile"></param>
        private void InnerProcessConsumer(Customer cust, LicenseAgreement agr, int version, string docFile)
        {
            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            var regions = _dic.region.ToDictionary(rec => rec.CodeI);
            var period = _dic.period.ToDictionary(rec => rec.CodeI);
            var typeVAT = _dic.typeVat.ToDictionary(rec => rec.CodeI);
            app = StartWordApp();
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
            string prcntIncText = String.Empty;

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


            DocDate = $"{licenseAgrParam?.LicDate:dd.MM.yyyy}";
            LicNum = licenseAgrParam?.LicNum ?? licAgr?.Agr?.AgreementAddBr.SingleOrDefault()?.AgrNumber;//TODO номер генерального договору 
            prcntInc = $"{licenseAgrParam?.RateAmount:F}";
            minRltGrn = $"{licenseAgrParam?.MinAmount:F}";
            int minRltKopInt = default(int);
            if (licenseAgrParam?.MinAmount != null) //TODO генеральний договір не містить такого поля
                minRltKopInt = ((int)((licenseAgrParam?.MinAmount - (int)(licenseAgrParam?.MinAmount)) * 100));
            minRltKop = minRltKopInt.ToString();
            if (minRltKopInt < 10)
            {
                minRltKop = "0" + minRltKop;
            }
            pay_period = $"{period[licenseAgrParam?.PeriodCode ?? 1].Name}";
            pay_period2 = $"{period[licenseAgrParam?.PeriodCode ?? 1].NameR}";
            DocDateEnd = $"{licenseAgrParam?.DateEnd:dd.MM.yyyy}";
            ///            prcntPrl = licenseAgrParam?.AddRate?.ToString();
            prcntPrl = $"{licenseAgrParam?.AddRate:F}";


            registerDate = $"{anketaCompany?.RegistrDate:dd.MM.yyyy}";
            registerNumber = anketaCompany?.RegistrNumber?.ToString();
            numberVAT = anketaCompany?.NumberVat?.ToString();
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
                        item.Range.Text = $"{licenseAgrParam.LicDate:yy}";
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
                        prcntIncText = Utils.PrcnPhrase(Convert.ToDecimal(licenseAgrParam.RateAmount));
                        item.Range.Text = prcntIncText;
                        break;
                    case "minRltGrn":
                        item.Range.Text = minRltGrn;
                        break;
                    case "minRltGrnText":
                        item.Range.Text = Utils.NumPhraseL(Convert.ToUInt32((int)licenseAgrParam.MinAmount), true);
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
                        item.Range.Text = Utils.PrcnPhrase(Convert.ToDecimal(licenseAgrParam.AddRate));
                        ///                        item.Range.Text = Utils.NumPhraseL(Convert.ToUInt32(licenseAgrParam.AddRate), true);
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
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;


        }

        #region Copyright request

        public async System.Threading.Tasks.Task ProcessCopyrightRequest(string pathTemplate, RightolderWithNotAcceptedCopyrightViewModel rightholder, IEnumerable<ObjectRightNotAccepted> objectRightList)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            ClearFiles();

            var docFile = tempFileName + ".docx";

            File.Copy(pathTemplate, docFile);

            // відкрити шаблон
            await System.Threading.Tasks.Task.Run(() => InnerProcesCopyrightRequest(rightholder, objectRightList));

        }

        private void InnerProcesCopyrightRequest(RightolderWithNotAcceptedCopyrightViewModel rightholder, IEnumerable<ObjectRightNotAccepted> objectRightList)
        {
            app = StartWordApp();
            innerDoc = app.Documents.Open(Docx);

            var list = innerDoc.ContentControls;

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = true;
                string title = item.Title.Trim();

                switch (title)
                {
                    case "CstName":
                        item.Range.Text = rightholder.Name;
                        break;
                    case "data":
                        item.Range.Text = DateTime.Now.ToShortDateString();
                        break;
                    case "TableObjForApp":
                        PopulateTableObjects(item.Range.Tables, objectRightList);
                        break;
                }
            }

            innerDoc.Save();
            innerDoc.SaveAs2(Pdf, WdSaveFormat.wdFormatPDF);
            innerDoc.Close();
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;

        }

        private void PopulateTableObjects(Tables tables, IEnumerable<ObjectRightNotAccepted> objectRightList)
        {
            if (tables.Count == 0)
                return;

            Table tableObjects = tables[1];

            foreach (var item in objectRightList)
            {
                var newRow = tableObjects.Rows.Add();
                newRow.Cells[1].Range.Text = (newRow.Index - 1).ToString();
                newRow.Cells[2].Range.Text = item.ObjName;
                newRow.Cells[3].Range.Text = item.GenreName;
                newRow.Cells[4].Range.Text = item.Duration;
                newRow.Cells[5].Range.Text = item.RoleName;
                newRow.Cells[6].Range.Text = item.SpecName;
                newRow.Cells[7].Range.Text = item.Rate.ToString();
                newRow.Cells[8].Range.Text = item.Performer;

                DisableBoldFont(newRow);
            }
        }

        #endregion

        #region Fixation Order

        public async System.Threading.Tasks.Task ProcessFixationOrder(string pathTemplate, Fixation fixation)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            ClearFiles();

            var docFile = tempFileName + ".docx";

            File.Copy(pathTemplate, docFile);

            // відкрити шаблон
            await System.Threading.Tasks.Task.Run(() => InnerProcessFixationOrder(fixation));

        }

        private void InnerProcessFixationOrder(Fixation fixation)
        {
            var userService = new UserService();
            var responsible = userService.GetById(fixation.UserId);

            var consumerService = new ConsumerService();
            var consumer = consumerService.GetShortInfoById(fixation.ClientCustId.Value);

            app = StartWordApp();
            innerDoc = app.Documents.Open(Docx);

            var list = innerDoc.ContentControls;

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = true;
                string title = item.Title.Trim();

                switch (title)
                {
                    case "data":
                        item.Range.Text = DateTime.Today.ToShortDateString() + " р.";
                        break;
                    case "fixEmployee":
                        item.Range.Text = responsible.FIO;
                        break;
                    case "fixDate":
                        item.Range.Text = fixation.FixationDtBegin.Value.ToShortDateString();
                        break;
                    case "fixTime":
                        item.Range.Text = fixation.FixationDtBegin.Value.ToShortTimeString();
                        break;
                    case "fixPlacement":
                        item.Range.Text = fixation.Placement;
                        break;
                    case "fixAddress":
                        item.Range.Text = fixation.Address;
                        break;
                    case "fixClientName":
                        item.Range.Text = consumer.Name;
                        break;
                    case "fixClientInnOkpo":
                        item.Range.Text = consumer.Innokpo;
                        break;
                }
            }

            innerDoc.Save();
            innerDoc.SaveAs2(Pdf, WdSaveFormat.wdFormatPDF);
            innerDoc.Close();
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;
        }

        #endregion

        #region Fixation Act

        public async System.Threading.Tasks.Task ProcessFixationAct(string pathTemplate, Fixation fixation)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            ClearFiles();

            var docFile = tempFileName + ".docx";

            File.Copy(pathTemplate, docFile);

            // відкрити шаблон
            await System.Threading.Tasks.Task.Run(() => InnerProcessFixationAct(fixation));

        }

        private void InnerProcessFixationAct(Fixation fixation)
        {
            var userService = new UserService();
            var responsible = userService.GetById(fixation.UserId);

            var consumerService = new ConsumerService();
            var consumer = consumerService.GetShortInfoById(fixation.ClientCustId.Value);

            app = StartWordApp();
            innerDoc = app.Documents.Open(Docx);

            var list = innerDoc.ContentControls;

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = true;
                string title = item.Title.Trim();

                switch (title)
                {
                    case "data":
                        item.Range.Text = DateTime.Today.ToShortDateString() + " р.";
                        break;
                    case "fixEmployee":
                        item.Range.Text = responsible.FIO;
                        break;
                    case "fixDate":
                        item.Range.Text = fixation.FixationDtBegin.Value.ToShortDateString();
                        break;
                    case "fixTime":
                        item.Range.Text = fixation.FixationDtBegin.Value.ToShortTimeString();
                        break;
                    case "fixPlacement":
                        item.Range.Text = fixation.Placement;
                        break;
                    case "fixAddress":
                        item.Range.Text = fixation.Address;
                        break;
                    case "fixClientName":
                        item.Range.Text = consumer.Name;
                        break;
                    case "fixClientInnOkpo":
                        item.Range.Text = consumer.Innokpo;
                        break;
                    case "fixEventName":
                        item.Range.Text = fixation.EventName;
                        break;
                    case "fixDevice":
                        item.Range.Text = GetStringOfDeviceList(fixation.FixStorageDevice);
                        break;
                    case "TableObjFix":
                        PopulateTableObjectsFix(item.Range.Tables, fixation.GetRegister().RegisterItem);
                        break;
                }
            }

            innerDoc.Save();
            innerDoc.SaveAs2(Pdf, WdSaveFormat.wdFormatPDF);
            innerDoc.Close();
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;
        }

        private string GetStringOfDeviceList(IEnumerable<FixStorageDevice> fixStorageDevices)
        {
            var result = "";

            foreach(var device in fixStorageDevices)
            {
                result += result == "" ? "" : "; ";
                result += $"{device.Name}, {device.SerialNumber}, {device.Capacity} Gb";
            }

            return result;
        }

        private void PopulateTableObjectsFix(Tables tables, IEnumerable<RegisterItem> registerItemList)
        {
            if (tables.Count == 0)
                return;

            Table tableObjects = tables[1];

            foreach (var item in registerItemList)
            {
                var newRow = tableObjects.Rows.Add();
                newRow.Cells[1].Range.Text = (newRow.Index - 1).ToString();
                newRow.Cells[2].Range.Text = item.ItemName;
                newRow.Cells[3].Range.Text = item.Performer;

                DisableBoldFont(newRow);
            }
        }

        #endregion

        #region Fixation Slugbova

        public async System.Threading.Tasks.Task ProcessFixationSlugbova(string pathTemplate, Fixation fixation)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            ClearFiles();

            var docFile = tempFileName + ".docx";

            File.Copy(pathTemplate, docFile);

            // відкрити шаблон
            await System.Threading.Tasks.Task.Run(() => InnerProcessFixationSlugbova(fixation));

        }

        private void InnerProcessFixationSlugbova(Fixation fixation)
        {
            var userService = new UserService();
            var responsible = userService.GetById(fixation.UserId);

            var consumerService = new ConsumerService();
            var consumer = consumerService.GetShortInfoById(fixation.ClientCustId.Value);

            app = StartWordApp();
            innerDoc = app.Documents.Open(Docx);

            var list = innerDoc.ContentControls;

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = true;
                string title = item.Title.Trim();

                switch (title)
                {
                    case "fixDate":
                        item.Range.Text = fixation.FixationDtBegin.Value.ToShortDateString();
                        break;
                    case "fixClientName":
                        item.Range.Text = consumer.Name;
                        break;
                    case "fixDevice":
                        item.Range.Text = GetStringOfDeviceList(fixation.FixStorageDevice);
                        break;
                }
            }

            innerDoc.Save();
            innerDoc.SaveAs2(Pdf, WdSaveFormat.wdFormatPDF);
            innerDoc.Close();
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;
        }

        #endregion

        #region Fixation Identification Act

        public async System.Threading.Tasks.Task ProcessFixationIdentificationAct(string pathTemplate, Fixation fixation, IEnumerable<RegisterCountViewModel> registerCountList)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            ClearFiles();

            var docFile = tempFileName + ".docx";

            File.Copy(pathTemplate, docFile);

            // відкрити шаблон
            await System.Threading.Tasks.Task.Run(() => InnerProcessFixationIdentificationAct(fixation, registerCountList));
        }

        private void InnerProcessFixationIdentificationAct(Fixation fixation, IEnumerable<RegisterCountViewModel> registerCountList)
        {
            var consumerService = new ConsumerService();
            var consumer = consumerService.GetShortInfoById(fixation.ClientCustId.Value);

            app = StartWordApp();
            innerDoc = app.Documents.Open(Docx);

            var list = innerDoc.ContentControls;

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = true;
                string title = item.Title.Trim();

                switch (title)
                {
                    case "data":
                        item.Range.Text = DateTime.Today.ToShortDateString() + " р.";
                        break;
                    case "fixDate":
                        item.Range.Text = fixation.FixationDtBegin.Value.ToShortDateString();
                        break;
                    case "fixClientName":
                        item.Range.Text = consumer.Name;
                        break;
                    case "fixEventName":
                        item.Range.Text = fixation.EventName;
                        break;
                    case "fixDevice":
                        item.Range.Text = GetStringOfDeviceList(fixation.FixStorageDevice);
                        break;
                    case "TableObjFixIdent":
                        PopulateTableObjectsIdent(item.Range.Tables, fixation.GetRegister().RegisterItem, registerCountList);
                        break;
                }
            }

            innerDoc.Save();
            innerDoc.SaveAs2(Pdf, WdSaveFormat.wdFormatPDF);
            innerDoc.Close();
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;
        }

        private void PopulateTableObjectsIdent(Tables tables, IEnumerable<RegisterItem> registerItemList, IEnumerable<RegisterCountViewModel> registerCountList)
        {
            if (tables.Count == 0)
                return;

            Table tableObjects = tables[1];

            var rowNo = 0;

            foreach (var item in registerItemList)
            {
                var newRow = tableObjects.Rows.Add();
                newRow.Cells[1].Range.Text = (++rowNo).ToString();
                newRow.Cells[2].Range.Text = item.Obj.Name;
                newRow.Cells[3].Range.Text = item.Obj.Performer;
                newRow.Cells[4].Range.Text = item.RegisterItemFix.TimeStart.ToString();
                newRow.Cells[5].Range.Text = item.RegisterItemFix.TimeEnd.ToString();

                DisableBoldFont(newRow);

                var countList = registerCountList
                    .Where(rc => rc.RegId == item.RegId && rc.RegIitemId == item.RegIitemId)
                    .ToList();

                foreach (var countItem in countList)
                {
                    if (countList.IndexOf(countItem) > 0)
                    {
                        newRow = tableObjects.Rows.Add();

                        DisableBoldFont(newRow);
                    }

                    newRow.Cells[6].Range.Text = countItem.CreativeRoles;
                    newRow.Cells[7].Range.Text = countItem.Name;
                    newRow.Cells[9].Range.Text = countItem.Rate.ToString();
                }
            }
        }

        private static void DisableBoldFont(Row newRow)
        {
            for (var i = 1; i <= newRow.Cells.Count; i++)
            {
                newRow.Cells[i].Range.Font.Bold = 0;
            }
        }

        #endregion

        class TbAuthorPrc
        {
            public string RoleName { get; set; }
            public string AuthorName { get; set; }
            public decimal RoleRate { get; set; }
            public string CountryName { get; set; }
        }
        class TbAuthorL
        {
            public string RoleName { get; set; }
            public string AuthorName { get; set; }
            public string CountryName { get; set; }
            public decimal? prepaySum { get; set; }
            public string Currency { get; set; }
            public DateTime? prepayDateDo { get; set; }
        }
        class currency
        {
            public string r030 { get; set; }
            public string countryCode { get; set; }
            public string a3 { get; set; }
        }

        public void processConsumerBR(string pathTemplate, Customer cust, AgreementMaster agrMain, LicenseAgreement licA)
        {

            AgreementAddBr agr = agrMain.AgreementAddBr.Where(rec => rec.Version == agrMain.Version).First();
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var docFile = tempFileName + ".docx";

            if (File.Exists(docFile))
                File.Delete(docFile);

            File.Copy(pathTemplate, docFile);
            // відкрити шаблон

            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            var regions = _dic.region.ToDictionary(rec => rec.CodeI);
            var period = _dic.period.ToDictionary(rec => rec.CodeI);
            var typeVAT = _dic.typeVat.ToDictionary(rec => rec.CodeI);
            var KL030 = (from kl in _dic.klR030
                         select new currency { r030 = kl.R030, countryCode = kl.CountryCode, a3 = kl.A3 }
            );

            app = StartWordApp();
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
            agreementAddBr = agr;

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
            string ShowName = String.Empty;
            string ShowAct = String.Empty;
            string docNumberC = String.Empty;
            string docDateC = String.Empty;
            string docDateEndС = String.Empty;
            string prcntShow = string.Empty;
            string prcntShowText = string.Empty;
            string pPayShowGrnText = string.Empty;
            string pPayShowKop = string.Empty;
            string PayShowDataDo = string.Empty;
            string aPayShowGrnText = string.Empty;
            string aPayShowKop = string.Empty;

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
                phone = bossEmployee?.Empl.PhoneNumber ?? string.Empty;
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

            GdocDateC = $"{agreementAddBr?.AgrDate:dd.MM.yyyy}";
            GdocDateBeginC = $"{agreementAddBr?.DateBegin:dd.MM.yyyy}";
            GdocDateEndC = $"{agreementAddBr?.DateEnd:dd.MM.yyyy}";
            GdocNumber = agreementAddBr?.AgrNumber?.ToString() ?? agr.AgrNumber?.ToString();

            registerDate = $"{anketaCompany?.RegistrDate:dd.MM.yyyy}";
            registerNumber = anketaCompany?.RegistrNumber?.ToString();
            numberVAT = anketaCompany?.NumberVat.ToString();
            typeVat = $"{typeVAT[anketaCompany?.TypeVat ?? 2].Name}";

            LicenseBigR licenseBigR = licA?.LicenseBigR;
            var creativeRole = _dic.creativeRoleType;
            var authors = licenseBigR?.Obj.Authors?.Where(rec => rec.ObjId == licenseBigR.ObjId).ToList();
            var copyright = licenseBigR?.Obj.CopyRight?.Where(rec => rec.ObjId == licenseBigR.ObjId).ToList();
            var licauthorbr = licenseBigR?.Obj.CopyRight.Select(rec => rec.LicAuthorBr).ToList();

            var TbAPrc = new List<TbAuthorPrc>();
            if (authors != null)

            {
                TbAPrc = (from aut in authors
                          join crt in creativeRole on aut.RoleCode equals crt.CodeI
                          join cpr in copyright on aut.CustId equals cpr.CustId
                          select new TbAuthorPrc
                          { RoleName = crt.Name ?? " ", AuthorName = aut.AuthorName ?? " ", RoleRate = cpr.RoleRate ?? 0 })?.ToList();
            }

            var TbAL = new List<TbAuthorL>();
            if (authors != null)
            { 
                 TbAL = (from aut in authors
                            join crt in creativeRole on aut.RoleCode equals crt.CodeI
                            join cpr in copyright on aut.CustId equals cpr.CustId
                            join lab in licauthorbr on cpr.CRightId equals lab.CRightId
                            where lab.PrepayType == 1
                            select new TbAuthorL
                            {
                                RoleName = crt.Name,
                                AuthorName = aut.AuthorName,
                                CountryName = null,
                                prepaySum = lab.PrepaySum ?? 0,
                                Currency = lab.R030 ?? "980"
                                ,
                                prepayDateDo = lab.PrepayDateDo
                            }).ToList();
        }
            var TbAvAdv = new List<TbAuthorL>();
            if (authors != null)
            {
                TbAvAdv = (from aut in authors
                           join crt in creativeRole on aut.RoleCode equals crt.CodeI
                           join cpr in copyright on aut.CustId equals cpr.CustId
                           join lab in licauthorbr on cpr.CRightId equals lab.CRightId
                           where lab.PrepayType == 2
                           select new TbAuthorL
                           {
                               RoleName = crt.Name,
                               AuthorName = aut.AuthorName,
                               CountryName = null,
                               prepaySum = lab.PrepaySum ?? 0,
                               Currency = lab.R030 ?? "980"
                               ,
                               prepayDateDo = lab.PrepayDateDo
                           }).ToList();
            }


            ShowName = licenseBigR?.Obj?.Name?.ToString();
            ShowAct = licenseBigR?.Obj?.ActCode?.ToString();

            docNumberC = licA?.LicenseAgrParam?.Where(rec => rec.LicVersion == licA.LicVersion).Single().LicNum;
            LicenseAgrParam licagr = licA?.LicenseAgrParam?.Where(rec => (rec.LicId == licA.LicId) &
                    (rec.LicVersion == licA.LicVersion)).Single();

            docDateC = $"{licagr?.LicDate:dd.MM.yyyy}";
            docDateEndС = $"{licagr?.DateEnd:dd.MM.yyyy}";
            decimal prcntrate = Convert.ToDecimal(licenseBigR?.Rate);
            prcntShow = prcntrate.ToString("F");
            prcntShowText = Utils.PrcnPhrase(prcntrate);
            //PayShowDataDo = $"{licA?.LicenseBigR?.PrepayDateDo:dd.MM.yyyy}";
            decimal pPayShowGrn = 0;
            decimal aPayShowGrn = 0;
            //var array_licAuthorB = licA?.LicenseBigR?.LicAuthorBr?.ToList();
            //if (array_licAuthorB != null)
            //{
            //    foreach (LicAuthorBr item in array_licAuthorB)
            //    {
            //        if (item.PrepayType == 1)
            //        {
            //            pPayShowGrn = pPayShowGrn + Convert.ToDecimal(item.PrepaySum);
            //        }
            //        if (item.PrepayType == 2)
            //        {
            //            aPayShowGrn = aPayShowGrn + Convert.ToDecimal(item.PrepaySum);
            //        }

            //    }
            //}
            pPayShowGrnText = Utils.NumPhrase(Convert.ToUInt32((int)(pPayShowGrn)), false);
            pPayShowKop = ((int)((pPayShowGrn - (int)(pPayShowGrn)) * 100)).ToString();
            aPayShowGrnText = Utils.NumPhrase(Convert.ToUInt32((int)(aPayShowGrn)), false);
            aPayShowKop = ((int)((aPayShowGrn - (int)(aPayShowGrn)) * 100)).ToString();

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = false;
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
                    case "CstName":
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
                    case "TableAvtorPrc":
                        formTableAvtorPrc(item.Range.Tables, TbAPrc);
                        break;
                    case "TableAvtorLmp":
                        formTableAvtorLmp(item.Range.Tables, TbAL);
                        break;
                    case "TableAvtorAdv":
                        formTableAvtorLmp(item.Range.Tables, TbAvAdv);
                        break;


                    case "GdocDateBeginC":
                        item.Range.Text = GdocDateBeginC;
                        break;
                    case "GdocDateEndC":
                        item.Range.Text = GdocDateEndC;
                        break;
                    case "CstLegalAddress":
                        item.Range.Text = reAddress;
                        break;
                    case "CstResidentialAddress":
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
                    case "CstBankName":
                        item.Range.Text = $"{bankacc?.MfoName ?? string.Empty}";
                        break;
                    case "CstBankMfo":
                        item.Range.Text = $"{bankacc?.Mfo.ToString() ?? string.Empty}";
                        break;
                    case "CstAcc":
                        item.Range.Text = $"{bankacc?.AccountNumber ?? string.Empty}";
                        break;
                    case "CstRegNumber":
                        item.Range.Text = registerNumber;
                        break;
                    case "CstRegData":
                        item.Range.Text = registerDate;
                        break;
                    case "CstVAT":
                        item.Range.Text = numberVAT;
                        break;
                    case "CstVATType":
                        item.Range.Text = typeVat;
                        break;
                    case "CstEmail":
                        item.Range.Text = eMail;
                        break;
                    case "CstContPerson":
                        item.Range.Text = cstContPerson;
                        break;
                    case "CstContPersonPhone":
                        item.Range.Text = cstContPersonPhone;
                        break;
                    case "ShowName":
                        item.Range.Text = ShowName;
                        break;
                    case "ShowAct":
                        item.Range.Text = ShowAct;
                        break;
                    case "docNumberC":
                        item.Range.Text = docNumberC;
                        break;
                    case "docDateC":
                        item.Range.Text = docDateC;
                        break;
                    case "prcntShow":
                        item.Range.Text = prcntShow;
                        break;
                    case "prcntShowText":
                        item.Range.Text = prcntShowText;
                        break;
                    case "pPayShowGrn":
                        item.Range.Text = ((int)(pPayShowGrn)).ToString();
                        break;
                    case "pPayShowGrnText":
                        item.Range.Text = pPayShowGrnText;
                        break;
                    case "pPayShowKop":
                        item.Range.Text = pPayShowKop;
                        break;
                    case "aPayShowGrn":
                        item.Range.Text = ((int)(aPayShowGrn)).ToString();
                        break;
                    case "aPayShowGrnText":
                        item.Range.Text = aPayShowGrnText;
                        break;
                    case "aPayShowKop":
                        item.Range.Text = aPayShowKop;
                        break;
                    case "PayShowDataDo":
                        item.Range.Text = PayShowDataDo;
                        break;
                    case "docDateEndС":
                        item.Range.Text = docDateEndС;
                        break;
                    case "TableAvtor":
                        //formTableAvtor(item.Range.Tables, array_licAuthorB);
                        break;

                    default:

                        break;

                }

                item.Delete();
            } // for each
            innerDoc.Save();
            innerDoc.SaveAs2(tempFileName + ".pdf", WdSaveFormat.wdFormatPDF);
            innerDoc.Close();
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;

        }



        public void processPartner(string pathTemplate, Customer cust, AgreementMaster agrMain)
        {

            AgreementAddPartner agr = cust.Partner.AgreementAddPartner.
                Where(rec => (rec.Version == agrMain.Version) &(rec.AgrId == agrMain.AgrId)).First();
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var docFile = tempFileName + ".docx";

            if (File.Exists(docFile))
                File.Delete(docFile);

            File.Copy(pathTemplate, docFile);
            // відкрити шаблон

            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            var regions = _dic.region.ToDictionary(rec => rec.CodeI);
            var period = _dic.period.ToDictionary(rec => rec.CodeI);
            var typeVAT = _dic.typeVat.ToDictionary(rec => rec.CodeI);
            var KL030 = (from kl in _dic.klR030
                         select new currency { r030 = kl.R030, countryCode = kl.CountryCode, a3 = kl.A3 }
            );

            app = StartWordApp();
            innerDoc = app.Documents.Open(docFile);
            // отримати ControlContent
            var list = innerDoc.ContentControls;

            // замінити вміст

            AnketaPerson anketaPerson = cust.Person?.AnketaPerson.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
            BankAccount bankacc = cust.BankAccount.FirstOrDefault();
            AgreementAddPartner agreementAddPartner;
            agreementAddPartner = agr;

            string docNumberP = string.Empty;
            string docDateP = string.Empty;
            string appeal = string.Empty;
            string CstName = string.Empty;
            string CstPasportIssued = string.Empty;
            string CstResidentialAddress = string.Empty;
            string CstINN = string.Empty;
            string docDateBeginP = string.Empty;
            string docDateEndP = string.Empty;
            string cstPasport = string.Empty;
            string CstBankName = string.Empty;
            string CstBankMFO = string.Empty;
            string CstBankEDRPOU = string.Empty;
            string CstAcc = string.Empty;
            string CstPhone = string.Empty;
            
         string faAddress = string.Empty;
            string eMail = string.Empty;

            {
                CstName = $"{anketaPerson.LastName} {anketaPerson.FirstName} {anketaPerson.SurName ?? string.Empty}";
                CstPasportIssued =$"{anketaPerson.PUissuedWho } {anketaPerson.PUissuedWhen:dd.MM.yyyy}";
                cstPasport  = $"{anketaPerson.PUseries} {anketaPerson.PUnumber} ";
                CstINN = $"{anketaPerson.Inn}";
                CstBankName = $"{bankacc.MfoName}";
                CstBankMFO = $"{bankacc.Mfo}";
                CstBankEDRPOU = $"{bankacc.MfoOkpo}";
                CstAcc = $"{bankacc.TransitNumber}";
                CstPhone = $"{anketaPerson.PhoneMobileMain}";
                faAddress = anketaPerson.FaAddress != null ?
                    $"{countries[anketaPerson.FaCountry ?? "804"].CountryName} {anketaPerson.FaCity} {anketaPerson.FaAddress}" : faAddress;
                faAddress = $"{countries[anketaPerson.FaCountry ?? "804"].CountryName}{","} {anketaPerson.FaCity}{","} {anketaPerson.FaAddress}" ;

                eMail = anketaPerson.EMail;
      
            }

            docDateP = $"{agreementAddPartner?.AgrDate:dd.MM.yyyy}";
            docDateBeginP = $"{agreementAddPartner?.DateBegin:dd.MM.yyyy}";
            docDateEndP = $"{agreementAddPartner?.DateEnd:dd.MM.yyyy}";
            docNumberP = agreementAddPartner?.AgrNumber?.ToString() ?? agr.AgrNumber?.ToString();
            appeal = "Громадянин";
            if (anketaPerson.Sex == 1)
                appeal = "Громадянка";

            string firstMonthRate = string.Empty;
            string firstMonthRateText = string.Empty;

            string monthRate = string.Empty;
            string monthRateText = string.Empty;

            string pfFirstRate = string.Empty;
            string pfFirstRateText = string.Empty;

            decimal fprcntrate = Convert.ToDecimal(agreementAddPartner?.SrFirstRate);
            firstMonthRate = fprcntrate.ToString("F");
            firstMonthRateText = Utils.PrcnPhrase(fprcntrate);

            decimal mprcntrate = Convert.ToDecimal(agreementAddPartner?.SrMonthRate);
            monthRate = mprcntrate.ToString("F");
            monthRateText = Utils.PrcnPhrase(mprcntrate);

            decimal pprcntrate = Convert.ToDecimal(agreementAddPartner?.PfFirstRate);
            pfFirstRate = pprcntrate.ToString("F");
            pfFirstRateText = Utils.PrcnPhrase(pprcntrate);

      

            foreach (ContentControl item in list)
            {
                item.LockContentControl = false;
                item.Temporary = false;
                string title = item.Title.Trim();

                switch (title)

                {
                    case "docNumberP":
                        item.Range.Text = docNumberP;
                        break;
                    case "docDateP":
                        item.Range.Text = docDateP;
                        break;
                    case "docDateBeginP":
                        item.Range.Text = docDateBeginP;
                        break;
                    case "docDateEndP":
                        item.Range.Text = docDateEndP;
                        break;
                    case "CstName":
                        item.Range.Text = CstName;
                        break;
                    case "appeal":
                        item.Range.Text = appeal;
                        break;
                    case "CstPasportIssued":
                        item.Range.Text = CstPasportIssued;
                        break;
                    case "CstResidentialAddress":
                        item.Range.Text = faAddress;
                        break;
                    case "firstMonthRate":
                        item.Range.Text = firstMonthRate;
                        break;
                    case "firstMonthRateText":
                        item.Range.Text = firstMonthRateText;
                        break;
                    case "monthRate":
                        item.Range.Text = monthRate;
                        break;
                    case "monthRateText":
                        item.Range.Text = monthRateText;
                        break;

                    case "pfFirstRate":
                        item.Range.Text = pfFirstRate;
                        break;
                    case "pfFirstRateText":
                        item.Range.Text = pfFirstRateText;
                        break;
                    case "cstPasport":
                        item.Range.Text = cstPasport;
                        break;
                    case "CstINN":
                        item.Range.Text = CstINN;
                        break;
                    case "CstBankName":
                        item.Range.Text = CstBankName;
                        break;
                    case "CstBankMFO":
                        item.Range.Text = CstBankMFO;
                        break;
                    case "CstBankEDRPOU":
                        item.Range.Text = CstBankEDRPOU;
                        break;
                    case "CstAcc":
                        item.Range.Text = CstAcc;
                        break;
                    case "CstPhone":
                        item.Range.Text = CstPhone;
                        break;




                 case "CstEmail":
                        item.Range.Text = eMail;
                        break;
                    default:

                        break;

                }

                item.Delete();
            } // for each
            innerDoc.Save();
            innerDoc.SaveAs2(tempFileName + ".pdf", WdSaveFormat.wdFormatPDF);
            innerDoc.Close();
        }











        private string PrepareWork()
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var docFile = tempFileName + ".docx";

            if (File.Exists(docFile))
                File.Delete(docFile);
            return docFile;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathTemplate"></param>
        /// <param name="cust"></param>
        /// <param name="licAgr"></param>
        /// <param name="period"></param>
        public void processAction(string pathTemplate, Customer cust, LicenseAgreement licAgrMain, PaidPeriod period)
        {
            // копіювати в тимчасову папку
            tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var docFile = tempFileName + ".docx";

            if (File.Exists(docFile))
                File.Delete(docFile);

            File.Copy(pathTemplate, docFile);
            // відкрити шаблон
            var licAgr = licAgrMain.LicenseAgrParam.Where(rec => rec.LicVersion == licAgrMain.LicVersion).Single();

            AnketaCompany anketaCompany = cust.Company?.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
            BankAccount bankacc = cust.BankAccount.FirstOrDefault();
            Employee Employee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault()?.Empl;
            Employee EmployeeBooker = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 2).SingleOrDefault()?.Empl;
            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            var regions = _dic.region.ToDictionary(rec => rec.CodeI);
            var typeVAT = _dic.typeVat.ToDictionary(rec => rec.CodeI);
            var bossEmployee = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault();


            app = StartWordApp();
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
            CPaidPeriod = period?.PeriodName ;
            CPaidData = $"{ DateTime.Today:dd.MM.yyyy}";
            customerName = anketaCompany.Name;
            CstPersonReason = bossEmployee?.RelDocument;
            CstPerson = $"{Employee.LastName} {Employee.FirstName} {Employee.SurName ?? string.Empty}";
            CstBooker = $"{EmployeeBooker.LastName} {EmployeeBooker.FirstName} {EmployeeBooker.SurName ?? string.Empty}";
            CPaidAmountGrn = period?.Amount.ToString();
            CPaidAmountGrnText = Utils.NumPhraseL(Convert.ToUInt32(period?.Amount), false);
            int CPaidAmountKopInt = ((int)((period?.Amount ?? 0 - period?.Amount ?? 0) * 100)  );
            CPaidAmountKop = CPaidAmountKopInt.ToString();
            if (CPaidAmountKopInt < 10)
            {
                CPaidAmountKop = "0" + CPaidAmountKop;
            }

            CPaidAmountKopText = Utils.NumPhraseL(Convert.ToUInt32(((int)((period?.Amount ?? 0 - period?.Amount ?? 0) * 100))), false);
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
            Marshal.ReleaseComObject(innerDoc);
            innerDoc = null;


        }

        private void formTableAvtorPrc(Tables tables, List<TbAuthorPrc> list)
        {
            TbAuthorPrc tbAuthorPrc;
            if (tables.Count == 0) return;
            Table table = tables[1];
            Row curRow = null;
            int index = 1;
            foreach (var item in list)
            {
                tbAuthorPrc = item;
                curRow = table.Rows.Add();
                index++;
                curRow.Cells[1].Range.Text = tbAuthorPrc.RoleName.ToString();
                curRow.Cells[2].Range.Text = tbAuthorPrc.AuthorName.ToString();
                curRow.Cells[3].Range.Text = "Україна";
                curRow.Cells[4].Range.Text = tbAuthorPrc.RoleRate.ToString("F");
            }
        }
        private void formTableAvtorLmp(Tables tables, List<TbAuthorL> list)
        {
            TbAuthorL tbAuthorL;
            if (tables.Count == 0) return;
            Table table = tables[1];
            Row curRow = null;
            int index = 1;
            foreach (var item in list)
            {
                tbAuthorL = item;
                curRow = table.Rows.Add();
                index++;
                curRow.Cells[1].Range.Text = tbAuthorL.RoleName.ToString();
                curRow.Cells[2].Range.Text = tbAuthorL.AuthorName.ToString();
                curRow.Cells[3].Range.Text = "Україна";
                curRow.Cells[4].Range.Text = (Convert.ToDecimal(tbAuthorL.prepaySum)).ToString("F");
                curRow.Cells[5].Range.Text = tbAuthorL.Currency.ToString();
                curRow.Cells[6].Range.Text = $"{tbAuthorL.prepayDateDo:dd.MM.yyyy}";
            }
        }





        private void formTableAvtor(Tables tables, ICollection<LicAuthorBr> alicAuthorB)
        {
            LicAuthorBr authorBr;
            if (tables.Count == 0) return;
            Table table = tables[1];
            //    var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            Row curRow = null;
            int index = 1;
            foreach (var item in alicAuthorB)
            {
                authorBr = item;
                curRow = table.Rows.Add();
                index++;
                //curRow.Cells[1].Range.Text = authorBr.RoleType.ToString();
                //curRow.Cells[2].Range.Text = authorBr.NameAuthor;
                curRow.Cells[3].Range.Text = "Україна";
                curRow.Cells[4].Range.Text = "";
                curRow.Cells[5].Range.Text = authorBr.Rate.ToString();
                curRow.Cells[6].Range.Text = "гривня";
                curRow.Cells[7].Range.Text = authorBr.PrepaySum.ToString();
                curRow.Cells[8].Range.Text = "";
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
                    //curRow.Cells[4].Range.Text = place.SqHoll.ToString();
                    //curRow.Cells[5].Range.Text = place.HollNum.ToString();
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
                //                curRow.Cells[4].Range.Text = places.ClnPlaceHoll?.First().SqHoll?.ToString();

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
                    //curRow.Cells[4].Range.Text = place.HollNum.ToString();
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
            //if (table.Rows.Count > 0)
            //    table.Rows.Delete();

            /*
            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);
            Row curRow = null;
            foreach (var item in rightHolder.TerritoryExclude)
            {
                curRow = curRow == null ? table.Rows[1] : table.Rows.Add();
                curRow.Cells[1].Range.Text = countries[item.CountryCode].CountryName;
            }
            */


            var list = rightHolder.TerritoryExclude;

            if (list.Count == 0)
            {
                table.Rows.Delete();
                return;
            }

            for (int i = table.Rows.Count; i > 2; i--)
                table.Rows[i].Delete();

            var countries = _dic.country.ToDictionary(rec => rec.CountryCode);

            Row curRow = null;

            WdRowAlignment aa;
            
  /*          if (rightHolder.AroundWord == true)
            {
                curRow = curRow == null ? table.Rows[1] : table.Rows.Add();
                curRow.Cells[1].Range.Text = "Всіх країн світу";
            }
            else
  */              foreach (var item in rightHolder.TerritoryExclude)
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

