using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

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

            flowLayoutPanel1.Controls.Add(new RadButton { Text = "Text 1" });
            flowLayoutPanel1.Controls.Add(new RadButton { Text = "Text 2" });
            flowLayoutPanel1.Controls.Add(new RadButton { Text = "Text 3" });
            flowLayoutPanel1.Controls.Add(new RadButton { Text = "Text 4" });
        }
        
        public void Run()
        {
            ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void btnStatusDirected_Click(object sender, EventArgs e)
        {
            _presenter.SetStatus(FixationStageStatuses.NegotiationBeforeFixationDirectedToConsumer);
            bsFixation.ResetCurrentItem();
        }

        private void btnStatusRejected_Click(object sender, EventArgs e)
        {
            _presenter.SetStatus(FixationStageStatuses.NegotiationBeforeFixationRejected);
            bsFixation.ResetCurrentItem();
        }

        private void btnStatusClosed_Click(object sender, EventArgs e)
        {
            _presenter.SetStatus(FixationStageStatuses.ClosedAgreedBeforeFixation);
            bsFixation.ResetCurrentItem();
        }
    }
}
