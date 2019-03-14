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
        CopyrightKindTr ukCreativeroleType;
        //Ru data item
        CopyrightKindTr ruCreativeroleType;
        //En data item
        CopyrightKindTr enCreativeroleType;
        //data grid
        List<CopyrightKind> _creativeroleTypeList;
        //item data
        CopyrightKind creativeroleTypeData;
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
                txtSearchComplex.Enabled = value;
                //filter for grid
                ddlCommonKeyData.Enabled = value;
                //grid element
                gvCopyrightKindList.Enabled = value;
                //'Add' button
                btnAddComplex.Enabled = value;
                //'Delete' button
                btnDeleteComplex.Enabled = value;
                //'Save' button (bottom panel)
                btnSave.Enabled = !value;
                //'Cancel' button (bottom panel)
                btnCancel.Enabled = !value;
            }
        }
        public BaseCreativeroleTypeControl(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            //initialize connector
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchComplex.SetUsageGrid(gvCopyrightKindList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlCommonKeyData.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            dictBaseTypeIBindingSource.DataSource = ddlCommonKeyData.DataSource;
            //save url for filter data into grid
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gvCopyrightKindList.DataSource = HandleDataForGrid(urlForComplexDict);
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
            _creativeroleTypeList = _connector.GetList<CopyrightKind>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _creativeroleTypeList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    VariantUse = ddlCommonKeyData.Items.First(el => (int)el.Value == item.CrGroupCode).Text,
                });
            }
            //show current count elements into grid
            total.Text = _creativeroleTypeList.Count.ToString();
            return dataGrid;
        }

        //handle data for drop down list - 'Спосіб використання'
        private List<DictBaseTypeI> InitializeDataForFilter()
        {
            //define for result data
            List<DictBaseTypeI> dataDropDownList = new List<DictBaseTypeI>();
            //get data for drop down list
            dataDropDownList = _connector.GetList<DictBaseTypeI>("dictionary/base/CrkindGroup");
            //check data
            return dataDropDownList != null ? dataDropDownList : new List<DictBaseTypeI>();
        }

        //show data for bottom panel
        private void gvCopyrightKindList_CellClick(object sender, GridViewCellEventArgs e)
        {
            //get id dictionary
            GridViewRowInfo rowDetail = gvCopyrightKindList.CurrentRow;
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
            if (codeForRefresh == 0) codeForRefresh = _creativeroleTypeList[0].CodeI;
            //get object by parameter 'code' from service
            creativeroleTypeData = dictService.GetCopyrightKind(codeForRefresh);
            //use data for binding source
            bsCopyrightKind.DataSource = creativeroleTypeData;
            //define binding for source of the 'Uk'
            ukCreativeroleType = creativeroleTypeData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukCreativeroleType == null)
            {
                ukCreativeroleType = new CopyrightKindTr { Lang = "Uk" };
                creativeroleTypeData.CopyrightKindTr.Add(ukCreativeroleType);
            }
            bindingSourceUk.DataSource = ukCreativeroleType;
            //defined binding for source of the 'Ru'
            ruCreativeroleType = creativeroleTypeData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruCreativeroleType == null)
            {
                ruCreativeroleType = new CopyrightKindTr { Lang = "Ru" };
                creativeroleTypeData.CopyrightKindTr.Add(ruCreativeroleType);
            }
            bindingSourceRu.DataSource = ruCreativeroleType;
            //define binding for source of the 'En'
            enCreativeroleType = creativeroleTypeData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enCreativeroleType == null)
            {
                enCreativeroleType = new CopyrightKindTr { Lang = "En" };
                creativeroleTypeData.CopyrightKindTr.Add(enCreativeroleType);
            }
            bindingSourceEn.DataSource = enCreativeroleType;
        }

        //select item into drop down list for filtered data into grid
        private void ddlCommonKeyData_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //stop perform if position is not exist
            if (e.Position == -1) return;
            //get field 'value' of the current selected item
            int selectedItemData = (int)ddlCommonKeyData.Items[e.Position].Value;
            //set filtered data to grid
            gvCopyrightKindList.DataSource = FilterDataIntoGrid(selectedItemData);
        }

        //filter data for grid
        private List<ViewTable> FilterDataIntoGrid(int code)
        {
            //initialzie empty data for result
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            _creativeroleTypeList = _connector.GetList<CopyrightKind>(urlDataGrid);
            //stop perform if data is not exist
            if (_creativeroleTypeList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            _creativeroleTypeList = _creativeroleTypeList.Where(item => item.CrGroupCode == code).ToList();
            //initialize data for grid
            foreach (var item in _creativeroleTypeList)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    VariantUse = ddlCommonKeyData.SelectedItem.Text,
                });
            }
            //show current count elements into grid
            total.Text = _creativeroleTypeList.Count.ToString();
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSave.Text = "Додати";
            //clear data into bottom panel
            //refresh data for field 'Code'
            creativeroleTypeData = new CopyrightKind();
            bsCopyrightKind.DataSource = creativeroleTypeData;
            //refresh data for field 'Uk'
            ukCreativeroleType = new CopyrightKindTr();
            creativeroleTypeData.CopyrightKindTr.Add(ukCreativeroleType);
            bindingSourceUk.DataSource = ukCreativeroleType;
            //refresh data for field 'Ru'
            ruCreativeroleType = new CopyrightKindTr();
            creativeroleTypeData.CopyrightKindTr.Add(ruCreativeroleType);
            bindingSourceRu.DataSource = ruCreativeroleType;
            //refresh data for field 'Ru'
            enCreativeroleType = new CopyrightKindTr();
            creativeroleTypeData.CopyrightKindTr.Add(enCreativeroleType);
            bindingSourceEn.DataSource = enCreativeroleType;
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
            gvCopyrightKindList.DataSource = HandleDataForGrid(urlDataGrid);
            DataUpdateForBottomPanel();
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            DictionaryService dictService = new DictionaryService();
            if (btnSave.Text == "Додати")
            {
                //send created object
                var result = dictService.CreateCopyrightKind(creativeroleTypeData);
                //set default state for 'Text' of the btnSave
                btnSave.Text = "Зберегти";
            } else if (btnSave.Text == "Зберегти")
            {
                //save changes
                var result = dictService.UpdateCopyrightKind(creativeroleTypeData);
            }
            //update data for grid
            gvCopyrightKindList.DataSource = HandleDataForGrid(urlDataGrid);
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
                if (btnSave.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSave.Text = "Зберегти";
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
                if (btnSave.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSave.Text = "Зберегти";
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
                if (btnSave.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSave.Text = "Зберегти";
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
                if (btnSave.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSave.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
        }
    }
}
