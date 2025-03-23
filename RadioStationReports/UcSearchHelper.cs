using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public class UcSearchHelper
    {
        private List<UcSearch.FoundWork> _foundWorks;
        private List<string> _fragments;
       
        public UcSearchHelper(List<UcSearch.FoundWork> foundWorks, List<string> fragments)
        {
            _foundWorks = foundWorks;
            _fragments = fragments;
        }

        private string FormatFragments(string text)
        {
            var retVal = text;
            _fragments.ForEach(x =>
            {
                retVal = retVal.Replace(x, $"<span>{x}</span>", StringComparison.OrdinalIgnoreCase);
            });
            return retVal;
        }

        public string GetRow(UcSearch.FoundWork rec)
        {
            return $@"
                <tr>
                    <td>{rec.Code}</td>
                    <td>{rec.Name}</td>
                    <td>{rec.Authors}</td>
                    <td>{FormatFragments(rec.Performers)}</td>
                    <td><button>Застосувати</button></td>
                </tr>
            ";
        }

        public string GetRows()
        {
            var sw = new StringWriter();
            _foundWorks.ForEach(x =>
            {
                sw.WriteLine(GetRow(x));
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
                            border: 1px solid #dddddd;
                        }}

                        td, th {{
                            border: 1px solid #dddddd;
                            text-align: left;
                            padding: 4px;
                            }}

                        span {{
                            font-weight: bold;
                            border: black;
                            background-color: LightSeaGreen;
                            color: white;
                            padding-left: 5px;
                            padding-right: 5px;
                            }}
                    </style>
                </head>
                <body>
                    <table>
                        <tr>
                            <th>Код</th>
                            <th>Назва</th>
                            <th>Автори</th>
                            <th>Виконавці</th>
                            <th>Вибір</th>
                        </tr>
                        {GetRows()}
                    </table>
                </body>
                </html>
            ";
        }
    }
}
