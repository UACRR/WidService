using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using sysAdminwp.Model;
using Telerik.WinControls.UI;
using static sysAdminwp.Model.DictionaryConstants;

namespace sysAdminwp.ComplexDictionariesControls
{
    public sealed partial class CopyrightKindControl : UserControl
    {
        private readonly DictionaryService _service = DictionaryService.GetInstance();

        private List<CopyrightKind> _copyrightKindList;
        private CopyrightKind _copyrightKindData;

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
                //filter for grid
                ddlFilterCopyrightKind.Enabled = !value;
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

        public CopyrightKindControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            if (IpsGlobal.AnketaDictionaties != null)
            {
                bsDictCRKindGroup.DataSource = IpsGlobal.AnketaDictionaties.crkindGroup;

                var list = new List<CrkindGroup>
                {
                    new CrkindGroup
                    {
                        CodeI = 0,
                        Name = "Всі",
                    }
                };
                list.AddRange(IpsGlobal.AnketaDictionaties.crkindGroup);
                bsFilterDictCRKindGroup.DataSource = list;
            }

            searchCopyrightKind.SetUsageGrid(gvCopyrightKindList);
            ctrlGridRowCount.RadGridViewDataSource = gvCopyrightKindList;
            ddlFilterCopyrightKind.SelectedValueChanged += ddlFilterCopyrightKind_SelectedValueChanged;

            IsEditMode = false;
            ChangeSubscribeEvents();
        }

        /// <summary>
        /// Передати контролу Url на його дані
        /// </summary>
        /// <param name="url"></param>
        public void SetDataByDictionaryURL(string url)
        {
            Url = url;
            UpdateDataFromServer();
        }

        private void UpdateDataFromServer()
        {
            if (string.IsNullOrWhiteSpace(Url))
                return;
            
            _copyrightKindList = _service.GetExtraDictionaryList<CopyrightKind>(Url);

            bsViewTable.DataSource = ConvertToGridDataList();
            bsViewTable.ResetBindings(false);
        }

        private List<ViewTable> ConvertToGridDataList()
        {
            int groupCode = ddlFilterCopyrightKind.SelectedValue as int? ?? 0;

            var filteredList = groupCode == 0 ? _copyrightKindList : _copyrightKindList.Where(rec => rec.CrGroupCode == groupCode).ToList();

            var dataGrid = new List<ViewTable>();

            foreach (var item in filteredList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == UkLang)?.Name ?? item.Name,
                    NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == RuLang)?.Name,
                    NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == EnLang)?.Name,
                });
            }
            return dataGrid;
        }

        // додати запис
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            SaveMode = SaveMode.OnCreate;
            IsEditMode = true;
            ddlCopyrightKind.Enabled = true;
            txtCodeCopyrightKind.ReadOnly = false;
            ChangeSubscribeEvents();

            var codeItem = _copyrightKindList.Max(rec => rec.CodeI) + 1;
            var codeGroup = IpsGlobal.AnketaDictionaties.crkindGroup.Min(rec => rec.CodeI);
            
            var copyrightKind = new CopyrightKind
            {
                CodeI = codeItem,
                CrGroupCode = codeGroup,
                CopyrightKindTr = new ObservableListSource<CopyrightKindTr>
                {
                    new CopyrightKindTr {CodeI = codeItem, Lang = UkLang},
                    new CopyrightKindTr {CodeI = codeItem, Lang = RuLang},
                    new CopyrightKindTr {CodeI = codeItem, Lang = EnLang},
                }
            };
            UpdateBottomPanel(copyrightKind);
        }

        // видалити запис
        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            if (!(gvCopyrightKindList.CurrentRow?.DataBoundItem is ViewTable row))
                return;

            if (MessageShow.ConfirmAction(DeleteRecordConfirmMsg) == DialogResult.Yes)
            {
                var result = _service.DeleteExtraDictionaryRecord<CopyrightKind>(int.Parse(row.Code));
                MessageShow.ShowInfoByResult(DeleteRecordSuccessMsg, DeleteRecordErrorMsg, result);
                UpdateDataFromServer();
            }
        }

        // зберегти
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveMode == SaveMode.None)
                return;

            if (SaveMode == SaveMode.OnCreate)
            {
                if (!CheckForUniqueness(_copyrightKindData.CodeI))
                {
                    MessageShow.ShowError(NotUniquenessCodeWarningMsg);
                    return;
                }

                var result = _service.CreateExtraDictionaryRecord(_copyrightKindData);
                MessageShow.ShowInfoByResult(SaveNewRecordSuccessMsg, SaveNewRecordErrorMsg, result);

                if (!result)
                    return;

                ddlCopyrightKind.Enabled = false;
                txtCodeCopyrightKind.ReadOnly = true;

                // змінити режим збереження перед зміною підписок
                SaveMode = SaveMode.None;
                ChangeSubscribeEvents();
            }
            else if (SaveMode == SaveMode.OnEditExist)
            {
                var result = _service.UpdateExtraDictionaryRecord(_copyrightKindData);
                MessageShow.ShowInfoAfterChanges(result);

                if (!result)
                    return;

                SaveMode = SaveMode.None;
            }

            UpdateDataFromServer();
            IsEditMode = false;
        }

        // скасувати
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveMode = SaveMode.None;
            UpdateDataFromServer();
            IsEditMode = false;
            ddlCopyrightKind.Enabled = false;
            txtCodeCopyrightKind.ReadOnly = true;
            ChangeSubscribeEvents();
        }

        // реагування на редагування запису
        private void OnBeginEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveMode = SaveMode.OnEditExist;
            IsEditMode = true;
        }

        private void ddlFilterCopyrightKind_SelectedValueChanged(object sender, EventArgs e)
        {
            bsViewTable.DataSource = ConvertToGridDataList();
            bsViewTable.ResetBindings(false);
        }

        private void gvCopyrightKindList_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is ViewTable currentRow))
                return;

            var copyrightKind = _copyrightKindList.SingleOrDefault(rec => rec.CodeI == int.Parse(currentRow.Code));
            UpdateBottomPanel(copyrightKind);
        }

        /// <summary>
        /// Перевірити введений код на унікальність
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool CheckForUniqueness(int code)
        {
            // не унікальний якщо такий код є в колекції
            return !_copyrightKindList.Select(rec => rec.CodeI).ToArray().Contains(code);
        }

        /// <summary>
        /// Оновити дані на панелі редагування
        /// </summary>
        /// <param name="copyrightKind"></param>
        private void UpdateBottomPanel(CopyrightKind copyrightKind)
        {
            _copyrightKindData = copyrightKind;
            bsCopyrightKind.DataSource = copyrightKind;
            bsCopyrightKind.ResetBindings(false);

            if (!(copyrightKind.CopyrightKindTr.Any(rec => rec.Lang == UkLang)))
                copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr{Lang = UkLang, CodeI = copyrightKind.CodeI});

            bsUkLangCopyrightKind.DataSource = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == UkLang);
            bsUkLangCopyrightKind.ResetBindings(false);

            if (!(copyrightKind.CopyrightKindTr.Any(rec => rec.Lang == RuLang)))
                copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr { Lang = RuLang, CodeI = copyrightKind.CodeI });

            bsRuLangCopyrightKind.DataSource = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == RuLang);
            bsRuLangCopyrightKind.ResetBindings(false);

            if (!(copyrightKind.CopyrightKindTr.Any(rec => rec.Lang == EnLang)))
                copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr { Lang = EnLang, CodeI = copyrightKind.CodeI });

            bsEnLangCopyrightKind.DataSource = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == EnLang);
            bsEnLangCopyrightKind.ResetBindings(false);
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

                txtUaDescr.KeyPress -= OnBeginEdit_KeyPress;
                txtRuDescr.KeyPress -= OnBeginEdit_KeyPress;
                txtEnDescr.KeyPress -= OnBeginEdit_KeyPress;
                txtRuCopyrightKind.KeyPress -= OnBeginEdit_KeyPress;
                txtUaCopyrightKind.KeyPress -= OnBeginEdit_KeyPress;
                txtEnCopyrightKind.KeyPress -= OnBeginEdit_KeyPress;
                _subscribedEvents = false;
            }
            else
            {
                if (_subscribedEvents)
                    return;

                txtUaDescr.KeyPress += OnBeginEdit_KeyPress;
                txtRuDescr.KeyPress += OnBeginEdit_KeyPress;
                txtEnDescr.KeyPress += OnBeginEdit_KeyPress;
                txtRuCopyrightKind.KeyPress += OnBeginEdit_KeyPress;
                txtUaCopyrightKind.KeyPress += OnBeginEdit_KeyPress;
                txtEnCopyrightKind.KeyPress += OnBeginEdit_KeyPress;
                _subscribedEvents = true;
            }
        }
    }
}
