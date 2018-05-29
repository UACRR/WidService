using ipsFormsDesign.Model;
using iText.Forms;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerWorkplace_v_1._0
{
    public class PdfEngine
    {
        public string GetPdf( Customer cust )
        {
            PdfDocument doc =  new PdfDocument( new PdfReader(@"./PDF/Litsenziyniy-dogovir-z-tsirkami-yak-mayut-statsionarniy-maydanchik1.pdf")
                                    , new PdfWriter(@"./PDF/Document.pdf"));

            PdfAcroForm form = PdfAcroForm.GetAcroForm(doc, true);

            var license = cust.Client.LicenseAgreement.Where(rec => rec.LicStatus < 4).FirstOrDefault();

            form.GetField("Title").SetValue(license.Agr.AgrNumber);
            doc.Close();

            return @"./PDF/Document.pdf";
        }
    }
}
