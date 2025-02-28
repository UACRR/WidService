using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DdexInvoicing.UcDspResourceAnalyser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace DdexInvoicing
{
    public class DspResourceAnalyserHelper
    {
        private static string[] colorNames = 
        {
              "Lavender"
            , "PaleGreen"
            , "LightCyan"
            , "PowderBlue"
            , "Cornsilk"
            , "Linen"
            , "Gainsboro"
            , "LightYellow"
            , "PapayaWhip"
            , "Snow"
            , "Snow"
            , "Snow"
            , "Snow"
            , "Snow"
            , "Snow"
            , "Snow"
            , "Snow"
            , "Snow"
            , "Snow"
            , "Snow"
        };
        private UcDspResourceAnalyser.DspResource _dspResource;
       
        public DspResourceAnalyserHelper(UcDspResourceAnalyser.DspResource dspResource)
        {
            _dspResource = dspResource;
        }

        public string GetRow(UcDspResourceAnalyser.DspResourceDetailRecord rec, string color)
        {
            var quarterTxt = rec.Quarter == 0 ? "" : rec.Quarter.ToString();
            var monthTxt = rec.Month == 0 ? "" : rec.Month.ToString();
            var foundCodeTxt = rec.ObjId > 0 ? $"MS-{rec.ObjId}" :
                rec.Wic > 0 ? $"WID-{rec.Wic}" : "";
            return $@"
                <tr>
                    <td style=""background-color:{color}"">{rec.Year}</td>
                    <td style=""background-color:{color}"">{quarterTxt}</td>
                    <td style=""background-color:{color}"">{monthTxt}</td>
                    <td style=""background-color:{color}"">{rec.FileType}</td>
                    <td style=""background-color:{color}"">{rec.ResourceTitle}</td>
                    <td style=""background-color:{color}"">{rec.Title}</td>
                    <td style=""background-color:{color}"">{rec.Authors}</td>
                    <td style=""background-color:{color}"">{rec.Performers}</td>
                    <td style=""background-color:{color}"">{rec.Iswc}</td>
                    <td style=""background-color:{color}"">{foundCodeTxt}</td>
                </tr>
            ";
        }

        public string GetRows()
        {
            var mwIds = _dspResource.Details.Select(x => x.MwId).Distinct().ToList();
            var mwIdColors = new Dictionary<int, string>();
            var idx = 0;
            mwIds.ForEach(x =>
            {
                mwIdColors.Add(x, colorNames[idx++]);
            });
            
            
            var sw = new StringWriter();
            _dspResource.Details.ForEach(x =>
            {
                sw.WriteLine(GetRow(x, mwIdColors[x.MwId]));
            });
            return sw.ToString();
        }

        public string GetHtml()
        {
            return $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{
                            border: 1px solid #dddddd;
                        }}
                        table {{
                            font-family: arial, sans-serif;
                            font-size: 12px;
                            border-collapse: collapse;
                            width: 100%;
                        }}

                        td, th {{
                            border: 1px solid #dddddd;
                            text-align: left;
                            padding: 4px;
                            }}
                    </style>
                </head>
                <body>
                    <table>
                        <tr>
                            <th>Рік</th>
                            <th>Кв</th>
                            <th>Міс</th>
                            <th>Сервіс</th>
                            <th>Альбом</th>
                            <th>Назва твору</th>
                            <th>Автори</th>
                            <th>Виконавці</th>
                            <th>Код Iswc</th>
                            <th>Пов''язаний твір</th>
                        </tr>
                        {GetRows()}
                    </table>
                </body>
                </html>
            ";
        }
    }
}
