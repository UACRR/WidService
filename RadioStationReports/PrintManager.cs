using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{
    public class PrintManager
    {
        private readonly string[] MonthNames =
        {
            "січень",
            "лютий",
            "березень",
            "квітень",
            "травень",
            "червень",
            "липень",
            "серпень",
            "вересень",
            "жовтень",
            "листопад",
            "грудень",
        };

        private static readonly string PrintTemplate = @"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    .tableWorks {{
                        font-family: arial, sans-serif;
                        font-size: 12px;
                        border-collapse: collapse;
                        width: 100%;
                        border: 2px solid black;
                    }}

                    .thWorks {{
                        border: 1px solid #dddddd;
                        border-bottom: 4px black double;
                        text-align: center;
                        padding: 4px;
                    }}

                    td {{
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

                    .tableSign {{
                        font-family: arial, sans-serif;
                        font-size: 12px;
                        border-collapse: collapse;
                        width: 100%;
                        border: none;
                    }}

                    .tdSign {{
                        border: none;
                        white-space: nowrap;
                        text-align: center;
                        padding-left: 30px;
                        padding-right: 30px;
                    }}
                </style>
            </head>
            <body>
                <div style=""text-align: center""><bold>ЗВІТ</bold></div>
                <div style=""text-align: center""><bold>від користувача {1}</bold></div>
                <div style=""text-align: center""><bold>про використання обєктів авторського права</bold></div>
                <div style=""text-align: center""><bold>на майданчику МОДНИЙ РЕСТОРАН</bold></div>
                <div style=""text-align: center""><bold>за період {2} {3} р. - {4} {5} р.</bold></div>
                <p></p>
                <p></p>
                <p></p>
                <table class=""tableWorks"">
                    <tr>
                        <th class=thWorks>№</th>
                        <th class=thWorks>Назва використаного твору</th>
                        <th class=thWorks>Виконавець  - П.І.Б. виконавця (співвиконавців) або назва колективу виконавців</th>
                        <th class=thWorks style=""width: 60px;"">Автор музики (П.І.Б.)</th>
                        <th class=thWorks style=""width: 60px;"">Автор тексту (П.І.Б.)</th>
                        <th class=thWorks style=""width: 100px;"">Тривалість звучання твору (хвил. сек.)</th>
                        <th class=thWorks style=""width: 100px;"">Кількість публічних сповіщень твору</th>
                        <th class=thWorks style=""width: 100px;"">Загальна Тривалість звучання твору (хвил. сек.)</th>
                    </tr>

                    {0}          
                </table>


                <p></p>
                <p></p>
                <p></p>

                <table class=""tableSign"">
                    <tr>
                        <td class=""tdSign"">
                            <div style=""margin-top: 10px;"">Від ГО УААСП</div>
                            <div style=""margin-top: 10px;"">директор</div>
                            <div style=""margin-top: 10px;"">Сергій ШАПОВАЛ</div>
                            <div style=""margin-top: 10px;"">24 серпня 2024 р.</div>
                        </td>
                        <td class=""tdSign"" style=""width: 100%;"">
                        </td>
                        <td class=""tdSign"">
                            <div style=""margin-top: 10px;"">Від користувача</div>
                            <div style=""margin-top: 10px;"">керівник відділу роялті</div>
                            <div style=""margin-top: 10px;"">Alice COOPER</div>
                            <div style=""margin-top: 10px;"">24 серпня 2024 р.</div>
                        </td>
                    </tr>
                </table>
            </body>
            </html>
        ";

        private Report _report;
        public PrintManager(Report report) 
        {
            _report = report;
        }

        private string GetReportLineHtml(SqlDataReader r)
        {
            var idx = 0;
                return $@"
                <tr>
                    <td>{r.GetInt32(idx++)}</td>
                    <td>{r.GetString(idx++)}</td>
                    <td>{r.GetString(idx++)}</td>
                    <td>{r.GetString(idx++)}</td>
                    <td>{r.GetString(idx++)}</td>
                    <td>{r.GetString(idx++)}</td>
                    <td>{r.GetString(idx++)}</td>
                    <td>{r.GetString(idx++)}</td>
                </tr>

            ";
        }

        private string GetReportLinesHtml()
        {
            var sw = new StringWriter();
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select
	                    LineNr
                      , Name
                      , Performer
                      , MusicAuthor
                      , TextAuthor
                      , Duration
                      , CountUses
                      , TotalDuration
                    from ReportLines
                    where ReportId = @reportId
                ";
                cmd.Parameters.AddWithValue("@reportId", _report.Id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        sw.WriteLine(GetReportLineHtml(r));
                    }
                }

            });

            return sw.ToString();
        }

        private string GetMonthName(int? month)
        {
            if(month == null)
            {
                return "<не визначений місяць>";
            }
            else
            {
                return MonthNames[(int)month - 1];
            }
        }

        private string GetYear(int? year)
        {
            if(year == null)
            {
                return "<не визначений рік>";
            }
            else
            {
                return year.ToString();
            }
        }

        private string GetCustomerName(string name)
        {
            if(name == null)
            {
                return "<не визначений користувач>";
            }
            else
            {
                return name;
            }
        }

        public void CreatePrintFile()
        {
            var template = PrintTemplate;
            var htmlText = string.Format(template, 
                GetReportLinesHtml(),
                GetCustomerName(_report.RadioStationName),
                GetMonthName(_report.StartMonth),
                GetYear(_report.StartYear),
                GetMonthName(_report.EndMonth),
                GetYear(_report.EndYear)
            );
            var fileFullName = Path.Combine(Path.GetTempPath(), "RadioStationReportPrintFile.html") + "";
            using (StreamWriter sw = File.CreateText(fileFullName))
            {
                sw.Write(htmlText);
            }
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(fileFullName)
            {
                UseShellExecute = true
            };
            p.Start();
            //File.Delete(fileFullName);
        }
    }
}
