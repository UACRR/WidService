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
        public static string GetPdf( Customer cust )
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            var sors = Path.Combine(currentDir, "PDF", "Litsenziyniy-dogovir-z-tsirkami-yak-mayut-statsionarniy-maydanchik1.pdf");
            var dest = Path.Combine(currentDir, "PDF", "OutDocument.pdf");

            PdfDocument doc =  new PdfDocument( new PdfReader(sors)
                                    , new PdfWriter(dest));

            PdfAcroForm form = PdfAcroForm.GetAcroForm(doc, true);
            string FONT = "c:/Windows/Fonts/Arial.ttf";
            PdfFont font = PdfFontFactory.CreateFont(FONT, "Cp1251", true);

            var license = cust.Client.LicenseAgreement.Where(rec => rec.LicStatus < 4).FirstOrDefault();
            
            form.GetField("Title").SetValue(license.Agr.AgrNumber, font, 10);
            form.FlattenFields();
            doc.Close();

            return dest;
        }
    }
}
