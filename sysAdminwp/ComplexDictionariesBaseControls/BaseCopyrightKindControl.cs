using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WebAPIConnector;
using ipsFormsDesign.Model;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;

namespace sysAdminwp.ComplexDictionariesBaseControls
{
    public partial class BaseCopyrightKindControl : UserControl
    {
        private readonly DictionaryService _service;
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
                    totalCopyrightKind.Text = _copyrightKindList.Count.ToString();
                    ukCopyrightKind = null;
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
        private bool controlEnabledActiveElements = false;
        public bool ControlEnabledActiveElements
        {
            get { return controlEnabledActiveElements; }
            set
            {
                controlEnabledActiveElements = value;
                //'search' element
                txtSearchCopyrightKind.Enabled = value;
                //filter for grid
                ddlFilterCopyrightKind.Enabled = value;
                //grid element
                gridCopyrightKindList.Enabled = value;
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

        public BaseCopyrightKindControl(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            _connector = connector;
            _service = DictionaryService.GetInstance();

            //setup search posibility for textBox element
            txtSearchCopyrightKind.SetUsageGrid(gridCopyrightKindList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterCopyrightKind.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            bsSimpleDictCopyrightKind.DataSource = ddlFilterCopyrightKind.DataSource;
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridCopyrightKindList.DataSource = HandleDataForGrid(urlForComplexDict);
            int codeDefault = CopyrightKindList[0].CodeI;
            //set default data for bottom panel
            DataUpdateForBottomPanel(codeDefault);
            //set 'Enabled' state by default
            ControlEnabledActiveElements = true;
        }
        
        //handle data for grid
        private List<ViewTable> HandleDataForGrid(string urlForGetDataDictionaries)
        {
            //check on valid state parameter
            if (urlForGetDataDictionaries == null) return new List<ViewTable>();
            List<ViewTable> dataGrid = new List<ViewTable>();
            //get data dictionaries -> for grid
            CopyrightKindList = _connector.GetList<CopyrightKind>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in CopyrightKindList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    VariantUse = ddlFilterCopyrightKind.Items.First(el => (int)el.Value == item.CrGroupCode).Text,
                });
            }
            return dataGrid;
        }

        //handle data for drop down list - 'Спосіб використання'
        private List<DictBaseTypeI> InitializeDataForFilter()
        {
            //get data for drop down list
            var dataDropDownList = _connector.GetList<DictBaseTypeI>("dictionary/base/CrkindGroup");
            //check data
            return dataDropDownList ?? new List<DictBaseTypeI>();
        }

        //show data for bottom panel
        private void gvCopyrightKindList_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(gridCopyrightKindList.CurrentRow.DataBoundItem is ViewTable currentRow))
                return;

            if (!int.TryParse(currentRow.Code, out int code))
                return;
            indexSelectedElem = CopyrightKindList.FindIndex(el => el.CodeI == code);
            DataUpdateForBottomPanel(code);
        }

        //refresh changed data for bottom panel
        private void DataUpdateForBottomPanel(int codeI)
        {
            //DictionaryService dictService = new DictionaryService();
            //get object by parameter 'code' from service
            copyrightKindData = _service.GetCopyrightKind(codeI);
            //use data for binding source
            bsCopyrightKind.DataSource = copyrightKindData;
            //define binding for source of the 'Uk'
            ukCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukCopyrightKind == null)
            {
                ukCopyrightKind = new CopyrightKindTr { Lang = "Uk" };
                copyrightKindData.CopyrightKindTr.Add(ukCopyrightKind);
            }
            bsUkLangCopyrightKind.DataSource = ukCopyrightKind;
            //defined binding for source of the 'Ru'
            ruCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruCopyrightKind == null)
            {
                ruCopyrightKind = new CopyrightKindTr { Lang = "Ru" };
                copyrightKindData.CopyrightKindTr.Add(ruCopyrightKind);
            }
            bsRuLangCopyrightKind.DataSource = ruCopyrightKind;
            //define binding for source of the 'En'
            enCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enCopyrightKind == null)
            {
                enCopyrightKind = new CopyrightKindTr { Lang = "En" };
                copyrightKindData.CopyrightKindTr.Add(enCopyrightKind);
            }
            bsEnLangCopyrightKind.DataSource = enCopyrightKind;
        }

        //check after 'Get' query
        private CopyrightKind CheckAfterGetQuery(int codeI)
        {
            //DictionaryService dictService = new DictionaryService();
            CopyrightKind result = _service.GetCopyrightKind(codeI);
            if (result == null)
            {
                MessageBox.Show("об'єкт не знайдено");
                //set select first element of grid
                result = CopyrightKindList[0];
            }
            return result;
        }

        //select item into drop down list for filtered data into grid
        private void ddlCommonKeyData_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //stop perform if position is not exist
            if (e.Position == -1) return;
            //get field 'value' of the current selected item
            int selectedItemData = (int)ddlFilterCopyrightKind.Items[e.Position].Value;
            //set filtered data to grid
            gridCopyrightKindList.DataSource = FilterDataIntoGrid(selectedItemData);
        }

        //filter data for grid
        private List<ViewTable> FilterDataIntoGrid(int code)
        {
            //initialzie empty data for result
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            CopyrightKindList = _connector.GetList<CopyrightKind>(urlDataGrid);
            //stop perform if data is not exist
            if (CopyrightKindList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            CopyrightKindList = CopyrightKindList.Where(item => item.CrGroupCode == code).ToList();
            //initialize data for grid
            foreach (var item in CopyrightKindList)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    VariantUse = ddlFilterCopyrightKind.SelectedItem.Text,
                });
            }
            return filteredData;
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
            ukCopyrightKind = new CopyrightKindTr { Lang = "Uk" };
            copyrightKindData.CopyrightKindTr.Add(ukCopyrightKind);
            bsUkLangCopyrightKind.DataSource = ukCopyrightKind;
            //refresh data for field 'Ru'
            ruCopyrightKind = new CopyrightKindTr { Lang = "Ru" };
            copyrightKindData.CopyrightKindTr.Add(ruCopyrightKind);
            bsRuLangCopyrightKind.DataSource = ruCopyrightKind;
            //refresh data for field 'Ru'
            enCopyrightKind = new CopyrightKindTr { Lang = "En" };
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
            //DictionaryService dictService = new DictionaryService();
            //delete selected item of grid by field 'Code'
            CopyrightKind item = CopyrightKindList[indexSelectedElem];
            bool result = CheckAfterDelete(item.CodeI);
            //update data for grid
            gridCopyrightKindList.DataSource = HandleDataForGrid(urlDataGrid);

            // TODO: DataSource гріда через BindingSource
            //BindingSource bs = new BindingSource();
            //bs.DataSource = HandleDataForGrid(urlDataGrid);
            //bs.ResetBindings(false);

            //step up in grid position
            if (result) --indexSelectedElem;
            if (indexSelectedElem < 0) indexSelectedElem = 0;
            gridCopyrightKindList.CurrentRow = gridCopyrightKindList.Rows[indexSelectedElem];
            //define new currentRow
            int codeNew = CopyrightKindList[indexSelectedElem].CodeI;
            DataUpdateForBottomPanel(codeNew);
            
        }

        /// <summary>
        /// control delete state
        /// </summary>
        /// <param name="codeI"></param>
        /// <returns></returns>
        private bool CheckAfterDelete(int codeI)
        {
            //DictionaryService dictService = new DictionaryService();
            bool result = _service.DeleteCopyrightKind(codeI);
            if (!result)
            {
                //MessageBox.Show("об'єкт не видалений");
                //MessageShow.ShowInfoByResult("", "", result);
                MessageShow.ShowError("Об'єкт не видалений!");
            }
            return result;
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            //refresh bottom panel
            int codeIAfter = 0;
            if (btnSaveCopyrightKind.Text == "Додати")
            {
                //send created object
                CopyrightKind result = CheckAfterCreate(copyrightKindData);
                codeIAfter = result.CodeI;
                //update data for grid
                gridCopyrightKindList.DataSource = HandleDataForGrid(urlDataGrid);
                indexSelectedElem = CopyrightKindList.FindIndex(el => el.CodeI == result.CodeI);
                //select certain item into grid
                gridCopyrightKindList.CurrentRow = gridCopyrightKindList.Rows[indexSelectedElem];
                //set default state for 'Text' of the btnSave
                btnSaveCopyrightKind.Text = "Зберегти";
            } else if (btnSaveCopyrightKind.Text == "Зберегти")
            {
                //save changes
                CopyrightKind result = CheckAfterUpdate(copyrightKindData);
                codeIAfter = result.CodeI;
                //save last selected item
                indexSelectedElem = gridCopyrightKindList.CurrentRow.Index;
                //update data for grid
                gridCopyrightKindList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridCopyrightKindList.CurrentRow = gridCopyrightKindList.Rows[indexSelectedElem];
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
            //DictionaryService dictService = new DictionaryService();
            CopyrightKind result = new CopyrightKind();
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
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
            //DictionaryService dictService = new DictionaryService();
            CopyrightKind result = new CopyrightKind();
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = CopyrightKindList[0];
            }
            return result;
        }

        //action 'Cancel' reset changed data for selected item
        private void btnCancel_Click(object sender, EventArgs e)
        {
            int codeICurrent = CopyrightKindList[indexSelectedElem].CodeI;
            //reset changed data
            DataUpdateForBottomPanel(codeICurrent);
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
    }
}
