using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class UcCcidInvoiceTestDetails17 : UserControl
    {
        private static string sql = @"
drop table if exists #WrongAuthors
select distinct t1.CustId, t2.ShortName, t1.PerSoc, t1.MecSoc --, t5.shortName, t6.shortName
into #WrongAuthors
from ddex..DdexReportAuthors t1
	join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
where DdexReportId = 457
	and t1.CustId is not null
	and (
			PerSoc is not null
		and PerSoc not in (99, 140)
		and PerSocShr > 0
		or
			MecSoc is not null
		and MecSoc not in (99, 140)
		and MecSocShr > 0
	)
	and IpBaseNr is null
order by t1.CustId

select *
from #WrongAuthors t1
	join MediaService..Community t2 on t1.PerSoc = t2.interCode
	join MediaService..vCustomerNamesShort t3 on t2.CustId = t3.CustId
	join MediaService..Community t4 on t1.MecSoc = t4.interCode
	join MediaService..vCustomerNamesShort t5 on t4.CustId = t5.CustId
        ";
        public UcCcidInvoiceTestDetails17()
        {
            InitializeComponent();
        }
    }
}
