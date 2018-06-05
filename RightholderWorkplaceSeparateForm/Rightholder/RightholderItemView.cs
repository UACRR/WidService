using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RightholderWorkplaceSeparateForm.Models;
using Telerik.WinControls;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public partial class RightholderItemView : Telerik.WinControls.UI.RadForm
    {
        public RightholderItemView()
        {
            InitializeComponent();

            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private RightholderItemViewPresenter _presenter;
        public RightholderItemViewPresenter Presenter
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

        public RightholderModel Rightholder
        {
            get => rightholderModelBindingSource.Current as RightholderModel;
            set => rightholderModelBindingSource.DataSource = value;
        }

        public void Run()
        {
            Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }
    }
}
