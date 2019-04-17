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

namespace sysAdminwp.ComplexDictionariesBaseControls
{
    public partial class BaseKlr030Control : UserControl
    {
        //define data for different languages
        private KlR030tr ukKlr030;
        private KlR030tr ruKlr030;
        private KlR030tr enKlr030;
        //define grid data
        private List<KlR030> _klr030List;
        public List<KlR030> Klr030List
        {
            get { return _klr030List; }
            set
            {
                if (value != null)
                {
                    _klr030List = value;
                    totalKlr030.Text = _klr030List.Count.ToString();
                }
            }
        }
        //item data
        private KlR030 klr030Data;
        //define connector
        private readonly ApiConnector _connector;
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
                txtSearchKlr030.Enabled = value;
                //filter for grid
                ddlFilterKlr030.Enabled = value;
                //grid element
                gridKlr030List.Enabled = value;
                //'Add' button
                btnAddKlr030.Enabled = value;
                //'Delete' button
                btnDeleteKlr030.Enabled = value;
                //'Save' button (bottom panel)
                btnSaveKlr030.Enabled = !value;
                //'Cancel' button (bottom panel)
                btnCancelKlr030.Enabled = !value;
            }
        }
        public BaseKlr030Control(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchKlr030.SetUsageGrid(gridKlr030List);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterKlr030.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            bsSimpleDictKlr030.DataSource = ddlFilterKlr030.DataSource;
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridKlr030List.DataSource = HandleDataForGrid(urlForComplexDict);
            string codeIDefault = Klr030List[0].R030;
            //set default data for bottom panel
            DataUpdateForBottomPanel(codeIDefault);
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
            Klr030List = _connector.GetList<KlR030>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in Klr030List)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.R030,
                    NameUk = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Uk")?.R030Name ?? item.R030Name,
                    NameRu = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Ru")?.R030Name,
                    NameEn = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "En")?.R030Name,
                    klrCountry = ddlFilterKlr030.Items.First(el => (int)el.Value == item.R031).Text,
                });
            }
            return dataGrid;
        }

        //handle data for drop down list - 'Спосіб використання'
        private List<DictBaseTypeI> InitializeDataForFilter()
        {
            List<DictBaseTypeI> dataDropDownList = new List<DictBaseTypeI>();
            //get data for drop down list
            dataDropDownList = _connector.GetList<DictBaseTypeI>("dictionary/base/Country");
            //check data
            return dataDropDownList != null ? dataDropDownList : new List<DictBaseTypeI>();
        }

        //show data for bottom panel
        private void gvCopyrightKindList_CellClick(object sender, GridViewCellEventArgs e)
        {
            //get id dictionary
            GridViewRowInfo rowDetail = gridKlr030List.CurrentRow;
            //get data of the current row
            ViewTable @curRow = rowDetail.DataBoundItem as ViewTable;
            //stop perform if data is not exist
            if (@curRow == null) return;
            //check field 'Code' on correct type 'int'
            if (!int.TryParse(@curRow.Code, out int code)) return;
            //save value 'code' -> fr refresh data when 'Cancel' action
            var strCode = code.ToString();
            indexSelectedElem = _klr030List.FindIndex(el => el.R030 == strCode);
            //update data for bottom panel
            DataUpdateForBottomPanel(code.ToString());
        }

        //refresh changed data for bottom panel
        private void DataUpdateForBottomPanel(string codeI)
        {
            DictionaryService dictService = new DictionaryService();
            //set default first item of the grid
            //if (codeForRefresh == 0) codeForRefresh = int.TryParse(_klr030List[0].R030, out int code) ? code : 0;
            //KlR030 item = _klr030List[codeForRefresh];
            //get object by parameter 'code' from service
            klr030Data = CheckAfterGetQuery(codeI);
            //use data for binding source
            bsKlr030.DataSource = klr030Data;
            //define binding for source of the 'Uk'
            ukKlr030 = klr030Data.KlR030tr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukKlr030 == null)
            {
                ukKlr030 = new KlR030tr { Lang = "Uk" };
                klr030Data.KlR030tr.Add(ukKlr030);
            }
            bsUkLangKlr030.DataSource = ukKlr030;
            //defined binding for source of the 'Ru'
            ruKlr030 = klr030Data.KlR030tr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruKlr030 == null)
            {
                ruKlr030 = new KlR030tr { Lang = "Ru" };
                klr030Data.KlR030tr.Add(ruKlr030);
            }
            bsRuLangKlr030.DataSource = ruKlr030;
            //define binding for source of the 'En'
            enKlr030 = klr030Data.KlR030tr.FirstOrDefault(rec => rec.Lang == "En");
            if (enKlr030 == null)
            {
                enKlr030 = new KlR030tr { Lang = "En" };
                klr030Data.KlR030tr.Add(enKlr030);
            }
            bsEnLangKlr030.DataSource = enKlr030;
        }

        /// <summary>
        /// //check after 'Get' query
        /// </summary>
        /// <param name="codeI"></param>
        /// <returns></returns>
        private KlR030 CheckAfterGetQuery(string codeI)
        {
            DictionaryService dictService = new DictionaryService();
            KlR030 result = new KlR030();
            try
            {
                if (int.TryParse(codeI, out int code)) 
                    result = dictService.GetKlR030(code);
            }
            catch (Exception exp)
            {
                MessageBox.Show("об'єкт не знайдено");
                //set select first element of grid
                result = Klr030List[0];
            }
            if (result == null)
            {
                MessageBox.Show("об'єкт не знайдено");
                //set select first element of grid
                result = Klr030List[0];
            }
            return result;
        }



        //select item into drop down list for filtered data into grid
        private void ddlCommonKeyData_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //stop perform if position is not exist
            if (e.Position == -1) return;
            //get field 'value' of the current selected item
            int selectedItemData = (int)ddlFilterKlr030.Items[e.Position].Value;
            //set filtered data to grid
            gridKlr030List.DataSource = FilterDataIntoGrid(selectedItemData);
        }

        //filter data for grid
        private List<ViewTable> FilterDataIntoGrid(int code)
        {
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            Klr030List = _connector.GetList<KlR030>(urlDataGrid);
            //stop perform if data is not exist
            if (Klr030List == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            Klr030List = Klr030List.Where(item => item.R031 == code).ToList();
            //initialize data for grid
            foreach (var item in Klr030List)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.R030,
                    NameUk = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Uk")?.R030Name ?? item.R030Name,
                    NameRu = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Ru")?.R030Name,
                    NameEn = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "En")?.R030Name,
                    klrCountry = ddlFilterKlr030.SelectedItem.Text,
                });
            }
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveKlr030.Text = "Додати";
            //refresh data for field 'Code'
            klr030Data = new KlR030 { R031 = 1 };
            bsKlr030.DataSource = klr030Data;
            //refresh data for field 'Uk'
            ukKlr030 = new KlR030tr { Lang = "Uk" };
            klr030Data.KlR030tr.Add(ukKlr030);
            bsUkLangKlr030.DataSource = ukKlr030;
            //refresh data for field 'Ru'
            ruKlr030 = new KlR030tr { Lang = "Ru" };
            klr030Data.KlR030tr.Add(ruKlr030);
            bsRuLangKlr030.DataSource = ruKlr030;
            //refresh data for field 'Ru'
            enKlr030 = new KlR030tr { Lang = "En" };
            klr030Data.KlR030tr.Add(enKlr030);
            bsEnLangKlr030.DataSource = enKlr030;
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
            KlR030 item = Klr030List[indexSelectedElem];
            bool result = CheckAfterDelete((int)item.R031);
            //update data for grid
            gridKlr030List.DataSource = HandleDataForGrid(urlDataGrid);
            //step up in grid position
            if (result) --indexSelectedElem;
            if (indexSelectedElem < 0) indexSelectedElem = 0;
            gridKlr030List.CurrentRow = gridKlr030List.Rows[indexSelectedElem];
            //define new currentRow
            string codeNew = Klr030List[indexSelectedElem].R030;
            DataUpdateForBottomPanel(codeNew);
        }

        /// <summary>
        /// control delete state
        /// </summary>
        /// <param name="codeI"></param>
        /// <returns></returns>
        private bool CheckAfterDelete(int codeI)
        {
            DictionaryService dictService = new DictionaryService();
            bool result;
            try
            {
                result = dictService.DeleteKlR030(codeI);
            }
            catch (Exception exp)
            {
                MessageBox.Show("об'єкт не видалений");
                result = false;
            }
            return result;
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            string codeIAfter = string.Empty;
            if (btnSaveKlr030.Text == "Додати")
            {
                //send created object
                KlR030 result = CheckAfterCreate(klr030Data);
                codeIAfter = result.R030;
                //set default state for 'Text' of the btnSave
                //btnSaveKlr030.Text = "Зберегти";
                //save last selected item
                //current = gridKlr030List.CurrentRow.Index;
                //update data for grid
                gridKlr030List.DataSource = HandleDataForGrid(urlDataGrid);
                indexSelectedElem = Klr030List.FindIndex(el => el.R031 == result.R031);
                //select certain item into grid
                gridKlr030List.CurrentRow = gridKlr030List.Rows[indexSelectedElem];
                btnSaveKlr030.Text = "Зберегти";
            } else if (btnSaveKlr030.Text == "Зберегти")
            {
                //save changes
                KlR030 result = CheckAfterUpdate(klr030Data);
                codeIAfter = result.R030;
                //save last selected item
                indexSelectedElem = gridKlr030List.CurrentRow.Index;
                //update data for grid
                gridKlr030List.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridKlr030List.CurrentRow = gridKlr030List.Rows[indexSelectedElem];
            }
            DataUpdateForBottomPanel(codeIAfter);
            //stop perform if elements have 'Enabled' -> true
            if (ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = true;
        }

        /// <summary>
        /// check result data after 'Create'
        /// </summary>
        /// <param name="createItem"></param>
        /// <returns></returns>
        private KlR030 CheckAfterCreate(KlR030 createItem)
        {
            DictionaryService dictService = new DictionaryService();
            KlR030 result = new KlR030();
            try
            {
                result = dictService.CreateKlR030(createItem);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = Klr030List[0];
            }
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = Klr030List[0];
            }
            return result;
        }

        /// <summary>
        /// check result data after 'Update'
        /// </summary>
        /// <param name="updateItem"></param>
        /// <returns></returns>
        private KlR030 CheckAfterUpdate(KlR030 updateItem)
        {
            DictionaryService dictService = new DictionaryService();
            KlR030 result = new KlR030();
            try
            {
                result = dictService.UpdateKlR030(klr030Data);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = Klr030List[0];
            }
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = Klr030List[0];
            }
            return result;
        }

        //action 'Cancel' reset changed data for selected item
        private void btnCancel_Click(object sender, EventArgs e)
        {
            string codeICurrent = Klr030List[indexSelectedElem].R030;
            //reset changed data
            DataUpdateForBottomPanel(codeICurrent);
            //stop perform if elements have 'Enabled' -> true
            if (ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = true;
        }

        //changed data of the field 'Uk'
        private void bindingSourceUk_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            //if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            //{
            //    if (btnSaveKlr030.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveKlr030.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void txtUkLangKlr030_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveKlr030.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveKlr030.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        //changed data of the field 'Ru'
        private void bindingSourceRu_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            //if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            //{
            //    if (btnSaveKlr030.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveKlr030.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void txtRuLangKlr030_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveKlr030.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveKlr030.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        //changed data of the field 'En'
        private void bindingSourceEn_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            //if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            //{
            //    if (btnSaveKlr030.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveKlr030.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void txtEnLangKlr030_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveKlr030.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveKlr030.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        /// <summary>
        /// event for field 'Code' and for dropDownList (bottom panel)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dsCopyrightKind_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            //if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            //{
            //    if (btnSaveKlr030.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveKlr030.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void ddlEditKeyKlr030_Click(object sender, EventArgs e)
        {
            if (btnSaveKlr030.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveKlr030.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        //allow input only number data
        private void txtCodeKlr030_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it 'number' or 'Backspace' -> allow input
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                if (btnSaveKlr030.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveKlr030.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
                return;
            }
            else
                //disallow input
                e.Handled = true;
        }

        
    }
}
