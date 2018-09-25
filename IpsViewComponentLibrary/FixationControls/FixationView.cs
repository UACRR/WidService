using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.FixationControls
{
    public partial class FixationView : IpsViewComponentLibrary.Common.Form.IpsForm
    {
        private FixationPresenter _presenter;
        public FixationPresenter Presenter
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

        private Fixation _fixation;
        public Fixation Fixation
        {
            get { return _fixation; }
            set
            {
                _fixation = value;
                bsFixation.DataSource = _fixation;
            }
        }

        public FixationView()
        {
            InitializeComponent();
        }

        private void FixationView_Load(object sender, EventArgs e)
        {
            ddlUsesType.SetDataSource(IpsGlobal.AnketaDictionaties.usesType);
        }

        public void Run()
        {
            ShowDialog();
        }
    }
}
