using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderRegisterControls
{
    public partial class RightholderRegisterDetailForm : RadForm
    {
        private CatalogFile _catalogFile;

        public RightholderRegisterDetailForm(CatalogFile file, List<RhcatalogItem> list)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Text = file.FileName;
            _catalogFile = file;

            btnPerform.Enabled = _catalogFile.Status == 1 || _catalogFile.CountOk == 2;

            bsCatalogFile.DataSource = _catalogFile;
            lblStatus.Text = IpsGlobal.ObjectRightDictionaries.catalogStatus
                .SingleOrDefault(rec => rec.CodeI == _catalogFile.Status)?.Name;

            bsRHCatalogItem.DataSource = list;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void btnAuditItems_Click(object sender, EventArgs e)
        {

        }

        private void btnGetExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnPerform_Click(object sender, EventArgs e)
        {

        }
    }
}
