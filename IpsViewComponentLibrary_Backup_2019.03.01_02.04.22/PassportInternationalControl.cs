using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{

    public partial class PassportInternationalControl : UserControl
    {
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return bsAnketaPerson.DataSource; }
            set
            {
                if (bsAnketaPerson.DataSource != value)
                    bsAnketaPerson.DataSource = value;
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get { return bsAnketaPerson.DataMember; }
            set { bsAnketaPerson.DataMember = value; }
        }

        public PassportInternationalControl()
        {
            InitializeComponent();
            dtIssuedDate.SetUserCalendarSettingsm();
            dtValidityDate.SetUserCalendarSettingsm();
        }
    }
}
