using RightholderWorkplaceSeparateForm.Rightholder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace RightholderWorkplaceSeparateForm
{
    public partial class MainView : Telerik.WinControls.UI.RadForm
    {
        public MainView()
        {
            InitializeComponent();
        }

        private MainViewPresenter _presenter;
        public MainViewPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        public void Run()
        {
            Application.Run(this);
        }

        public void ShowRightholders()
        {
            var rightholdersView = _presenter.GetRightHoldersView();

            rightholderPanel.Controls.Clear();
            rightholderPanel.Controls.Add(rightholdersView);

            mainPageView.SelectedPage = mainPageRightholders;
        }
    }
}
