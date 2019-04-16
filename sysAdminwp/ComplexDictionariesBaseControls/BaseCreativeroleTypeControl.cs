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
    public partial class BaseCreativeroleTypeControl : UserControl
    {
        //Uk data item
        CreativeRoleTypeTr ukCreativeroleType;
        //Ru data item
        CreativeRoleTypeTr ruCreativeroleType;
        //En data item
        CreativeRoleTypeTr enCreativeroleType;
        //data grid
        List<CreativeRoleType> _creativeroleTypeList;
        //item data
        CreativeRoleType creativeroleTypeData;
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
            //initialize connector
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchCreativeroleType.SetUsageGrid(gridCreativeroleTypeList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterCreativeroleType.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            bsSimpleDictCreativeRoleType.DataSource = ddlFilterCreativeroleType.DataSource;
            //save url for filter data into grid
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridCreativeroleTypeList.DataSource = HandleDataForGrid(urlForComplexDict);
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
            _creativeroleTypeList = _connector.GetList<CreativeRoleType>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _creativeroleTypeList)
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
            //show current count elements into grid
            totalCreativeroleType.Text = _creativeroleTypeList.Count.ToString();
            return dataGrid;
        }

        //handle data for drop down list - 'Спосіб використання'
        private List<DictBaseTypeI> InitializeDataForFilter()
        {
            //define for result data
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
            var @curRow = rowDetail.DataBoundItem as ViewTable;
            //stop perform if data is not exist
            if (@curRow == null) return;
            //check field 'Code' on correct type 'int'
            if (!int.TryParse(@curRow.Code, out int code)) return;
            //save value 'code' -> fr refresh data when 'Cancel' action
            codeForRefresh = _creativeroleTypeList.FindIndex(el => el.CodeI == code);
            //update data for bottom panel
            DataUpdateForBottomPanel();
        }

        //refresh changed data for bottom panel
        private void DataUpdateForBottomPanel()
        {
            DictionaryService dictService = new DictionaryService();
            //set default first item of the grid
            if (codeForRefresh == 0) codeForRefresh = _creativeroleTypeList[0].CodeI;
            CreativeRoleType item = _creativeroleTypeList[codeForRefresh];
            //get object by parameter 'code' from service
            creativeroleTypeData = dictService.GetCreativeRoleType(item.CodeI);
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
            //initialzie empty data for result
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            _creativeroleTypeList = _connector.GetList<CreativeRoleType>(urlDataGrid);
            //stop perform if data is not exist
            if (_creativeroleTypeList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            _creativeroleTypeList = _creativeroleTypeList.Where(item => item.CategoryCode == code).ToList();
            //initialize data for grid
            foreach (var item in _creativeroleTypeList)
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
            //show current count elements into grid
            totalCreativeroleType.Text = _creativeroleTypeList.Count.ToString();
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveCreativeroleType.Text = "Додати";
            //clear data into bottom panel
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
            CreativeRoleType item = _creativeroleTypeList[codeForRefresh];
            bool result = dictService.DeleteCreativeRoleType(item.CodeI);
            //update data for grid
            gridCreativeroleTypeList.DataSource = HandleDataForGrid(urlDataGrid);
            DataUpdateForBottomPanel();
            gridCreativeroleTypeList.CurrentRow = gridCreativeroleTypeList.Rows[codeForRefresh];
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            //for save last index selected item
            int current = 0;

            DictionaryService dictService = new DictionaryService();
            if (btnSaveCreativeroleType.Text == "Додати")
            {
                
                //send created object
                var result = dictService.CreateCreativeRoleType(creativeroleTypeData);
                //set default state for 'Text' of the btnSave
                btnSaveCreativeroleType.Text = "Зберегти";
                //save last selected item
                //current = gridCreativeroleTypeList.CurrentRow.Index;
                //update data for grid
                gridCreativeroleTypeList.DataSource = HandleDataForGrid(urlDataGrid);
                int newPosition = _creativeroleTypeList.FindIndex(el => el.CodeI == result.CodeI);
                //select certain item into grid
                gridCreativeroleTypeList.CurrentRow = gridCreativeroleTypeList.Rows[newPosition];
            } else if (btnSaveCreativeroleType.Text == "Зберегти")
            {
                //save changes
                CreativeRoleType result = dictService.UpdateCreativeRoleType(creativeroleTypeData);
                //save last selected item
                current = gridCreativeroleTypeList.CurrentRow.Index;
                //update data for grid
                gridCreativeroleTypeList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridCreativeroleTypeList.CurrentRow = gridCreativeroleTypeList.Rows[current];
            }
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
            //if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            //{
            //    if (btnSaveCreativeroleType.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveCreativeroleType.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
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

        //changed data of the field 'Ru'
        private void bindingSourceRu_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            //if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            //{
            //    if (btnSaveCreativeroleType.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveCreativeroleType.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

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

        //changed data of the field 'En'
        private void bindingSourceEn_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            //if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            //{
            //    if (btnSaveCreativeroleType.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveCreativeroleType.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

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
        /// event for field 'Code' and for dropDownList (bottom panel)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dsCopyrightKind_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            //if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            //{
            //    if (btnSaveCreativeroleType.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveCreativeroleType.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void ddlEditKeyCreativeroleType_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            //if (btnSaveCreativeroleType.Text != "Додати")
            //{
            //    //change property 'Text' of the btnSave for 'Save' action
            //    btnSaveCreativeroleType.Text = "Зберегти";
            //}
            ////stop perform if elements have 'Enabled' -> false
            //if (!ControlEnabledActiveElements) return;
            ////change 'Enabled' state for elements
            //ControlEnabledActiveElements = false;
        }

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

        //allow input only number data
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
