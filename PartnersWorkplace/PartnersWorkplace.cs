using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PartnersWorkplace.Presenters;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PartnersWorkplace
{
    public partial class PartnersWorkplace : RadForm
    {
        public PartnersWorkplace()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            // ReSharper disable once ObjectCreationAsStatement
            new PartnerPresenter(ctrlPartners);
        }
    }
}
