using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWord_1
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        //      private RightholderService service = new RightholderService();
        private ConsumerService service = new ConsumerService();
        private RightholderService service1 = new RightholderService();      

        private WordEngine wordApp = null;

        public RadForm1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {

            string Filename = string.Empty;

            Filename = "F_7_Г готелі.docx";
                        Filename = "F_4_ТЦ магазини.docx";
                        Filename = "F_1_БВ-НК-бари-дискотеки_.docx";
                        
                        Filename = "F_6_МТЦ.docx";
                        Filename = "F_Акт_публічне виконання.docx";  
                     
                      Filename = "F_Акт_публічне сповіщення TV+радио.docx";
                    Filename = "F_Акт_публічне сповіщення кTV.docx";
                        Filename = "F_DOGOVIR-NA-UPRAVLINNYA-PRAVAMI-Avtora-2018-1_.docx";
            Filename = "F_ГО УААСП Автор.docx";
              //          Filename = "F_Лицензионный договор на спектакль (БП).docx";
              //  Filename = "F_ТИПОВИЙ ДОГОВІР ПРЕДСТАВНИК ГО УААСП.docx";
                 Filename = "F_ГО УААСП Правовласник-Видавництво.docx";
            //Filename = "F_3_МБВ.docx";
            //      Filename = "F_ТИПОВИЙ ГЕНЕРАЛЬНИЙ ДОГОВІР ТЕАТРИ.docx";
            // Filename = "F_ТИПОВИЙ ДОГОВІР КБР ГО УААСП.docx";
            Filename = "F_dogovir_licenziya_teatr_go_uaasp.docx";


            base.OnLoad(e);
            string template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Filename);
            ProcessWord(template, Filename);
            //Task.Run(()=>ProcessWord(template, Filename)).GetAwaiter().GetResult();

        }

        private void ProcessWord(string template, string Filename)
        {
            
            
            //         Customer cust = service.GetData(134);
            Customer cust;

            

            switch (Filename)
            {
                case "F_DOGOVIR-NA-UPRAVLINNYA-PRAVAMI-Avtora-2018-1_.docx":
                    cust = service1.GetData(221);
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessRightHolder(template, cust, cust.AgreementMaster.First());
                    break;
                case "F_ГО УААСП Автор.docx":
                    cust = service1.GetData(222);
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessRightHolder(template, cust, cust.AgreementMaster.First());
                    break;
                case "F_ГО УААСП Правовласник-Видавництво.docx":
                    cust = service1.GetData(305);
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessRightHolder(template, cust, cust.AgreementMaster.First());
                    break;
/*
                case "F_ТИПОВИЙ ДОГОВІР ПРЕДСТАВНИК ГО УААСП.docx":
                   // cust = service.GetPartner(300);
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.processPartner(template, cust, cust.AgreementMaster.First());
                    break;
                    */
                case "F_Лицензионный договор на спектакль (БП).docx":
                    /*                    cust = service.GetData(134);
                                        LicenseAgreement licAgr4 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == 1).SingleOrDefault();
                                        PaidPeriod Period4 = licAgr4.PaidPeriod.FirstOrDefault();
                                        wordApp = new WordEngine(service.GetDictionary());
                                        wordApp.processAction(template, cust, licAgr4, Period4);
                                        break;
                    */
                    cust = service.GetData(321);
                    wordApp = new WordEngine(service.GetDictionary());
                    
// для теста берем agrid=13;
                    AgreementMaster agreementMaster = cust.AgreementMaster?.Where(rec => rec.AgrId == 2334).Single();
// для теста берем agrid=13 и licid=3;
                    LicenseAgreement licA = cust.Client.LicenseAgreement?.Where(rec => (rec.AgrId == 2334 &  rec.LicId == 1202)).Single();
                    wordApp.ProcessConsumerBR(template, cust, agreementMaster , licA);
                    break;

                case "F_Акт_публічне виконання.docx":
                    cust = service.GetData(134);
                    LicenseAgreement licAgr = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == 1).SingleOrDefault();
                    PaidPeriod Period1 = licAgr.PaidPeriod.FirstOrDefault();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessAction(template, cust, licAgr, Period1);
                    break;
                case "F_Акт_публічне сповіщення TV+радио.docx":
                    cust = service.GetData(134);
                    LicenseAgreement licAgr1 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == 1).SingleOrDefault();
                    PaidPeriod Period2 = licAgr1.PaidPeriod.FirstOrDefault();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessAction(template, cust, licAgr1, Period2);
                    break;
                case "F_Акт_публічне сповіщення кTV.docx":
                    cust = service.GetData(134);
                    LicenseAgreement licAgr2 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == 1).SingleOrDefault();
                    PaidPeriod Period3 = licAgr2.PaidPeriod.FirstOrDefault();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessAction(template, cust, licAgr2, Period3);
                    break;
                case "F_ТИПОВИЙ ГЕНЕРАЛЬНИЙ ДОГОВІР ТЕАТРИ.docx":
                    cust = service.GetData(1375);
                    // для теста берем agrid=13;
                    AgreementMaster agreementMaster11 = cust.AgreementMaster?.Where(rec => rec.AgrId == 3442).Single();
                    // для теста берем agrid=13 и licid=3;
                    LicenseAgreement licA11 = cust.Client.LicenseAgreement?.Where(rec => (rec.AgrId == 3442 & rec.LicId == 1298)).Single();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessConsumerBR(template, cust, agreementMaster11, licA11);
                    break;


                case "F_dogovir_licenziya_teatr_go_uaasp.docx":
                    cust = service.GetData(3059);
                    // для теста берем agrid=13;
                    AgreementMaster agreementMaster111 = cust.AgreementMaster?.Where(rec => rec.AgrId == 4389).Single();
                    // для теста берем agrid=13 и licid=3;
                    LicenseAgreement licA111 = cust.Client.LicenseAgreement?.Where(rec => (rec.AgrId == 4389 & rec.LicId == 1496)).Single();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessConsumerBR(template, cust, agreementMaster111, licA111);
                    break;
                case "F_7_Г готелі.docx":
                    cust = service.GetData(226);
                    LicenseAgreement licAgr3 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == 1).SingleOrDefault();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessConsumer(template, cust, cust.AgreementMaster.First(), licAgr3);
                    break;
                case "F_4_ТЦ магазини.docx":
                    cust = service.GetData(134);

                    wordApp = new WordEngine(service.GetDictionary());
                    AgreementMaster agrMaster = cust.AgreementMaster.First();
                    LicenseAgreement licAgr4 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == agrMaster.Version
                    & rec.AgrId == agrMaster.AgrId).SingleOrDefault();
                    wordApp.ProcessConsumer(template, cust, agrMaster, licAgr4);
 ///                   await wordApp.ProcessConsumer(template, cust, cust.AgreementMaster.First(), null);
                    break;
                case "F_1_БВ-НК-бари-дискотеки_.docx":
                    cust = service.GetData(134);
                    AgreementMaster agrMaster1 = cust.AgreementMaster.First();
                    LicenseAgreement licAgr5 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == agrMaster1.Version
                    & rec.AgrId == agrMaster1.AgrId).SingleOrDefault();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessConsumer(template, cust, agrMaster1, licAgr5);
                    break;
                case "F_3_МБВ.docx":
                    cust = service.GetData(134);
                    AgreementMaster agrMaster2 = cust.AgreementMaster.First();
                    LicenseAgreement licAgr6 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == agrMaster2.Version
                    & rec.AgrId == agrMaster2.AgrId).SingleOrDefault();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessConsumer(template, cust, agrMaster2, licAgr6);
                    break;
                case "F_6_МТЦ.docx":
                    cust = service.GetData(134);
                    AgreementMaster agrMaster3 = cust.AgreementMaster.First();
                    LicenseAgreement licAgr7 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == agrMaster3.Version
                  & rec.AgrId == agrMaster3.AgrId).SingleOrDefault();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessConsumer(template, cust, agrMaster3, licAgr7);
                    break;

                case "F_ТИПОВИЙ ДОГОВІР КБР ГО УААСП.docx":
                    cust = service.GetData(1375);
                    AgreementMaster agrMaster5 = cust.AgreementMaster.First();
                    LicenseAgreement licAgr75 = cust.Client.LicenseAgreement.Where(rec => rec.Agr.Version == agrMaster5.Version
                  & rec.AgrId == agrMaster5.AgrId).SingleOrDefault();
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessConsumer(template, cust, agrMaster5, licAgr75);
                    break;

                default:
                    cust = service.GetData(134);                   
                    wordApp = new WordEngine(service.GetDictionary());
                    wordApp.ProcessConsumer(template, cust, cust.AgreementMaster.First(), null);
                    break;
            }
            radPdfViewer1.LoadDocument(wordApp.Pdf);

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
