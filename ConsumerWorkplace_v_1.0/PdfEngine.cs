using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using iText.Forms;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerWorkplace_v_1._0
{
    public static class PdfEngine
    {
        public static string GetPdf( Customer cust, AnketaDictionaties dic )
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            var license = cust.Client.LicenseAgreement.Where(rec => rec.LicStatus < 4).SingleOrDefault();
            var agree = license.Agr;
            var anketa = cust.Company.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
            var relEmployy = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault();
            var bankAcc = cust.BankAccount.FirstOrDefault();
            var period = dic.period.Where(rec => rec.CodeI == license.PeriodCode).SingleOrDefault();

            var licTypeDoc = dic.agrLicenseType.Where(rec => rec.CodeI == license.LicCode ).SingleOrDefault();
            var sors = Path.Combine(currentDir, "PDF", licTypeDoc.TemplateName );
            var dest = Path.Combine(currentDir, "PDF", "OutDocument.pdf");

            PdfDocument doc =  new PdfDocument( new PdfReader(sors)
                                    , new PdfWriter(dest));

            PdfAcroForm form = PdfAcroForm.GetAcroForm(doc, true);
            string FONT = "c:/Windows/Fonts/Arial.ttf";
            PdfFont font = PdfFontFactory.CreateFont(FONT, "Cp1251", true);

            form.GetField("License.licNum").SetValue(license.Agr.AgrNumber, font, 10);
            form.GetField("Date").SetValue(license.Agr.AgrDate?.ToString() ?? DateTime.Today.ToString(), font, 10);
            form.GetField("AnketaCompany.name").SetValue(anketa.Name, font, 10);
            form.GetField("Employee.name").SetValue($"{relEmployy.Empl.LastName} {relEmployy.Empl.FirstName} {relEmployy.Empl.SurName ?? string.Empty }", font, 10);
            form.GetField("RelEmployee.RelDocument").SetValue(relEmployy.RelDocument ?? string.Empty, font, 10);

            form.GetField("LicenseAgreement.rateAmount").SetValue(license.RateAmount?.ToString() ?? "1", font, 10);
            form.GetField("LicenseAgreement.minAmount#0").SetValue(license.MinAmount?.ToString() ?? "2 000", font, 10);
            form.GetField("LicenseAgreement.minAmount").SetValue((license.MinAmount % 100)?.ToString() ?? "00", font, 10);
            form.GetField("Period.name").SetValue(period?.Name ?? string.Empty, font, 10);
            form.GetField("Period.nameR").SetValue(period?.Name ?? string.Empty, font, 10);
            form.GetField("year").SetValue(DateTime.Today.Year.ToString(), font, 10);
            form.GetField("LicenseAgreement.addRate").SetValue(license.AddRate?.ToString() ?? "5", font, 10);
            form.GetField("AnketaPerson.Name").SetValue(anketa.Name, font, 10);
            form.GetField("AnketaCompany.JaCountry + AnketaCompany.jaRegion + AnketaCompany.JaCity + AnketaCompany.JaAddress").SetValue($"{anketa.JaCity} {anketa.JaAddress}", font, 10);
            form.GetField("AnketaCompany.faCountry +  AnketaCompany. faRegion + AnketaCompany.faCity + AnketaCompany.faAddress").SetValue($"{anketa.FaCity} {anketa.FaAddress}", font, 10);
            form.GetField("Employee.PhoneNumber").SetValue(relEmployy.Empl.PhoneNumber, font, 10);
            form.GetField("AnketaCompany.OKPO").SetValue(anketa.Okpo, font, 10);
            form.GetField("BankAccount.mfoName").SetValue(bankAcc.MfoName, font, 10);
            form.GetField("BankAccount.mfo").SetValue(bankAcc.Mfo.ToString(), font, 10);
            form.GetField("BankAccount.accountNumber").SetValue(bankAcc.AccountNumber, font, 10);
            form.GetField("AnketaCompany.registrNumber").SetValue(anketa.RegistrNumber, font, 10);
            form.GetField("AnketaCompany.registrDate").SetValue(anketa.RegistrDate.ToString(), font, 10);
            form.GetField("AnketaPerson.Inn").SetValue( anketa.NumberVat , font, 10);
            form.GetField("AnketaCompany.numberVAT").SetValue( anketa.NumberVat == "1" ? "Платник" : "Не Платник" , font, 10);
            form.GetField("Employee.Email").SetValue( relEmployy.Empl.Email , font, 10);



            form.FlattenFields();
            doc.Close();

            return dest;
        }
    }
}
