using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Utilities;
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

            gvStorages.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);
            gvFiles.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);

            bgbStatuses.Visible = _showStatusesGroupBox;
        }

        public void SetAvailableStageStatuses(IEnumerable<FixationStageStatuses> stageStatuses)
        {
            bgbStatuses.Buttons.Clear();

            foreach (var ss in stageStatuses)
            {
                bgbStatuses.Buttons.AddButton(EnumUtility.GetDescription(ss), ss);
            }
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

        private void btnAddStorage_Click(object sender, EventArgs e)
        {
            var newRow = gvStorages.Rows.AddNew();
            newRow.Cells["Name"].BeginEdit();
        }

        private void gvStorages_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "DeleteColumn")
            {
                gvStorages.Rows.Remove(gvStorages.CurrentRow);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var newRow = gvFiles.Rows.AddNew();
            newRow.Cells["Name"].BeginEdit();
        }

        private void gvFiles_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "DeleteColumn")
            {
                gvFiles.Rows.Remove(gvFiles.CurrentRow);
            }
        }
    }
}
