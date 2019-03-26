using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IpsViewComponentLibrary.Utilities;
using PartnersWorkplace.Presenters;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace PartnersWorkplace
{
    public partial class PartnersWorkplace : RadForm
    {
        public PartnersWorkplace()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new IpsUARadGridLocalizationProvider();

            // ReSharper disable once ObjectCreationAsStatement
            new PartnerPresenter(ctrlPartners);
        }
    }
}
