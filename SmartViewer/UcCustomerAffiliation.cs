using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartViewer
{
    public partial class UcCustomerAffiliation : UserControl
    {
        private bool _isDirty;

        public UcCustomerAffiliation()
        {
            InitializeComponent();
        }

        private void UcCustomerAffiliation_Load(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void Configure()
        {
            ucListViewBase.SqlSelect = @"
                select
	                  concat(t2.Name, ' (', t2.CustId	, ')') as [Правовласник]
	                , t2.Socs                                as [Товариства правовласника]
	                , t3.Name                                as [Афілійований видавець]
	                , t3.Socs                                as [Товариства видавця]
                from RelSubPublish t1
	                join vCustomerSocs t2 on t1.CustIdPub = t2.CustId
	                join vCustomerSocs t3 on t1.CustIdSub = t3.CustId
                where getdate() between t1.dateBegin and t1.dateEnd
                order by t2.Name, t3.Name
            ";
        }

        public void UpdateContent()
        {
            if(!_isDirty) return;

            ucListViewBase.UpdateContent();
        }
    }
}
