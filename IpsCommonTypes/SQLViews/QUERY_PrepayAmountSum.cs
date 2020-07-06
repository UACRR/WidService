using System;
using System.Collections.Generic;
using System.Text;

namespace IpsCommonTypes.SQLViews
{
    public class QUERY_RegisterPrepayAmountSum
    {
        public int CustId { get; set; }
        public int LicId { get; set; }
        public int PeriodId { get; set; }
        public decimal PrepayAmountSum { get; set; }
    }
}
