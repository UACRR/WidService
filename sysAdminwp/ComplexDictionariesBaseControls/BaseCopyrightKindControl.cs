using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using WebAPIConnector;
using ipsFormsDesign.Model;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using sysAdminwp.PresenterComplexDictionaries.DefineComplexLayers;

namespace sysAdminwp.ComplexDictionariesBaseControls
{
    public sealed partial class BaseCopyrightKindControl : UserControl
    {
        CopyrightKindLayer _layer = new CopyrightKindLayer();
        public delegate CopyrightKind GetDictionaryLayer(int id);
        public delegate CopyrightKind CreateLayer(CopyrightKind sors);
        public delegate CopyrightKind UpdateLayer(CopyrightKind sors);
        public delegate bool DeleteLayer(int id);

        private readonly List<string> Langs = new List<string>
        {
            "Uk", "Ru", "En"
        };

        private const string UkLang = "Uk";
        private const string RuLang = "Ru";
        private const string EnLang = "En";

        private const string DelMess = "Об'єкт не видалений!";
        private const string GetMess = "об'єкт не знайдено";
        private const string CreateMess = "Помилка формату";
        private const string UpdateMess = "Помилка формату";
        private const string UrlBaseDict = "dictionary/base/CrkindGroup";

        private readonly DictionaryService _service = DictionaryService.GetInstance();
        private readonly ApiConnector _connector;

        //define data for different languages
        private CopyrightKindTr ukCopyrightKind;
        private CopyrightKindTr ruCopyrightKind;
        private CopyrightKindTr enCopyrightKind;

        //define grid data
        private List<CopyrightKind> _copyrightKindList;
        public List<CopyrightKind> CopyrightKindList {
            get => _copyrightKindList;
            set
            {
                if (value != null)
                {
                    _copyrightKindList = value;
                }
            }
        }
        //item data
        private CopyrightKind copyrightKindData;
        //url for get data to grid
        private readonly string urlDataGrid;
        //for control current select of grid
        private int indexSelectedElem;
        //control 'Enabled' state for elements
        private bool controlEnabledActiveElements = true;
        public bool ControlEnabledActiveElements
        {
            get => controlEnabledActiveElements;
            set
            {
                controlEnabledActiveElements = value;
                //'search' element
                searchCopyrightKind.Enabled = value;
                //filter for grid
                ddlFilterCopyrightKind.Enabled = value;
                //grid element
                gvCopyrightKindList.Enabled = value;
                //'Add' button
                btnAddCopyrightKind.Enabled = value;
                //'Delete' button
                btnDeleteCopyrightKind.Enabled = value;
                //'Save' button (bottom panel)
                btnSaveCopyrightKind.Enabled = !value;
                //'Cancel' button (bottom panel)
                btnCancelCopyrightKind.Enabled = !value;
            }
        }

        public BaseCopyrightKindControl()
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
            ControlEnabledActiveElements = true;
            ddlFilterCopyrightKind.SelectedValueChanged += ddlFilterCopyrightKind_SelectedValueChanged;
        }

        private string Url { get; set; }

        public void SetDataByDictionaryURL(string url)
        {
            Url = url;
            UpdateDataFromServer();
            bsViewTable.DataSource = ConvertToGridDataList();
            bsViewTable.ResetBindings(false);
        }

        private void UpdateDataFromServer()
        {
            if (string.IsNullOrWhiteSpace(Url))
                return;

            CopyrightKindList = _service.GetCopyrightKindList(Url);
        }

        private List<ViewTable> ConvertToGridDataList(int groupCode = 0)
        {
            var filteredList = groupCode == 0 ? CopyrightKindList : CopyrightKindList.Where(rec => rec.CrGroupCode == groupCode).ToList();

            List<ViewTable> dataGrid = new List<ViewTable>();

            foreach (var item in filteredList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == Langs[0])?.Name ?? item.Name,
                    NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == Langs[1])?.Name,
                    NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == Langs[2])?.Name,
                    VariantUse = ddlFilterCopyrightKind.Items.First(el => (int)el.Value == item.CrGroupCode).Text,
                });
            }
            return dataGrid;
        }

        //handle data for grid
        private List<ViewTable> HandleDataForGrid(string urlForGetDataDictionaries)
        {
            //check on valid state parameter
            if (urlForGetDataDictionaries == null)
                return new List<ViewTable>();

            //get data dictionaries -> for grid
            CopyrightKindList = _connector.GetList<CopyrightKind>(urlForGetDataDictionaries);
            //return if data is not exist
            if (CopyrightKindList == null)
            {
                CopyrightKindList = new List<CopyrightKind>();
                return new List<ViewTable>();
            }
            List<ViewTable> dataGrid = new List<ViewTable>();
            //initialize grid data
            foreach (var item in CopyrightKindList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == Langs[0])?.Name ?? item.Name,
                    NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == Langs[1])?.Name,
                    NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == Langs[2])?.Name,
                    VariantUse = ddlFilterCopyrightKind.Items.First(el => (int)el.Value == item.CrGroupCode).Text,
                });
            }
            return dataGrid;
        }

        /// <summary>
        /// refresh changed data for bottom panel
        /// </summary>
        /// <param name="codeI"></param>
        private void DataUpdateForBottomPanel(int codeI)
        {
            //get object by parameter 'code' from service
            copyrightKindData = CheckAfterGetQuery(codeI);
            //use data for binding source
            bsCopyrightKind.DataSource = copyrightKindData;
            //define binding for source of the 'Uk'
            ukCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == Langs[0]);
            if (ukCopyrightKind == null)
            {
                ukCopyrightKind = new CopyrightKindTr { Lang = Langs[0] };
                copyrightKindData.CopyrightKindTr.Add(ukCopyrightKind);
            }
            bsUkLangCopyrightKind.DataSource = ukCopyrightKind;
            //defined binding for source of the 'Ru'
            ruCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == Langs[1]);
            if (ruCopyrightKind == null)
            {
                ruCopyrightKind = new CopyrightKindTr { Lang = Langs[1] };
                copyrightKindData.CopyrightKindTr.Add(ruCopyrightKind);
            }
            bsRuLangCopyrightKind.DataSource = ruCopyrightKind;
            //define binding for source of the 'En'
            enCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == Langs[2]);
            if (enCopyrightKind == null)
            {
                enCopyrightKind = new CopyrightKindTr { Lang = Langs[2] };
                copyrightKindData.CopyrightKindTr.Add(enCopyrightKind);
            }
            bsEnLangCopyrightKind.DataSource = enCopyrightKind;
        }

        //check after 'Get' query
        private CopyrightKind CheckAfterGetQuery(int codeI)
        {
            GetDictionaryLayer dictDelegat = new GetDictionaryLayer(_layer.GetDictionary);
            CopyrightKind result = dictDelegat(codeI);
            if (result == null)
            {
                MessageShow.ShowError(GetMess);
                //set select first element of grid
                result = CopyrightKindList[0];
            }
            return result;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveCopyrightKind.Text = "Додати";
            //refresh data for field 'Code'
            copyrightKindData = new CopyrightKind { CrGroupCode = 1 };
            bsCopyrightKind.DataSource = copyrightKindData;
            //refresh data for field 'Uk'
            ukCopyrightKind = new CopyrightKindTr { Lang = Langs[0] };
            copyrightKindData.CopyrightKindTr.Add(ukCopyrightKind);
            bsUkLangCopyrightKind.DataSource = ukCopyrightKind;
            //refresh data for field 'Ru'
            ruCopyrightKind = new CopyrightKindTr { Lang = Langs[1] };
            copyrightKindData.CopyrightKindTr.Add(ruCopyrightKind);
            bsRuLangCopyrightKind.DataSource = ruCopyrightKind;
            //refresh data for field 'Ru'
            enCopyrightKind = new CopyrightKindTr { Lang = Langs[2] };
            copyrightKindData.CopyrightKindTr.Add(enCopyrightKind);
            bsEnLangCopyrightKind.DataSource = enCopyrightKind;
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        //action 'Delete' exist object from grid
        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            //return if element by index is not exist
            if (!(CopyrightKindList.Count > indexSelectedElem))
                return;
            //delete selected item of grid by field 'Code'
            CopyrightKind item = CopyrightKindList[indexSelectedElem];
            bool result = CheckAfterDelete(item.CodeI);
            //update data for grid
            gvCopyrightKindList.DataSource = HandleDataForGrid(urlDataGrid);

            // TODO: DataSource гріда через BindingSource
            //BindingSource bs = new BindingSource();
            //bs.DataSource = HandleDataForGrid(urlDataGrid);
            //bs.ResetBindings(false);

            //step up in grid position
            if (result) --indexSelectedElem;
            if (indexSelectedElem < 0) indexSelectedElem = 0;
            gvCopyrightKindList.CurrentRow = gvCopyrightKindList.Rows[indexSelectedElem];
            //define new currentRow
            DataUpdateForBottomPanel(CopyrightKindList[indexSelectedElem].CodeI);
        }

        /// <summary>
        /// control delete state
        /// </summary>
        /// <param name="codeI"></param>
        /// <returns></returns>
        private bool CheckAfterDelete(int codeI)
        {
            DeleteLayer dictDelegat = new DeleteLayer(_layer.Delete);
            bool result = dictDelegat(codeI);
            if (!result)
            {
                //MessageBox.Show("об'єкт не видалений");
                //MessageShow.ShowInfoByResult("", "", result);
                MessageShow.ShowError(DelMess);
            }
            return result;
        }
        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            int codeIAfter = 0;
            if (btnSaveCopyrightKind.Text == "Додати")
            {
                //send created object
                CopyrightKind result = CheckAfterCreate(copyrightKindData);
                codeIAfter = result.CodeI;
                //update data for grid
                gvCopyrightKindList.DataSource = HandleDataForGrid(urlDataGrid);
                indexSelectedElem = CopyrightKindList.FindIndex(el => el.CodeI == result.CodeI);
                //select certain item into grid
                gvCopyrightKindList.CurrentRow = gvCopyrightKindList.Rows[indexSelectedElem];
                //set default state for 'Text' of the btnSave
                btnSaveCopyrightKind.Text = "Зберегти";
            } else if (btnSaveCopyrightKind.Text == "Зберегти")
            {
                //save changes
                CopyrightKind result = CheckAfterUpdate(copyrightKindData);
                codeIAfter = result.CodeI;
                //save last selected item
                indexSelectedElem = gvCopyrightKindList.CurrentRow.Index;
                //update data for grid
                gvCopyrightKindList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gvCopyrightKindList.CurrentRow = gvCopyrightKindList.Rows[indexSelectedElem];
            }
            //update data for bottom panel
            DataUpdateForBottomPanel(codeIAfter);
            //stop perform if elements have 'Enabled' -> true
            if (ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = true;
        }

        private CopyrightKind CheckAfterCreate(CopyrightKind createItem)
        {
            CreateLayer dictDelegat = new CreateLayer(_layer.Create);
            CopyrightKind result = dictDelegat(createItem);
            if (result == null)
            {
                MessageShow.ShowError(CreateMess);
                //select first element of grid by default
                result = CopyrightKindList[0];
            }
            return result;
        }

        /// <summary>
        /// check result data after 'Update'
        /// </summary>
        /// <param name="updateItem"></param>
        /// <returns></returns>
        private CopyrightKind CheckAfterUpdate(CopyrightKind updateItem)
        {
            UpdateLayer dictDelegat = new UpdateLayer(_layer.Update);
            CopyrightKind result = dictDelegat(updateItem);
            if (result == null)
            {
                MessageShow.ShowError(UpdateMess);
                //select first element of grid by default
                result = CopyrightKindList[0];
            }
            return result;
        }

        //action 'Cancel' reset changed data for selected item
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //reset changed data
            DataUpdateForBottomPanel(CopyrightKindList[indexSelectedElem].CodeI);
            //stop perform if elements have 'Enabled' -> true
            if (ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = true;
        }

        /// <summary>
        /// changed data of the field 'Uk'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUaLangCopyrightKind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveCopyrightKind.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveCopyrightKind.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        /// <summary>
        /// changed data of the field 'Ru'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRuLangCopyrightKind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveCopyrightKind.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveCopyrightKind.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        /// <summary>
        /// changed data of the field 'En'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEnLangCopyrightKind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveCopyrightKind.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveCopyrightKind.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        /// <summary>
        /// define hide elements for dropDownList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlEditKeyCopyrightKind_Click(object sender, EventArgs e)
        {
            if (btnSaveCopyrightKind.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveCopyrightKind.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        /// <summary>
        /// allow input only number data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCodeComplex_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it 'number' or 'Backspace' -> allow input
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                if (btnSaveCopyrightKind.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveCopyrightKind.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements)
                    return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ddlFilterCopyrightKind_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(ddlFilterCopyrightKind.SelectedValue is int groupCode))
                return;

            bsViewTable.DataSource = ConvertToGridDataList(groupCode);
            bsViewTable.ResetBindings(false);
        }

        private void gvCopyrightKindList_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is ViewTable currentRow))
                return;

            var copyrightKind = CopyrightKindList.SingleOrDefault(rec => rec.CodeI == int.Parse(currentRow.Code));
            UpdateBottomPanel(copyrightKind);
        }

        private void UpdateBottomPanel(CopyrightKind copyrightKind)
        {
            bsCopyrightKind.DataSource = copyrightKind;
            bsCopyrightKind.ResetBindings(false);

            bsUkLangCopyrightKind.DataSource = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == UkLang);
            bsUkLangCopyrightKind.ResetBindings(false);

            bsRuLangCopyrightKind.DataSource = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == RuLang);
            bsRuLangCopyrightKind.ResetBindings(false);

            bsEnLangCopyrightKind.DataSource = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == EnLang);
            bsEnLangCopyrightKind.ResetBindings(false);
        }

    }
}
