using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class NewRightholderExternalForm : RadForm
    {
        public NewRightholderExternalForm()
        {
            InitializeComponent();
            ctrlTabNavigation.SetDefaultState(pageViewExternalRightholder, FLoadType.Create);
            ctelRightLimitationsExternal.IsExternalRightHolder = true;
        }

        public void LoadData(Customer customer)
        {
            ctrlAnketaExternalRightholder.DataSourceRightHolder = customer.RightHolder;
            ctrlAnketaExternalRightholder.DataSourceAnketaExternal = customer.AnketaExternal;
            ctelRightLimitationsExternal.DataSource = customer.RightHolder.TermsOfService.Select(rec => new TermsOfServiceWrapper(rec));
        }
    }
}
