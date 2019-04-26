using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IpsViewComponentLibrary.CatalogControls.Presenters;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogDetailForm : RadForm
    {
        public CatalogDetailForm(CatalogFile file)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Text = file.FileName;
            ctrlCatalogShowEdition.DataSource = file;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
    }
}
