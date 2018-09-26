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

        private bool _showNegotioationStatusGroupBox = false;
        public bool ShowNegotiationStatusGroupBox
        {
            get { return _showNegotioationStatusGroupBox; }
            set
            {
                _showNegotioationStatusGroupBox = value;
                gbNegotiationStatus.Visible = _showNegotioationStatusGroupBox;
            }
        }

        public FixationView()
        {
            InitializeComponent();

            ddlUsesType.SetDataSource(IpsGlobal.AnketaDictionaties.usesType);
            ddlStage.SetDataSource(IpsGlobal.AnketaDictionaties.fixStageStatus, "CodeI", "StageName");
            ddlStatus.SetDataSource(IpsGlobal.AnketaDictionaties.fixStageStatus, "CodeI", "StatusName");
        }
        
        public void Run()
        {
            ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }
    }
}
