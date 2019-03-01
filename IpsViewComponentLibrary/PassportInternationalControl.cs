using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary
{
    public partial class PassportInternationalControl : UserControl
    {
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsAnketaPerson.DataSource;
            set
            {
                if (bsAnketaPerson.DataSource != value)
                    bsAnketaPerson.DataSource = value;
            }
        }

        public PassportInternationalControl()
        {
            InitializeComponent();
            dtIssuedDate.SetUserCalendarSettingsm();
            dtValidityDate.SetUserCalendarSettingsm();
        }
    }
}
