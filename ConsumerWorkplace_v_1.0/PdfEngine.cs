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
        public static string GetPdf(Customer cust, AnketaDictionaties dic)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            var license = cust.Client.LicenseAgreement.Where(rec => rec.LicStatus < 4).FirstOrDefault();
            var agree = license.Agr;
            var licenseParam = license.LicenseAgrParam.Where(rec => rec.LicVersion == license.LicVersion).SingleOrDefault();
            var anketa = cust.Company.AnketaCompany.Where(rec => rec.Version == cust.AnkVersion).SingleOrDefault();
            var relEmployy = cust.Company.RelEmployee.Where(rec => rec.PositionCode == 1).SingleOrDefault();
            var bankAcc = cust.BankAccount.FirstOrDefault();
            var period = dic.period.Where(rec => rec.CodeI == licenseParam.PeriodCode).SingleOrDefault();

            var licTypeDoc = dic.agrLicenseType.SingleOrDefault(rec => rec.CodeI == license.LicCode);
            var sors = Path.Combine(currentDir, "PDF", licTypeDoc?.TemplateName ?? string.Empty);
            var dest = Path.Combine(Path.GetTempPath(), "OutDocument.pdf");

            PdfDocument doc = new PdfDocument(new PdfReader(sors)
                                    , new PdfWriter(dest));

            PdfAcroForm form = PdfAcroForm.GetAcroForm(doc, true);
            string FONT = "c:/Windows/Fonts/Arial.ttf";
            PdfFont font = PdfFontFactory.CreateFont(FONT, "Cp1251", true);

            form.GetField("License.licNum").SetValue(license?.Agr?.AgrNumber, font, 10);
            form.GetField("Date").SetValue(license?.Agr?.AgrDate?.ToString("dd.MM.yyyy") ?? DateTime.Today.ToString("dd.MM.yyyy"), font, 10);
            form.GetField("AnketaCompany.name").SetValue(anketa.Name, font, 10);
            form.GetField("Employee.name").SetValue($"{relEmployy.Empl.LastName} {relEmployy.Empl.FirstName} {relEmployy.Empl.SurName ?? string.Empty }", font, 10);
            form.GetField("RelEmployee.RelDocument").SetValue(relEmployy.RelDocument ?? string.Empty, font, 10);

            var field = form.GetField("LicenseAgreement.rateAmount");
            field?.SetValue(licenseParam.RateAmount?.ToString() ?? "1", font, 10);
            field = form.GetField("LicenseAgreement.minAmount#0");
            field?.SetValue(licenseParam.MinAmount?.ToString() ?? "2 000", font, 10);

            field = form.GetField("LicenseAgreement.minAmount");
            field?.SetValue((licenseParam.MinAmount % 100)?.ToString() ?? "00", font, 10);
            field = form.GetField("Period.name");
            field?.SetValue(period?.Name ?? string.Empty, font, 10);
            field = form.GetField("Period.nameR");
            field?.SetValue(period?.NameR ?? string.Empty, font, 10);
            field = form.GetField("year");
            field?.SetValue(DateTime.Today.Year.ToString(), font, 10);
            field = form.GetField("LicenseAgreement.addRate");
            field?.SetValue(licenseParam.AddRate?.ToString() ?? "5", font, 10);
            field = form.GetField("AnketaPerson.Name");
            field?.SetValue(anketa.Name, font, 10);
            field = form.GetField("AnketaCompany.JaCountry + AnketaCompany.jaRegion + AnketaCompany.JaCity + AnketaCompany.JaAddress");
            field?.SetValue($"{anketa.JaCity} {anketa.JaAddress}", font, 10);
            field = form.GetField("AnketaCompany.faCountry +  AnketaCompany. faRegion + AnketaCompany.faCity + AnketaCompany.faAddress");
            field?.SetValue($"{anketa.FaCity} {anketa.FaAddress}", font, 10);
            field = form.GetField("Employee.PhoneNumber");
            field?.SetValue(relEmployy.Empl.PhoneNumber ?? string.Empty, font, 10);
            field = form.GetField("AnketaCompany.OKPO");
            field?.SetValue(anketa.Okpo ?? string.Empty, font, 10);
            field = form.GetField("BankAccount.mfoName");
            field?.SetValue(bankAcc.MfoName ?? string.Empty, font, 10);
            field = form.GetField("BankAccount.mfo");
            field?.SetValue(bankAcc.Mfo?.ToString() ?? string.Empty, font, 10);
            field = form.GetField("BankAccount.accountNumber");
            field?.SetValue(bankAcc.AccountNumber ?? string.Empty, font, 10);
            field = form.GetField("AnketaCompany.registrNumber");
            field?.SetValue(anketa.RegistrNumber ?? string.Empty, font, 10);
            field = form.GetField("AnketaCompany.registrDate");
            field?.SetValue(anketa.RegistrDate?.ToString() ?? string.Empty, font, 10);
            field = form.GetField("AnketaPerson.Inn");
            field?.SetValue(anketa.NumberVat ?? string.Empty, font, 10);
            field = form.GetField("AnketaCompany.numberVAT");
            field?.SetValue(anketa.TypeVat == 1 ? "Платник" : "Не Платник", font, 10);
            field = form.GetField("Employee.Email");
            field?.SetValue(relEmployy.Empl.Email ?? string.Empty, font, 10);

            form.FlattenFields();
            doc.Close();

            return dest;
        }
    }
}
