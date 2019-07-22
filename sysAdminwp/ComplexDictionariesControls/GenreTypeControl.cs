using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using sysAdminwp.Model;
using sysAdminwp.PresenterComplexDictionaries.DefineComplexLayers;
using Telerik.WinControls.UI;
using WebAPIConnector;
using static sysAdminwp.Model.DictionaryConstants;

namespace sysAdminwp.ComplexDictionariesControls
{
    public sealed partial class GenreTypeControl : UserControl
    {
        private readonly DictionaryService _service = DictionaryService.GetInstance();

        private bool _subscribedEvents;
        private string Url { get; set; }
        private SaveMode SaveMode { get; set; } = SaveMode.None;

        private List<GenreType> _genreTypeList = new List<GenreType>();
        private GenreType _genreTypeData = new GenreType();

        private bool _isEditMode = true;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = !value;
                //'search' element
                ctrlSearch.Enabled = !value;
                //filter for grid
                ddlFilterCategory.Enabled = !value;
                //grid element
                gvGenreType.Enabled = !value;
                //'Add' button
                btnAddGenreType.Enabled = !value;
                //'Delete' button
                btnDeleteGenreType.Enabled = !value;
                //'Save' button (bottom panel)
                btnSaveGenreType.Enabled = value;
                //'Cancel' button (bottom panel)
                btnCancelGenreType.Enabled = value;
            }
        }

        public GenreTypeControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            if (IpsGlobal.AnketaDictionaties != null)
            {
                var list = new List<Category>
                {
                    new Category
                    {
                        CodeI = 0,
                        Name = "Всі",
                    }
                };
                list.AddRange(IpsGlobal.ObjectRightDictionaries.category);

                bsDictFilterCategory.DataSource = list;
                bsDictCategory.DataSource = IpsGlobal.ObjectRightDictionaries.category;
            }

            ctrlSearch.SetUsageGrid(gvGenreType);
            ctrlGridRowCount.RadGridViewDataSource = gvGenreType;
            ddlFilterCategory.SelectedValueChanged += ddlFilterCategory_SelectedValueChanged;

            IsEditMode = false;
            ChangeSubscribeEvents();
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

            _genreTypeList = _service.GetExtraDictionaryList<GenreType>(Url);

            bsViewTable.DataSource = ConvertToGridDataList();
            bsViewTable.ResetBindings(false);
        }

        private List<ViewTable> ConvertToGridDataList()
        {
            int categoryCode = ddlFilterCategory.SelectedValue as int? ?? 0;

            var filteredList = categoryCode == 0 ? _genreTypeList : _genreTypeList.Where(rec => rec.CategoryCode == categoryCode).ToList();

            var dataGrid = new List<ViewTable>();

            foreach (var item in filteredList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == UkLang)?.Name ?? item.Name,
                    NameEn = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == EnLang)?.Name,
                    NameRu = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == RuLang)?.Name,
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
            txtCodeGenreType.ReadOnly = false;
            ChangeSubscribeEvents();

            var codeItem = _genreTypeList.Max(rec => rec.CodeI) + 1;
            var codeCategory = IpsGlobal.ObjectRightDictionaries.category.Min(rec => rec.CodeI);

            var genreType = new GenreType
            {
                CodeI = codeItem,
                CategoryCode = codeCategory,
                GenreTypeTr = new ObservableListSource<GenreTypeTr>
                {
                    new GenreTypeTr {CodeI = codeItem, Lang = UkLang},
                    new GenreTypeTr {CodeI = codeItem, Lang = RuLang},
                    new GenreTypeTr {CodeI = codeItem, Lang = EnLang},
                }
            };
            UpdateBottomPanel(genreType);
        }

        // видалити
        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            if (!(gvGenreType.CurrentRow?.DataBoundItem is ViewTable row))
                return;

            if (MessageShow.ConfirmAction(DeleteRecordConfirmMsg) == DialogResult.Yes)
            {
                var result = _service.DeleteExtraDictionaryRecord<GenreType>(int.Parse(row.Code));
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
                if (!CheckForUniqueness(_genreTypeData.CodeI))
                {
                    MessageShow.ShowError(NotUniquenessCodeWarningMsg);
                    return;
                }

                var result = _service.CreateExtraDictionaryRecord(_genreTypeData);
                MessageShow.ShowInfoByResult(SaveNewRecordSuccessMsg, SaveNewRecordErrorMsg, result);

                if (!result)
                    return;

                ddlCategory.Enabled = false;
                txtCodeGenreType.ReadOnly = true;

                // змінити режим збереження перед зміною підписок
                SaveMode = SaveMode.None;
                ChangeSubscribeEvents();
            }
            else if (SaveMode == SaveMode.OnEditExist)
            {
                var result = _service.UpdateExtraDictionaryRecord(_genreTypeData);
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
            return !_genreTypeList.Select(rec => rec.CodeI).ToArray().Contains(code);
        }

        // скасувати
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveMode = SaveMode.None;
            UpdateDataFromServer();
            IsEditMode = false;
            ddlCategory.Enabled = false;
            txtCodeGenreType.ReadOnly = true;
            ChangeSubscribeEvents();
        }

        // реагування на редагування запису
        private void OnBeginEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveMode = SaveMode.OnEditExist;
            IsEditMode = true;
        }

        private void ChangeSubscribeEvents()
        {
            if (SaveMode == SaveMode.OnCreate)
            {
                if (!_subscribedEvents)
                    return;

                txtUkGenreType.KeyPress -= OnBeginEdit_KeyPress;
                txtRuGenreType.KeyPress -= OnBeginEdit_KeyPress;
                txtEnGenreType.KeyPress -= OnBeginEdit_KeyPress;
                _subscribedEvents = false;
            }
            else
            {
                if (_subscribedEvents)
                    return;

                txtUkGenreType.KeyPress += OnBeginEdit_KeyPress;
                txtRuGenreType.KeyPress += OnBeginEdit_KeyPress;
                txtEnGenreType.KeyPress += OnBeginEdit_KeyPress;
                _subscribedEvents = true;
            }
        }

        private void ddlFilterCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            bsViewTable.DataSource = ConvertToGridDataList();
            bsViewTable.ResetBindings(false);
        }

        private void gvGenreType_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is ViewTable currentRow))
                return;

            var genreType = _genreTypeList.SingleOrDefault(rec => rec.CodeI == int.Parse(currentRow.Code));
            UpdateBottomPanel(genreType);
        }

        private void UpdateBottomPanel(GenreType genreType)
        {
            _genreTypeData = genreType;
            bsGenreType.DataSource = genreType;
            bsGenreType.ResetBindings(false);

            if (!(genreType.GenreTypeTr.Any(rec => rec.Lang == UkLang)))
                genreType.GenreTypeTr.Add(new GenreTypeTr { Lang = UkLang, CodeI = genreType.CodeI });

            bsUkLangGenreType.DataSource = genreType.GenreTypeTr.SingleOrDefault(rec => rec.Lang == UkLang);
            bsUkLangGenreType.ResetBindings(false);

            if (!(genreType.GenreTypeTr.Any(rec => rec.Lang == RuLang)))
                genreType.GenreTypeTr.Add(new GenreTypeTr { Lang = RuLang, CodeI = genreType.CodeI });

            bsRuLangGenreType.DataSource = genreType.GenreTypeTr.SingleOrDefault(rec => rec.Lang == RuLang);
            bsRuLangGenreType.ResetBindings(false);

            if (!(genreType.GenreTypeTr.Any(rec => rec.Lang == EnLang)))
                genreType.GenreTypeTr.Add(new GenreTypeTr { Lang = EnLang, CodeI = genreType.CodeI });

            bsEnLangGenreType.DataSource = genreType.GenreTypeTr.SingleOrDefault(rec => rec.Lang == EnLang);
            bsEnLangGenreType.ResetBindings(false);
        }
    }
}
