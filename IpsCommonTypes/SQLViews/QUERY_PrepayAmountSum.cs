using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpsCommonTypes.SQLViews
{
    [NotMapped]
    public class QUERY_RegisterPrepayAmountSum
    {
        public int CustId { get; set; }
        public int LicId { get; set; }
        public int PeriodId { get; set; }
        public decimal PrepayAmountSum { get; set; }
    }
}
