using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexReportActionRegisterErrorsSkip : DdexReportActionBase
    {
        public DdexReportActionRegisterErrorsSkip() { }

        public override string GetDescription() { return "Реєстрація помилок у вхіному файлі для подальшого виправлення - пропущено"; }
    }
}
