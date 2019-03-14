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
    public partial class BaseSystemConstantControl : UserControl
    {
        //Uk data item
        SystemConstantTr ukCopyrightKind;
        //Ru data item
        SystemConstantTr ruCopyrightKind;
        //En data item
        SystemConstantTr enCopyrightKind;
        //data grid
        List<SystemConstant> _copyrightKindList;
        //item data
        SystemConstant copyrightKindData;
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
                txtSearchSystemConstant.Enabled = value;
                //filter for grid
                ddlFilterCopyrightKind.Enabled = value;
                //grid element
                gridSystemConstantList.Enabled = value;
                //'Add' button
                btnAddSystemConstant.Enabled = value;
                //'Delete' button
                btnDeleteSystemConstant.Enabled = value;
                //'Save' button (bottom panel)
                btnSaveSystemConstant.Enabled = !value;
                //'Cancel' button (bottom panel)
                btnCancelSystemConstant.Enabled = !value;
            }
        }
        public BaseSystemConstantControl(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            //initialize connector
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchSystemConstant.SetUsageGrid(gridSystemConstantList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterCopyrightKind.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            bsSimpleDictSystemConstant.DataSource = ddlFilterCopyrightKind.DataSource;
            //save url for filter data into grid
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridSystemConstantList.DataSource = HandleDataForGrid(urlForComplexDict);
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
            _copyrightKindList = _connector.GetList<SystemConstant>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _copyrightKindList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                });
            }
            //show current count elements into grid
            totalSystemConstant.Text = _copyrightKindList.Count.ToString();
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
            GridViewRowInfo rowDetail = gridSystemConstantList.CurrentRow;
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
            if (codeForRefresh == 0) codeForRefresh = _copyrightKindList[0].CodeI;
            //get object by parameter 'code' from service
            copyrightKindData = dictService.GetCopyrightKind(codeForRefresh);
            //use data for binding source
            bsSystemConstant.DataSource = copyrightKindData;
            //define binding for source of the 'Uk'
            ukCopyrightKind = copyrightKindData.SystemConstantTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukCopyrightKind == null)
            {
                ukCopyrightKind = new SystemConstantTr { Lang = "Uk" };
                copyrightKindData.SystemConstantTr.Add(ukCopyrightKind);
            }
            bsUkLangSystemConstant.DataSource = ukCopyrightKind;
            //defined binding for source of the 'Ru'
            ruCopyrightKind = copyrightKindData.SystemConstantTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruCopyrightKind == null)
            {
                ruCopyrightKind = new SystemConstantTr { Lang = "Ru" };
                copyrightKindData.SystemConstantTr.Add(ruCopyrightKind);
            }
            bsRuLangSystemConstant.DataSource = ruCopyrightKind;
            //define binding for source of the 'En'
            enCopyrightKind = copyrightKindData.SystemConstantTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enCopyrightKind == null)
            {
                enCopyrightKind = new SystemConstantTr { Lang = "En" };
                copyrightKindData.SystemConstantTr.Add(enCopyrightKind);
            }
            bsEnLangSystemConstant.DataSource = enCopyrightKind;
        }

        //select item into drop down list for filtered data into grid
        private void ddlCommonKeyData_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //stop perform if position is not exist
            if (e.Position == -1) return;
            //get field 'value' of the current selected item
            int selectedItemData = (int)ddlFilterCopyrightKind.Items[e.Position].Value;
            //set filtered data to grid
            gridSystemConstantList.DataSource = FilterDataIntoGrid(selectedItemData);
        }

        //filter data for grid
        private List<ViewTable> FilterDataIntoGrid(int code)
        {
            //initialzie empty data for result
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            _copyrightKindList = _connector.GetList<SystemConstant>(urlDataGrid);
            //stop perform if data is not exist
            if (_copyrightKindList == null) return new List<ViewTable>();
            //initialize data for grid
            foreach (var item in _copyrightKindList)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                });
            }
            //show current count elements into grid
            totalSystemConstant.Text = _copyrightKindList.Count.ToString();
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveSystemConstant.Text = "Додати";
            //clear data into bottom panel
            //refresh data for field 'Code'
            copyrightKindData = new SystemConstant();
            bsSystemConstant.DataSource = copyrightKindData;
            //refresh data for field 'Uk'
            ukCopyrightKind = new SystemConstantTr();
            copyrightKindData.SystemConstantTr.Add(ukCopyrightKind);
            bsUkLangSystemConstant.DataSource = ukCopyrightKind;
            //refresh data for field 'Ru'
            ruCopyrightKind = new SystemConstantTr();
            copyrightKindData.SystemConstantTr.Add(ruCopyrightKind);
            bsRuLangSystemConstant.DataSource = ruCopyrightKind;
            //refresh data for field 'Ru'
            enCopyrightKind = new SystemConstantTr();
            copyrightKindData.SystemConstantTr.Add(enCopyrightKind);
            bsEnLangSystemConstant.DataSource = enCopyrightKind;
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
            gridSystemConstantList.DataSource = HandleDataForGrid(urlDataGrid);
            DataUpdateForBottomPanel();
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            DictionaryService dictService = new DictionaryService();
            if (btnSaveSystemConstant.Text == "Додати")
            {
                //send created object
                var result = dictService.CreateCopyrightKind(copyrightKindData);
                //set default state for 'Text' of the btnSave
                btnSaveSystemConstant.Text = "Зберегти";
            } else if (btnSaveSystemConstant.Text == "Зберегти")
            {
                //save changes
                var result = dictService.UpdateCopyrightKind(copyrightKindData);
            }
            //update data for grid
            gridSystemConstantList.DataSource = HandleDataForGrid(urlDataGrid);
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
                if (btnSaveSystemConstant.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveSystemConstant.Text = "Зберегти";
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
                if (btnSaveSystemConstant.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveSystemConstant.Text = "Зберегти";
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
                if (btnSaveSystemConstant.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveSystemConstant.Text = "Зберегти";
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
                if (btnSaveSystemConstant.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveSystemConstant.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
        }
    }
}
