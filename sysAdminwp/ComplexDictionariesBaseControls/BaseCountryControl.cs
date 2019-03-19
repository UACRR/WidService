using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPIConnector;
using ipsFormsDesign.Model;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Services;

namespace sysAdminwp.ComplexDictionariesBaseControls
{
    public partial class BaseCountryControl : UserControl
    {
        //Uk data item
        CountryTr ukCountry;
        //Ru data item
        CountryTr ruCountry;
        //En data item
        CountryTr enCountry;
        //data grid
        List<Country> _countryList;
        //item data
        Country countryData;
        //define connector
        private readonly ApiConnector _connector;
        //url for get data to grid
        private readonly string urlDataGrid;
        //value 'code' for refresh data when 'Cancel' action
        private int codeForRefresh;
        //control 'Enabled' state for elements
        private bool controlEnabledActiveElements = false;
        public bool ControlEnabledActiveElements
        {
            get { return controlEnabledActiveElements; }
            set
            {
                controlEnabledActiveElements = value;
                //'search' element
                txtSearchCountry.Enabled = value;
                //filter for grid
                ddlFilterCountry.Enabled = value;
                //grid element
                gridCountryList.Enabled = value;
                //'Add' button
                btnAddCountry.Enabled = value;
                //'Delete' button
                btnDeleteCountry.Enabled = value;
                //'Save' button (bottom panel)
                btnSaveCountry.Enabled = !value;
                //'Cancel' button (bottom panel)
                btnCancelCountry.Enabled = !value;
            }
        }
        public BaseCountryControl(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            //initialize connector
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchCountry.SetUsageGrid(gridCountryList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterCountry.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            bsSimpleDictCountry.DataSource = ddlFilterCountry.DataSource;
            //save url for filter data into grid
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridCountryList.DataSource = HandleDataForGrid(urlForComplexDict);
            //set default data for bottom panel
            DataUpdateForBottomPanel();
            //set 'Enabled' state by default
            ControlEnabledActiveElements = true;
            
        }
        
        //handle data for grid
        private List<ViewTable> HandleDataForGrid(string urlForGetDataDictionaries)
        {
            //result data for initialize to grid
            List<ViewTable> dataGrid = new List<ViewTable>();
            //check on valid state parameter
            if (urlForGetDataDictionaries == null) return dataGrid;
            //get data dictionaries -> for grid
            _countryList = _connector.GetList<Country>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _countryList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CountryCode,
                    NameUk = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Uk")?.CountryName ?? item.CountryName,
                    NameRu = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Ru")?.CountryName,
                    NameEn = item.CountryTr?.SingleOrDefault(i => i?.Lang == "En")?.CountryName,
                    Continent = ddlFilterCountry.Items.First(el => (int)el.Value == item.ContinentCode).Text,
                });
            }
            //show current count elements into grid
            totalCountry.Text = _countryList.Count.ToString();
            return dataGrid;
        }

        //handle data for drop down list - 'Спосіб використання'
        private List<DictBaseTypeI> InitializeDataForFilter()
        {
            //define for result data
            List<DictBaseTypeI> dataDropDownList = new List<DictBaseTypeI>();
            //get data for drop down list
            dataDropDownList = _connector.GetList<DictBaseTypeI>("dictionary/base/Continent");
            //check data
            return dataDropDownList != null ? dataDropDownList : new List<DictBaseTypeI>();
        }

        //show data for bottom panel
        private void gvCopyrightKindList_CellClick(object sender, GridViewCellEventArgs e)
        {
            //get id dictionary
            GridViewRowInfo rowDetail = gridCountryList.CurrentRow;
            //get data of the current row
            var @curRow = rowDetail.DataBoundItem as ViewTable;
            //stop perform if data is not exist
            if (@curRow == null) return;
            //check field 'Code' on correct type 'int'
            if (!int.TryParse(@curRow.Code, out int code)) return;
            //save value 'code' -> fr refresh data when 'Cancel' action
            codeForRefresh = code;
            //update data for bottom panel
            DataUpdateForBottomPanel();
        }

        //refresh changed data for bottom panel
        private void DataUpdateForBottomPanel()
        {
            DictionaryService dictService = new DictionaryService();
            //set default first item of the grid
            if (codeForRefresh == 0) codeForRefresh = _countryList[0].ContinentCode ?? 1;
            //get object by parameter 'code' from service
            countryData = dictService.GetCountry(codeForRefresh);
            //use data for binding source
            bsCountry.DataSource = countryData;
            //define binding for source of the 'Uk'
            ukCountry = countryData.CountryTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukCountry == null)
            {
                ukCountry = new CountryTr { Lang = "Uk" };
                countryData.CountryTr.Add(ukCountry);
            }
            bsUkLangCountry.DataSource = ukCountry;
            //defined binding for source of the 'Ru'
            ruCountry = countryData.CountryTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruCountry == null)
            {
                ruCountry = new CountryTr { Lang = "Ru" };
                countryData.CountryTr.Add(ruCountry);
            }
            bsRuLangCountry.DataSource = ruCountry;
            //define binding for source of the 'En'
            enCountry = countryData.CountryTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enCountry == null)
            {
                enCountry = new CountryTr { Lang = "En" };
                countryData.CountryTr.Add(enCountry);
            }
            bsEnLangCountry.DataSource = enCountry;
        }

        //select item into drop down list for filtered data into grid
        private void ddlCommonKeyData_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //stop perform if position is not exist
            if (e.Position == -1) return;
            //get field 'value' of the current selected item
            int selectedItemData = (int)ddlFilterCountry.Items[e.Position].Value;
            //set filtered data to grid
            gridCountryList.DataSource = FilterDataIntoGrid(selectedItemData);
        }

        //filter data for grid
        private List<ViewTable> FilterDataIntoGrid(int code)
        {
            //initialzie empty data for result
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            _countryList = _connector.GetList<Country>(urlDataGrid);
            //stop perform if data is not exist
            if (_countryList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            _countryList = _countryList.Where(item => item.ContinentCode == code).ToList();
            //initialize data for grid
            foreach (var item in _countryList)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.CountryCode,
                    NameUk = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Uk")?.CountryName ?? item.CountryName,
                    NameRu = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Ru")?.CountryName,
                    NameEn = item.CountryTr?.SingleOrDefault(i => i?.Lang == "En")?.CountryName,
                    Continent = ddlFilterCountry.SelectedItem.Text,
                });
            }
            //show current count elements into grid
            totalCountry.Text = _countryList.Count.ToString();
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveCountry.Text = "Додати";
            //clear data into bottom panel
            //refresh data for field 'Code'
            countryData = new Country();
            bsCountry.DataSource = countryData;
            //refresh data for field 'Uk'
            ukCountry = new CountryTr();
            countryData.CountryTr.Add(ukCountry);
            bsUkLangCountry.DataSource = ukCountry;
            //refresh data for field 'Ru'
            ruCountry = new CountryTr();
            countryData.CountryTr.Add(ruCountry);
            bsRuLangCountry.DataSource = ruCountry;
            //refresh data for field 'Ru'
            enCountry = new CountryTr();
            countryData.CountryTr.Add(enCountry);
            bsEnLangCountry.DataSource = enCountry;
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        //action 'Delete' exist object from grid
        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            DictionaryService dictService = new DictionaryService();
            //delete selected item of grid by field 'Code'
            dictService.DeleteCopyrightKind(codeForRefresh);
            //update data for grid
            gridCountryList.DataSource = HandleDataForGrid(urlDataGrid);
            DataUpdateForBottomPanel();
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            DictionaryService dictService = new DictionaryService();
            if (btnSaveCountry.Text == "Додати")
            {
                //send created object
                var result = dictService.CreateCountry(countryData);
                //set default state for 'Text' of the btnSave
                btnSaveCountry.Text = "Зберегти";
            } else if (btnSaveCountry.Text == "Зберегти")
            {
                //save changes
                var result = dictService.UpdateCountry(countryData);
            }
            //update data for grid
            gridCountryList.DataSource = HandleDataForGrid(urlDataGrid);
            DataUpdateForBottomPanel();
            //stop perform if elements have 'Enabled' -> true
            if (ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = true;
        }

        //action 'Cancel' reset changed data for selected item
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //reset changed data
            DataUpdateForBottomPanel();
            //stop perform if elements have 'Enabled' -> true
            if (ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = true;
        }

        //changed data of the field 'Uk'
        private void bindingSourceUk_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            {
                if (btnSaveCountry.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveCountry.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
        }

        //changed data of the field 'Ru'
        private void bindingSourceRu_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            {
                if (btnSaveCountry.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveCountry.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
        }

        //changed data of the field 'En'
        private void bindingSourceEn_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            {
                if (btnSaveCountry.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveCountry.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
        }

        /// <summary>
        /// event for field 'Code' and for dropDownList (bottom panel)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dsCopyrightKind_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            {
                if (btnSaveCountry.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveCountry.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
        }
        //allow input only number data
        private void txtCodeCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it 'number' or 'Backspace' -> allow input
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else
                //disallow input
                e.Handled = true;
        }
    }
}
