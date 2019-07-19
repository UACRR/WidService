using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using sysAdminwp.Model;
using Telerik.WinControls.UI;
using static sysAdminwp.Model.DictionaryConstants;

namespace sysAdminwp.ComplexDictionariesControls
{
    public sealed partial class RelGenrePercentControl : UserControl
    {
        public const string NotUniquenessRecordWarningMsg = "Запис з таким жанром та кількістю частин/актів вже існує!";
        private readonly DictionaryService _service = DictionaryService.GetInstance();

        private bool _subscribedEvents;
        private string Url { get; set; }
        private SaveMode SaveMode { get; set; } = SaveMode.None;

        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = value;
                //'search' element
                searchCopyrightKind.Enabled = !value;
                //grid element
                gvCopyrightKindList.Enabled = !value;
                //'Add' button
                btnAddCopyrightKind.Enabled = !value;
                //'Delete' button
                btnDeleteCopyrightKind.Enabled = !value;
                //'Save' button (bottom panel)
                btnSaveCopyrightKind.Enabled = value;
                //'Cancel' button (bottom panel)
                btnCancelCopyrightKind.Enabled = value;
            }
        }

        private List<RelGenrePercent> _relGenrePercentList;
        private RelGenrePercent _relGenrePercentData;

        public RelGenrePercentControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            searchCopyrightKind.SetUsageGrid(gvCopyrightKindList);
            ctrlGridRowCount.RadGridViewDataSource = gvCopyrightKindList;

            if (IpsGlobal.AnketaDictionaties != null)
            {
                bsDictObjAct.DataSource = IpsGlobal.AnketaDictionaties.objAct;
                bsDictGenreType.DataSource = IpsGlobal.AnketaDictionaties.genreType;
            }
        }

        public void SetDataByDictionaryURL(string url)
        {
            Url = url;
            UpdateDataFromServer();
        }

        private void UpdateDataFromServer()
        {
            if (string.IsNullOrWhiteSpace(Url))
                return;

            _relGenrePercentList = _service.GetExtraDictionaryList<RelGenrePercent>(Url);

            bsViewTable.DataSource = ConvertToGridDataList();
            bsViewTable.ResetBindings(false);
        }

        private List<RelGenrePercentViewTable> ConvertToGridDataList()
        {
            var gridList = new List<RelGenrePercentViewTable>();
            foreach (var relGenrePercent in _relGenrePercentList)
            {
                gridList.Add(new RelGenrePercentViewTable
                {
                    GenreType = relGenrePercent.GenreType,
                    ActCode = relGenrePercent.ActCode,
                    Rate = relGenrePercent.Rate,
                    GenreName = IpsGlobal.AnketaDictionaties.genreType?.SingleOrDefault(rec => rec.CodeI == relGenrePercent.GenreType)?.Name,
                    ObjActName = IpsGlobal.AnketaDictionaties.objAct?.SingleOrDefault(rec => rec.CodeI == relGenrePercent.ActCode)?.Name,
                });
            }

            return gridList;
        }

        private void UpdateBottomPanel(RelGenrePercent relGenrePercent)
        {
            _relGenrePercentData = relGenrePercent;
            bsRelGenrePercent.DataSource = relGenrePercent;
            bsRelGenrePercent.ResetBindings(false);
        }

        private void gvCopyrightKindList_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is RelGenrePercentViewTable row))
                return;

            var relGenrePercent = _relGenrePercentList.SingleOrDefault(rec => rec.GenreType == row.GenreType && rec.ActCode == row.ActCode);
            UpdateBottomPanel(relGenrePercent);
        }

        private void btnAddCopyrightKind_Click(object sender, System.EventArgs e)
        {
            SaveMode = SaveMode.OnCreate;
            IsEditMode = true;
            ddlObjAct.Enabled = true;
            ddlGenre.Enabled = true;

            var relGenrePercent = new RelGenrePercent
            {
                ActCode = IpsGlobal.AnketaDictionaties.objAct.Min(rec => rec.CodeI),
                GenreType = IpsGlobal.AnketaDictionaties.genreType.Min(rec => rec.CodeI),
                Rate = 0m
            };

            UpdateBottomPanel(relGenrePercent);
        }

        private void btnDeleteCopyrightKind_Click(object sender, System.EventArgs e)
        {
            if (!(gvCopyrightKindList.CurrentRow?.DataBoundItem is RelGenrePercentViewTable row))
                return;

            if (MessageShow.ConfirmAction(DeleteRecordConfirmMsg) == DialogResult.Yes)
            {
                //var result = _service.DeleteExtraDictionaryRecord<CopyrightKind>(int.Parse(row.Code));
                MessageShow.ShowInfoByResult(DeleteRecordSuccessMsg, DeleteRecordErrorMsg, result);
                UpdateDataFromServer();
            }
        }

        private void btnSaveCopyrightKind_Click(object sender, System.EventArgs e)
        {
            if (SaveMode == SaveMode.None)
                return;

            if (SaveMode == SaveMode.OnCreate)
            {
                if (!CheckForUniqueness())
                {
                    MessageShow.ShowError(NotUniquenessRecordWarningMsg);
                    return;
                }

                var result = _service.CreateExtraDictionaryRecord(_relGenrePercentData);
                MessageShow.ShowInfoByResult(SaveNewRecordSuccessMsg, SaveNewRecordErrorMsg, result);

                if (!result)
                    return;

                ddlObjAct.Enabled = false;
                ddlGenre.Enabled = false;

                // змінити режим збереження перед зміною підписок
                SaveMode = SaveMode.None;
                ChangeSubscribeEvents();
            }
            else if (SaveMode == SaveMode.OnEditExist)
            {
                var result = _service.UpdateExtraDictionaryRecord(_relGenrePercentData);
                MessageShow.ShowInfoAfterChanges(result);

                if (!result)
                    return;

                SaveMode = SaveMode.None;
            }

            UpdateDataFromServer();
            IsEditMode = false;
        }

        private bool CheckForUniqueness()
        {
            return true;
        }

        private void btnCancelCopyrightKind_Click(object sender, System.EventArgs e)
        {
            SaveMode = SaveMode.None;
            IsEditMode = false;
            ddlObjAct.Enabled = false;
            ddlGenre.Enabled = false;
            UpdateDataFromServer();
            ChangeSubscribeEvents();
        }

        // реагування на редагування запису
        private void OnBeginEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveMode = SaveMode.OnEditExist;
            IsEditMode = true;
        }

        /// <summary>
        /// Змінити реакцію нижньої панелі на редагування/додавання нового запису
        /// </summary>
        private void ChangeSubscribeEvents()
        {
            if (SaveMode == SaveMode.OnCreate)
            {
                if (!_subscribedEvents)
                    return;

                txtRate.KeyPress -= OnBeginEdit_KeyPress;

                _subscribedEvents = false;
            }
            else
            {
                if (_subscribedEvents)
                    return;

                txtRate.KeyPress += OnBeginEdit_KeyPress;

                _subscribedEvents = true;
            }
        }
    }
}
