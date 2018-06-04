using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public partial class RightholderListView : Telerik.WinControls.UI.RadForm
    {
        public RightholderListView()
        {
            InitializeComponent();

            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private RightholderListViewPresenter _presenter;
        public RightholderListViewPresenter Presenter
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
            Show();
        }

        private void miAddRightholderPerson_Click(object sender, EventArgs e)
        {
            var rightholderItemView = new RightholderItemView();
            rightholderItemView.TopLevel = false;
            rightholderItemView.Dock = DockStyle.Fill;
        }
    }
}
