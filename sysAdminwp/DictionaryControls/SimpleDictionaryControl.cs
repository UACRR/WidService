using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using sysAdminwp.Model;
using Telerik.WinControls.UI;

namespace sysAdminwp.DictionaryControls
{
    public partial class SimpleDictionaryControl : UserControl
    {
        private readonly DictionaryService _service;

        private List<DictCategory> _dictionaryCategories;

        private DictBaseTypeI _dictBaseTypeData;
        private List<DictBaseTypeI> _dictBaseTypeList;

        private bool _subscribedEvents;

        /// <summary>
        /// URL довідника
        /// </summary>
        public string Url
        {
            get
            {
                var node = treeViewList.SelectedNode;
                if (node?.Parent == null)
                    return string.Empty;

                var categoryItem = _dictionaryCategories[node.Parent.Index].DicCategoryItems[node.Index];
                if (categoryItem == null)
                    return string.Empty;

                return categoryItem.Url;
            }
        }

        private SaveMode SaveMode { get; set; } = SaveMode.None;

        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = value;
                treeViewList.Enabled = !value;
                txtTreeFilter.Enabled = !value;
                //'search' element
                ctrlSearch.Enabled = !value;
                //grid element
                gvDictionaries.Enabled = !value;
                //'Add' button
                btnAdd.Enabled = !value;
                //'Delete' button
                btnDelete.Enabled = !value;
                //'Save' button (bottom panel)
                btnSave.Enabled = value;
                //'Cancel' button (bottom panel)
                btnCancel.Enabled = value;
            }
        }

        private bool IsDesingMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;

        public SimpleDictionaryControl()
        {
            InitializeComponent();

            if (!IsDesingMode)
                _service = DictionaryService.GetInstance();

            ctrlGridRowCount.RadGridViewDataSource = gvDictionaries;
            ctrlSearch.SetUsageGrid(gvDictionaries);

            IsEditMode = false;
            ChangeSubscribeEvents();
            DataSectionEnabled(false);
            gvDictionaries.SelectionChanged += gvDictionaries_SelectionChanged;
        }

        private void DataSectionEnabled(bool enabled)
        {
            ctrlSearch.Enabled = enabled;
            gvDictionaries.Enabled = enabled;
            btnAdd.Enabled = enabled;
            btnDelete.Enabled = enabled;
            bottomPanel.Enabled = enabled;
        }

        /// <summary>
        /// Передати контролу Url на його дані
        /// </summary>
        /// <param name="dictCategories"></param>
        public void SetDictionaryCategories(List<DictCategory> dictCategories)
        {
            _dictionaryCategories = dictCategories;
            treeViewList.DataSource = _dictionaryCategories;
            treeViewList.ChildMember = "DictCategory\\DicCategoryItems";
            treeViewList.DisplayMember = "Name\\Name";
            UpdateDataFromServer();
        }

        private void UpdateDataFromServer()
        {
            if (string.IsNullOrWhiteSpace(Url))
                return;

            _dictBaseTypeList = _service.GetSimpleDictionaryList(Url);

            gvDictionaries.SelectionChanged -= gvDictionaries_SelectionChanged;
            bsViewTable.DataSource = ConvertToGridDataList();
            gvDictionaries.SelectionChanged += gvDictionaries_SelectionChanged;

            bsViewTable.ResetBindings(false);
        }

        private List<ViewTable> ConvertToGridDataList()
        {
            var dataGrid = new List<ViewTable>();
            foreach (var item in _dictBaseTypeList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.DictTrI?.SingleOrDefault(i => i?.Lang == DictionaryConstants.UkLang)?.Name ?? item.Name,
                    NameEn = item.DictTrI?.SingleOrDefault(i => i?.Lang == DictionaryConstants.EnLang)?.Name,
                    NameRu = item.DictTrI?.SingleOrDefault(i => i?.Lang == DictionaryConstants.RuLang)?.Name,
                });
            }
            if (!dataGrid.Any())
                DataSectionEnabled(false);
            return dataGrid;
        }

        // додати запис
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveMode = SaveMode.OnCreate;
            IsEditMode = true;
            txtCode.ReadOnly = false;
            ChangeSubscribeEvents();

            var codeItem = _dictBaseTypeList.Max(rec => rec.CodeI) + 1;

            var record = new DictBaseTypeI
            {
                CodeI = codeItem,
                DictTrI = new List<DictTrI>
                {
                    new DictTrI {CodeI = codeItem, Lang = DictionaryConstants.UkLang},
                    new DictTrI {CodeI = codeItem, Lang = DictionaryConstants.RuLang},
                    new DictTrI {CodeI = codeItem, Lang = DictionaryConstants.EnLang},
                }
            };

            UpdateBottomPanel(record);
        }

        // видалити запис
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(gvDictionaries.CurrentRow?.DataBoundItem is ViewTable row))
                return;

            if (MessageShow.ConfirmAction(DictionaryConstants.DeleteRecordConfirmMsg) == DialogResult.Yes)
            {
                var result = _service.DeleteSimpleDictionaryRecord(Url, row.Code);
                MessageShow.ShowInfoByResult(DictionaryConstants.DeleteRecordSuccessMsg, DictionaryConstants.DeleteRecordErrorMsg, result);
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
                if (!CheckForUniqueness(_dictBaseTypeData.CodeI))
                {
                    MessageShow.ShowError(DictionaryConstants.NotUniquenessCodeWarningMsg);
                    return;
                }

                var result = _service.CreateSimpleDictionaryRecord(Url, _dictBaseTypeData);
                MessageShow.ShowInfoByResult(DictionaryConstants.SaveNewRecordSuccessMsg, DictionaryConstants.SaveNewRecordErrorMsg, result);

                if (!result)
                    return;

                txtCode.ReadOnly = true;

                // змінити режим збереження перед зміною підписок
                SaveMode = SaveMode.None;
                ChangeSubscribeEvents();
            }
            else if (SaveMode == SaveMode.OnEditExist)
            {
                var result = _service.UpdateSimpleDictionaryRecord(Url, _dictBaseTypeData);
                MessageShow.ShowInfoAfterChanges(result);

                if (!result)
                    return;

                SaveMode = SaveMode.None;
            }

            UpdateDataFromServer();
            IsEditMode = false;
        }

        /// <summary>
        /// Синхронізувати CodeI, Name, NameDescript основної таблиці та Tr-таблиці
        /// </summary>
        private void SyncCodeAndName()
        {

            foreach (var item in _dictBaseTypeData.DictTrI)
                item.CodeI = _dictBaseTypeData.CodeI;

            _dictBaseTypeData.Name = _dictBaseTypeData.DictTrI.SingleOrDefault(rec => rec.Lang == DictionaryConstants.UkLang)?.Name;
        }

        /// <summary>
        /// Перевірити введений код на унікальність
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool CheckForUniqueness(int code)
        {
            // не унікальний якщо такий код є в колекції
            return !_dictBaseTypeList.Select(rec => rec.CodeI).ToArray().Contains(code);
        }

        // скасувати
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveMode = SaveMode.None;
            UpdateDataFromServer();
            IsEditMode = false;
            txtCode.ReadOnly = true;
            ChangeSubscribeEvents();
        }

        // реагування на редагування запису
        private void OnBeginEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveMode = SaveMode.OnEditExist;
            IsEditMode = true;
        }

        /// <summary>
        /// Оновити дані на панелі редагування
        /// </summary>
        /// <param name="dictBaseType"></param>
        private void UpdateBottomPanel(DictBaseTypeI dictBaseType)
        {
            _dictBaseTypeData = dictBaseType;
            bsDictionary.DataSource = dictBaseType;
            bsDictionary.ResetBindings(false);

            if (!(dictBaseType.DictTrI.Any(rec => rec.Lang == DictionaryConstants.UkLang)))
                dictBaseType.DictTrI.Add(new DictTrI { Lang = DictionaryConstants.UkLang, CodeI = dictBaseType.CodeI });

            bsTrUk.DataSource = dictBaseType.DictTrI.SingleOrDefault(rec => rec.Lang == DictionaryConstants.UkLang);
            bsTrUk.ResetBindings(false);

            if (!(dictBaseType.DictTrI.Any(rec => rec.Lang == DictionaryConstants.RuLang)))
                dictBaseType.DictTrI.Add(new DictTrI { Lang = DictionaryConstants.RuLang, CodeI = dictBaseType.CodeI });

            bsTrRu.DataSource = dictBaseType.DictTrI.SingleOrDefault(rec => rec.Lang == DictionaryConstants.RuLang);
            bsTrRu.ResetBindings(false);

            if (!(dictBaseType.DictTrI.Any(rec => rec.Lang == DictionaryConstants.EnLang)))
                dictBaseType.DictTrI.Add(new DictTrI { Lang = DictionaryConstants.EnLang, CodeI = dictBaseType.CodeI });

            bsTrEn.DataSource = dictBaseType.DictTrI.SingleOrDefault(rec => rec.Lang == DictionaryConstants.EnLang);
            bsTrEn.ResetBindings(false);
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

                txtNameUa.KeyPress -= OnBeginEdit_KeyPress;
                txtNameRu.KeyPress -= OnBeginEdit_KeyPress;
                txtNameEn.KeyPress -= OnBeginEdit_KeyPress;
                _subscribedEvents = false;
            }
            else
            {
                if (_subscribedEvents)
                    return;

                txtNameUa.KeyPress += OnBeginEdit_KeyPress;
                txtNameRu.KeyPress += OnBeginEdit_KeyPress;
                txtNameEn.KeyPress += OnBeginEdit_KeyPress;
                _subscribedEvents = true;
            }
        }

        private void treeViewList_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            DataSectionEnabled(true);
            UpdateDataFromServer();
        }

        private void gvDictionaries_SelectionChanged(object sender, EventArgs e)
        {
            if (!(gvDictionaries.CurrentRow?.DataBoundItem is ViewTable currentRow))
                return;

            var copyrightKind = _dictBaseTypeList.SingleOrDefault(rec => rec.CodeI == int.Parse(currentRow.Code));
            UpdateBottomPanel(copyrightKind);
        }
    }
}
