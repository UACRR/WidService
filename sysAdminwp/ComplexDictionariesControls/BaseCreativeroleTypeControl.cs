using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using sysAdminwp.Model;
using Telerik.WinControls.UI;
using static sysAdminwp.Model.DictionaryConstants;

namespace sysAdminwp.ComplexDictionariesControls
{
    public sealed partial class BaseCreativeroleTypeControl : UserControl
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
                //filter for grid
                ddlFilterCategory.Enabled = !value;
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

        public BaseCreativeroleTypeControl()
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

        }

        // видалити
        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {

        }

        // зберегти
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        // скасувати
        private void btnCancel_Click(object sender, EventArgs e)
        {

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
