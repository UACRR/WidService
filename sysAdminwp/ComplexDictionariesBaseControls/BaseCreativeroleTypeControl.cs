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
    public partial class BaseCreativeroleTypeControl : UserControl
    {
        //define data for differenet languages
        private CreativeRoleTypeTr ukCreativeroleType;
        private CreativeRoleTypeTr ruCreativeroleType;
        private CreativeRoleTypeTr enCreativeroleType;
        //define grid data
        private List<CreativeRoleType> _creativeroleTypeList;
        public List<CreativeRoleType> CreativeroleTypeList {
            get { return _creativeroleTypeList; }
            set { if (value != null)
                {
                    _creativeroleTypeList = value;
                    //show current count elements into grid
                    totalCreativeroleType.Text = _creativeroleTypeList.Count.ToString();
                } }
        }
        //item data
        private CreativeRoleType creativeroleTypeData;
        //define 'Delete', 'Create', 'Update'
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
                txtSearchCreativeroleType.Enabled = value;
                //filter for grid
                ddlFilterCreativeroleType.Enabled = value;
                //grid element
                gridCreativeroleTypeList.Enabled = value;
                //'Add' button
                btnAddCreativeroleType.Enabled = value;
                //'Delete' button
                btnDeleteCreativeroleType.Enabled = value;
                //'Save' button (bottom panel)
                btnSaveCreativeroleType.Enabled = !value;
                //'Cancel' button (bottom panel)
                btnCancelCreativeroleType.Enabled = !value;
            }
        }
        public BaseCreativeroleTypeControl(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchCreativeroleType.SetUsageGrid(gridCreativeroleTypeList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterCreativeroleType.DataSource = InitializeDataForFilter();
            //set data Dictionaries into Edit Panel
            bsSimpleDictCreativeRoleType.DataSource = ddlFilterCreativeroleType.DataSource;
            urlDataGrid = urlForComplexDict;
            //set data to grid
            gridCreativeroleTypeList.DataSource = HandleDataForGrid(urlForComplexDict);
            int codeIDefault = CreativeroleTypeList[0].CodeI;
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
            CreativeroleTypeList = _connector.GetList<CreativeRoleType>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in CreativeroleTypeList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    Category = ddlFilterCreativeroleType.Items.First(el => (int)el.Value == item.CategoryCode).Text,
                });
            }
            return dataGrid;
        }

        //handle data for drop down list - 'Спосіб використання'
        private List<DictBaseTypeI> InitializeDataForFilter()
        {
            List<DictBaseTypeI> dataDropDownList = new List<DictBaseTypeI>();
            //get data for drop down list
            dataDropDownList = _connector.GetList<DictBaseTypeI>("dictionary/base/Category");
            //check data
            return dataDropDownList != null ? dataDropDownList : new List<DictBaseTypeI>();
        }

        //show data for bottom panel
        private void gvCopyrightKindList_CellClick(object sender, GridViewCellEventArgs e)
        {
            //get id dictionary
            GridViewRowInfo rowDetail = gridCreativeroleTypeList.CurrentRow;
            //get data of the current row
            ViewTable @curRow = rowDetail.DataBoundItem as ViewTable;
            //stop perform if data is not exist
            if (@curRow == null) return;
            //check field 'Code' on correct type 'int'
            if (!int.TryParse(@curRow.Code, out int code)) return;
            //get 'CodeI' of current element
            indexSelectedElem = CreativeroleTypeList.FindIndex(item => item.CodeI == code);
            //update data for bottom panel
            DataUpdateForBottomPanel(code);
        }

        //refresh changed data for bottom panel
        private void DataUpdateForBottomPanel(int codeI)
        {
            DictionaryService dictService = new DictionaryService();
            //get object by parameter 'code' from service
            creativeroleTypeData = CheckAfterGetQuery(codeI);
            //use data for binding source
            bsCreativeRoleType.DataSource = creativeroleTypeData;
            //define binding for source of the 'Uk'
            ukCreativeroleType = creativeroleTypeData.CreativeRoleTypeTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukCreativeroleType == null)
            {
                ukCreativeroleType = new CreativeRoleTypeTr { Lang = "Uk" };
                creativeroleTypeData.CreativeRoleTypeTr.Add(ukCreativeroleType);
            }
            bsUkLangCreativeRoleType.DataSource = ukCreativeroleType;
            //defined binding for source of the 'Ru'
            ruCreativeroleType = creativeroleTypeData.CreativeRoleTypeTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruCreativeroleType == null)
            {
                ruCreativeroleType = new CreativeRoleTypeTr { Lang = "Ru" };
                creativeroleTypeData.CreativeRoleTypeTr.Add(ruCreativeroleType);
            }
            bsRuLangCreativeRoleType.DataSource = ruCreativeroleType;
            //define binding for source of the 'En'
            enCreativeroleType = creativeroleTypeData.CreativeRoleTypeTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enCreativeroleType == null)
            {
                enCreativeroleType = new CreativeRoleTypeTr { Lang = "En" };
                creativeroleTypeData.CreativeRoleTypeTr.Add(enCreativeroleType);
            }
            bsEnLangCreativeRoleType.DataSource = enCreativeroleType;
        }

        /// <summary>
        /// //check after 'Get' query
        /// </summary>
        /// <param name="codeI"></param>
        /// <returns></returns>
        private CreativeRoleType CheckAfterGetQuery(int codeI)
        {
            DictionaryService dictService = new DictionaryService();
            CreativeRoleType result = new CreativeRoleType();
            try
            {
                result = dictService.GetCreativeRoleType(codeI);
            } catch (Exception exp)
            {
                MessageBox.Show("об'єкт не знайдено");
                //set select first element of grid
                result = CreativeroleTypeList[0];
            }
            if (result == null)
            {
                MessageBox.Show("об'єкт не знайдено");
                //set select first element of grid
                result = CreativeroleTypeList[0];
            }
            return result;
        }

        //select item into drop down list for filtered data into grid
        private void ddlCommonKeyData_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //stop perform if position is not exist
            if (e.Position == -1) return;
            //get field 'value' of the current selected item
            int selectedItemData = (int)ddlFilterCreativeroleType.Items[e.Position].Value;
            //set filtered data to grid
            gridCreativeroleTypeList.DataSource = FilterDataIntoGrid(selectedItemData);
        }

        //filter data for grid
        private List<ViewTable> FilterDataIntoGrid(int code)
        {
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            CreativeroleTypeList = _connector.GetList<CreativeRoleType>(urlDataGrid);
            //stop perform if data is not exist
            if (CreativeroleTypeList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            CreativeroleTypeList = CreativeroleTypeList.Where(item => item.CategoryCode == code).ToList();
            //initialize data for grid
            foreach (var item in CreativeroleTypeList)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    Category = ddlFilterCreativeroleType.SelectedItem.Text,
                });
            }
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveCreativeroleType.Text = "Додати";
            //refresh data for field 'Code'
            creativeroleTypeData = new CreativeRoleType { Crtype = 1, CategoryCode = 1 };
            bsCreativeRoleType.DataSource = creativeroleTypeData;
            //refresh data for field 'Uk'
            ukCreativeroleType = new CreativeRoleTypeTr { Lang = "Uk" };
            creativeroleTypeData.CreativeRoleTypeTr.Add(ukCreativeroleType);
            bsUkLangCreativeRoleType.DataSource = ukCreativeroleType;
            //refresh data for field 'Ru'
            ruCreativeroleType = new CreativeRoleTypeTr { Lang = "Ru" };
            creativeroleTypeData.CreativeRoleTypeTr.Add(ruCreativeroleType);
            bsRuLangCreativeRoleType.DataSource = ruCreativeroleType;
            //refresh data for field 'Ru'
            enCreativeroleType = new CreativeRoleTypeTr { Lang = "En" };
            creativeroleTypeData.CreativeRoleTypeTr.Add(enCreativeroleType);
            bsEnLangCreativeRoleType.DataSource = enCreativeroleType;
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
            CreativeRoleType item = CreativeroleTypeList[indexSelectedElem];
            bool result = CheckAfterDelete(item.CodeI);
            //update data for grid
            gridCreativeroleTypeList.DataSource = HandleDataForGrid(urlDataGrid);
            //step up in grid position
            if (result) --indexSelectedElem;
            if (indexSelectedElem < 0) indexSelectedElem = 0;
            gridCreativeroleTypeList.CurrentRow = gridCreativeroleTypeList.Rows[indexSelectedElem];
            //define new currentRow
            int codeNew = CreativeroleTypeList[indexSelectedElem].CodeI;
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
                result = dictService.DeleteCreativeRoleType(codeI);
            } catch (Exception exp)
            {
                MessageBox.Show("об'єкт не видалений");
                result = false;
            }
            return result;
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            //refresh bottom panel
            int codeIAfter = 0;
            if (btnSaveCreativeroleType.Text == "Додати")
            {
                //send created object
                CreativeRoleType result = CheckAfterCreate(creativeroleTypeData);
                codeIAfter = result.CodeI;
                //update data for grid
                gridCreativeroleTypeList.DataSource = HandleDataForGrid(urlDataGrid);
                indexSelectedElem = CreativeroleTypeList.FindIndex(el => el.CodeI == result.CodeI);
                //select certain item into grid
                gridCreativeroleTypeList.CurrentRow = gridCreativeroleTypeList.Rows[indexSelectedElem];
                //set default state for 'Text' of the btnSave
                btnSaveCreativeroleType.Text = "Зберегти";
            } else if (btnSaveCreativeroleType.Text == "Зберегти")
            {
                //save changes
                CreativeRoleType result = CheckAfterUpdate(creativeroleTypeData);
                codeIAfter = result.CodeI;
                //save last selected item
                indexSelectedElem = gridCreativeroleTypeList.CurrentRow.Index;
                //update data for grid
                gridCreativeroleTypeList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridCreativeroleTypeList.CurrentRow = gridCreativeroleTypeList.Rows[indexSelectedElem];
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
        private CreativeRoleType CheckAfterCreate(CreativeRoleType createItem)
        {
            DictionaryService dictService = new DictionaryService();
            CreativeRoleType result = new CreativeRoleType();
            try
            {
                result = dictService.CreateCreativeRoleType(createItem);
            } catch (Exception exp)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = CreativeroleTypeList[0];
            }
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = CreativeroleTypeList[0];
            }
            return result;
        }

        /// <summary>
        /// check result data after 'Update'
        /// </summary>
        /// <param name="updateItem"></param>
        /// <returns></returns>
        private CreativeRoleType CheckAfterUpdate(CreativeRoleType updateItem)
        {
            DictionaryService dictService = new DictionaryService();
            CreativeRoleType result = new CreativeRoleType();
            try
            {
                result = dictService.UpdateCreativeRoleType(creativeroleTypeData);
            } catch (Exception exp)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = CreativeroleTypeList[0];
            }
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = CreativeroleTypeList[0];
            }
            return result;
        }

        //action 'Cancel' reset changed data for selected item
        private void btnCancel_Click(object sender, EventArgs e)
        {
            int codeICurrent = CreativeroleTypeList[indexSelectedElem].CodeI;
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
        private void txtUkLangCreativeroleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveCreativeroleType.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveCreativeroleType.Text = "Зберегти";
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
        private void txtRuLangCreativeroleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveCreativeroleType.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveCreativeroleType.Text = "Зберегти";
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
        private void txtEnLangCreativeroleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveCreativeroleType.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveCreativeroleType.Text = "Зберегти";
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
        private void ddlEditKeyCreativeroleType_Click(object sender, EventArgs e)
        {
            if (btnSaveCreativeroleType.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveCreativeroleType.Text = "Зберегти";
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
        private void txtCodeCreativeroleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it 'number' or 'Backspace' -> allow input
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                if (btnSaveCreativeroleType.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveCreativeroleType.Text = "Зберегти";
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
