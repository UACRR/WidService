using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.Common;
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

        private bool _showStatusesGroupBox = false;
        public bool ShowStatusesGroupBox
        {
            get { return _showStatusesGroupBox; }
            set
            {
                _showStatusesGroupBox = value;
                bgbStatuses.Visible = _showStatusesGroupBox;
            }
        }

        public FixationView()
        {
            InitializeComponent();

            ddlUsesType.SetDataSource(IpsGlobal.AnketaDictionaties.usesType);
            ddlStage.SetDataSource(IpsGlobal.AnketaDictionaties.fixStageStatus, "CodeI", "StageName");
            ddlStatus.SetDataSource(IpsGlobal.AnketaDictionaties.fixStageStatus, "CodeI", "StatusName");

            bgbStatuses.Visible = _showStatusesGroupBox;

            bgbStatuses.Buttons.AddButton("Направлене користувачу", FixationStageStatuses.NegotiationBeforeFixationDirectedToConsumer);
            bgbStatuses.Buttons.AddButton("Відмова", FixationStageStatuses.NegotiationBeforeFixationRejected);
            bgbStatuses.Buttons.AddButton("Погоджене", FixationStageStatuses.ClosedAgreedBeforeFixation);
        }
        
        public void Run()
        {
            ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void bgbStatuses_ValueSelected(object sender, ValueSelectedEventArgs e)
        {
            _presenter.SetStatus((FixationStageStatuses)e.Value);
            bsFixation.ResetCurrentItem();
        }
    }
}
