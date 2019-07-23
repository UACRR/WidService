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
    public sealed partial class CreativeroleTypeControl : UserControl
    {
        private readonly DictionaryService _service = DictionaryService.GetInstance();
        
        private CreativeRoleType _creativeRoleTypeData = new CreativeRoleType();
        private List<CreativeRoleType> _creativeroleTypeList = new List<CreativeRoleType>();

        private bool _subscribedEvents;

        private string Url { get; set; }
        private SaveMode SaveMode { get; set; } = SaveMode.None;

        //control 'Enabled' state for elements
        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = !value;
                //'search' element
                ctrlSearch.Enabled = !value;
                //filters for grid
                ddlFilterCategory.Enabled = !value;
                ddlFilterCopyrightType.Enabled = !value;
                ddlFilterIsAuthorType.Enabled = !value;
                //grid element
                gvCreativeroleType.Enabled = !value;
                //'Add' button
                btnAddCreativeroleType.Enabled = !value;
                //'Delete' button
                btnDeleteCreativeroleType.Enabled = !value;
                //'Save' button (bottom panel)
                btnSaveCreativeroleType.Enabled = value;
                //'Cancel' button (bottom panel)
                btnCancelCreativeroleType.Enabled = value;
            }
        }

        public CreativeroleTypeControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            if (IpsGlobal.AnketaDictionaties != null)
            {
                var isAuthorType = new List<IsAuthorType>
                {
                    new IsAuthorType
                    {
                        // в довіднику наявний код 0
                        CodeI = -1,
                        Name = "Всі"
                    }
                };
                isAuthorType.AddRange(IpsGlobal.AnketaDictionaties.isAuthorType);

                bsDictFilterIsAuthorType.DataSource = isAuthorType;
                bsDictIsAuthorType.DataSource = IpsGlobal.AnketaDictionaties.isAuthorType;

                var category = new List<Category>
                {
                    new Category
                    {
                        CodeI = -1,
                        Name = "Всі"
                    }
                };
                category.AddRange(IpsGlobal.ObjectRightDictionaries.category);

                bsDictFilterCategory.DataSource = category;
                bsDictCategory.DataSource = IpsGlobal.ObjectRightDictionaries.category;

                var copyrightType = new List<CopyrightType>
                {
                    new CopyrightType
                    {
                        CodeI = -1,
                        Name = "Всі"
                    }
                };
                copyrightType.AddRange(IpsGlobal.AnketaDictionaties.copyrightType);

                bsDictFilterCopyrightType.DataSource = copyrightType;
                bsDictCopyrightType.DataSource = IpsGlobal.AnketaDictionaties.copyrightType;
            }

            ctrlSearch.SetUsageGrid(gvCreativeroleType);
            ctrlGridRowCount.RadGridViewDataSource = gvCreativeroleType;

            ddlFilterCategory.SelectedValueChanged += DdlFilters_SelectedValueChanged;
            ddlFilterCopyrightType.SelectedValueChanged += DdlFilters_SelectedValueChanged;
            ddlFilterIsAuthorType.SelectedValueChanged += DdlFilters_SelectedValueChanged;

            IsEditMode = false;
            ChangeSubscribeEvents();
        }

        private void ChangeSubscribeEvents()
        {
            if (SaveMode == SaveMode.OnCreate)
            {
                if (!_subscribedEvents)
                    return;

                txtUkCreativeroleType.KeyPress -= OnBeginEdit_KeyPress;
                txtRuCreativeroleType.KeyPress -= OnBeginEdit_KeyPress;
                txtEnCreativeroleType.KeyPress -= OnBeginEdit_KeyPress;
                _subscribedEvents = false;
            }
            else
            {
                if (_subscribedEvents)
                    return;

                txtUkCreativeroleType.KeyPress += OnBeginEdit_KeyPress;
                txtRuCreativeroleType.KeyPress += OnBeginEdit_KeyPress;
                txtEnCreativeroleType.KeyPress += OnBeginEdit_KeyPress;
                _subscribedEvents = true;
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

            _creativeroleTypeList = _service.GetExtraDictionaryList<CreativeRoleType>(Url);

            bsViewTable.DataSource = ConvertToGridDataList();
            bsViewTable.ResetBindings(false);
        }

        private List<ViewTable> ConvertToGridDataList()
        {
            int categoryCode = ddlFilterCategory.SelectedValue as int? ?? -1;
            int copyrightTypeCode = ddlFilterCopyrightType.SelectedValue as int? ?? -1;
            int isAuthorTypeCode = ddlFilterIsAuthorType.SelectedValue as int? ?? -1;
            
            var filteredList = categoryCode == 0 ? _creativeroleTypeList : _creativeroleTypeList
                .Where(rec => categoryCode == -1 || rec.CategoryCode == categoryCode)
                .Where(rec => copyrightTypeCode == -1 || rec.Crtype == copyrightTypeCode)
                .Where(rec => isAuthorTypeCode == -1 || rec.IsAuthorType == isAuthorTypeCode)
                .ToList();

            var dataGrid = new List<ViewTable>();

            foreach (var item in filteredList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == UkLang)?.Name ?? item.Name,
                    NameRu = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == RuLang)?.Name,
                    NameEn = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == EnLang)?.Name,
                });
            }
            return dataGrid;
        }

        // додати
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            SaveMode = SaveMode.OnCreate;
            IsEditMode = true;
            ddlCategory.Enabled = true;
            ddlCopyrightType.Enabled = true;
            ddlIsAuthorType.Enabled = true;
            txtCodeCreativeroleType.ReadOnly = false;
            ChangeSubscribeEvents();

            var codeItem = _creativeroleTypeList.Max(rec => rec.CodeI) + 1;
            var categoryCode = IpsGlobal.ObjectRightDictionaries.category.Min(rec => rec.CodeI);
            var isAuthorType = IpsGlobal.AnketaDictionaties.isAuthorType.Min(rec => rec.CodeI);
            var crtype = IpsGlobal.AnketaDictionaties.copyrightType.Min(rec => rec.CodeI);

            var copyrightKind = new CreativeRoleType
            {
                CodeI = codeItem,
                CategoryCode = categoryCode,
                IsAuthorType = isAuthorType,
                Crtype = crtype,
                CreativeRoleTypeTr = new ObservableListSource<CreativeRoleTypeTr>
                {
                    new CreativeRoleTypeTr
                    {
                        Lang = UkLang,
                    },
                    new CreativeRoleTypeTr
                    {
                        Lang = RuLang,
                    },
                    new CreativeRoleTypeTr
                    {
                        Lang = EnLang,
                    }
                }
            };
            UpdateBottomPanel(copyrightKind);
        }

        // видалити
        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            if (!(gvCreativeroleType.CurrentRow?.DataBoundItem is ViewTable row))
                return;

            if (MessageShow.ConfirmAction(DeleteRecordConfirmMsg) == DialogResult.Yes)
            {
                var result = _service.DeleteExtraDictionaryRecord<CreativeRoleType>(int.Parse(row.Code));
                MessageShow.ShowInfoByResult(DeleteRecordSuccessMsg, DeleteRecordErrorMsg, result);
                UpdateDataFromServer();
            }
        }

        // зберегти
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveMode == SaveMode.None)
                return;

            SyncCodeAndName();
            if (SaveMode == SaveMode.OnCreate)
            {
                if (!CheckForUniqueness(_creativeRoleTypeData.CodeI))
                {
                    MessageShow.ShowError(NotUniquenessCodeWarningMsg);
                    return;
                }

                var result = _service.CreateExtraDictionaryRecord(_creativeRoleTypeData);
                MessageShow.ShowInfoByResult(SaveNewRecordSuccessMsg, SaveNewRecordErrorMsg, result);

                if (!result)
                    return;

                ddlCategory.Enabled = false;
                ddlCopyrightType.Enabled = false;
                ddlIsAuthorType.Enabled = false;
                txtCodeCreativeroleType.ReadOnly = true;

                // змінити режим збереження перед зміною підписок
                SaveMode = SaveMode.None;
                ChangeSubscribeEvents();
            }
            else if (SaveMode == SaveMode.OnEditExist)
            {
                var result = _service.UpdateExtraDictionaryRecord(_creativeRoleTypeData);
                MessageShow.ShowInfoAfterChanges(result);

                if (!result)
                    return;

                SaveMode = SaveMode.None;
            }

            UpdateDataFromServer();
            IsEditMode = false;
        }

        /// <summary>
        /// Перевірити введений код на унікальність
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool CheckForUniqueness(int code)
        {
            // не унікальний якщо такий код є в колекції
            return !_creativeroleTypeList.Select(rec => rec.CodeI).ToArray().Contains(code);
        }

        /// <summary>
        /// Синхронізувати CodeI, Name основної таблиці та Tr-таблиці
        /// </summary>
        private void SyncCodeAndName()
        {
            if (SaveMode == SaveMode.OnCreate)
            {
                foreach (var creativeRoleTypeTr in _creativeRoleTypeData.CreativeRoleTypeTr)
                    creativeRoleTypeTr.CodeI = _creativeRoleTypeData.CodeI;
            }

            _creativeRoleTypeData.Name = _creativeRoleTypeData.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == UkLang)?.Name;
        }

        // скасувати
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveMode = SaveMode.None;
            UpdateDataFromServer();
            IsEditMode = false;
            ddlCategory.Enabled = false;
            ddlCopyrightType.Enabled = false;
            ddlIsAuthorType.Enabled = false;
            txtCodeCreativeroleType.ReadOnly = true;
            ChangeSubscribeEvents();
        }

        private void DdlFilters_SelectedValueChanged(object sender, EventArgs e)
        {
            bsViewTable.DataSource = ConvertToGridDataList();
            bsViewTable.ResetBindings(false);
        }

        private void OnBeginEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveMode = SaveMode.OnEditExist;
            IsEditMode = true;
        }

        private void gvCreativeroleType_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is ViewTable currentRow))
                return;

            var copyrightKind = _creativeroleTypeList.SingleOrDefault(rec => rec.CodeI == int.Parse(currentRow.Code));
            UpdateBottomPanel(copyrightKind);
        }

        /// <summary>
        /// Оновити дані на панелі редагування
        /// </summary>
        /// <param name="creativeRoleType"></param>
        private void UpdateBottomPanel(CreativeRoleType creativeRoleType)
        {
            _creativeRoleTypeData = creativeRoleType;
            bsCreativeRoleType.DataSource = creativeRoleType;
            bsCreativeRoleType.ResetBindings(false);

            if (!(creativeRoleType.CreativeRoleTypeTr.Any(rec => rec.Lang == UkLang)))
                creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr { Lang = UkLang, CodeI = creativeRoleType.CodeI });

            bsUkCreativeRoleType.DataSource = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == UkLang);
            bsUkCreativeRoleType.ResetBindings(false);

            if (!(creativeRoleType.CreativeRoleTypeTr.Any(rec => rec.Lang == RuLang)))
                creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr { Lang = RuLang, CodeI = creativeRoleType.CodeI });

            bsRuCreativeRoleType.DataSource = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == RuLang);
            bsRuCreativeRoleType.ResetBindings(false);

            if (!(creativeRoleType.CreativeRoleTypeTr.Any(rec => rec.Lang == EnLang)))
                creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr { Lang = EnLang, CodeI = creativeRoleType.CodeI });

            bsEnCreativeRoleType.DataSource = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == EnLang);
            bsEnCreativeRoleType.ResetBindings(false);
        }
    }
}
