using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestMVCStack.Interface;
using TestMVCStack.Main;

namespace TestMVCStack
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
            var service = new ServiceMain();
            var presenter = new PresenterMain();
            MainView view = new MainView();
            presenter.service = service;
            presenter.View = view;
            presenter.runGrid();

            view.Dock = DockStyle.Fill;
            view.Size = radPanel1.Size;

            radPanel1.Controls.Add(view as Control);

        }
    }
}
