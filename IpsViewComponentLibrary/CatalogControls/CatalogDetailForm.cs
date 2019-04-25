using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogDetailForm : Telerik.WinControls.UI.RadForm
    {
        public CatalogDetailForm(CatalogFile file)
        {
            InitializeComponent();
            CatalogShowEdition show = new CatalogShowEdition(file);
            Controls.Add(show);
        }
    }
}
