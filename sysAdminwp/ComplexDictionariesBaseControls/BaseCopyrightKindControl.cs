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
    public partial class BaseCopyrightKindControl : UserControl
    {
        //Uk data item
        CopyrightKindTr ukCopyrightKind;
        //Ru data item
        CopyrightKindTr ruCopyrightKind;
        //En data item
        CopyrightKindTr enCopyrightKind;
        //data grid
        List<CopyrightKind> _copyrightKindList;
        //item data
        CopyrightKind copyrightKindData;
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
        public BaseCopyrightKindControl(ApiConnector connector, string urlForComplexDict)
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
            //set 'Enabled' state by default
            ControlEnabledActiveElements = true;
            
        }
        
        //handle data for grid
        private List<ViewTable> HandleDataForGrid(string urlForGetDataDictionaries)
        {
            //save url for 'filtering' grid

            //result data for initialize to grid
            List<ViewTable> dataGrid = new List<ViewTable>();
            //check on valid state parameter
            if (urlForGetDataDictionaries == null) return dataGrid;
            //get data dictionaries -> for grid
            _copyrightKindList = _connector.GetList<CopyrightKind>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _copyrightKindList)
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
            total.Text = _copyrightKindList.Count.ToString();
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
            if (codeForRefresh == 0) codeForRefresh = _copyrightKindList[0].CodeI;
            //get object by parameter 'code' from service
            copyrightKindData = dictService.GetCopyrightKind(codeForRefresh);
            //use data for binding source
            bsCopyrightKind.DataSource = copyrightKindData;
            //define binding for source of the 'Uk'
            ukCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukCopyrightKind == null)
            {
                ukCopyrightKind = new CopyrightKindTr { Lang = "Uk" };
                copyrightKindData.CopyrightKindTr.Add(ukCopyrightKind);
            }
            bindingSourceUk.DataSource = ukCopyrightKind;
            //SetupBindSource("Uk", bindingSourceUk);
            //defined binding for source of the 'Ru'
            ruCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruCopyrightKind == null)
            {
                ruCopyrightKind = new CopyrightKindTr { Lang = "Ru" };
                copyrightKindData.CopyrightKindTr.Add(ruCopyrightKind);
            }
            bindingSourceRu.DataSource = ruCopyrightKind;
            //SetupBindSource("Ru", bindingSourceRu);
            //define binding for source of the 'En'
            enCopyrightKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enCopyrightKind == null)
            {
                enCopyrightKind = new CopyrightKindTr { Lang = "En" };
                copyrightKindData.CopyrightKindTr.Add(enCopyrightKind);
            }
            bindingSourceEn.DataSource = enCopyrightKind;
            //SetupBindSource("En", bindingSourceEn);
        }

        ////binding for textBox elements
        //private void SetupBindSource(string Lang, BindingSource dest)
        //{
        //    // get object by 'Lang'
        //    var copyKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == Lang);
        //    if (copyKind == null)
        //    {
        //        copyKind = new CopyrightKindTr { Lang = Lang };
        //        copyrightKindData.CopyrightKindTr.Add(copyKind);
        //    }
        //    //use data for source
        //    dest.DataSource = copyrightKindData;
        //}

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
            _copyrightKindList = _connector.GetList<CopyrightKind>(urlDataGrid);
            //stop perform if data is not exist
            if (_copyrightKindList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            _copyrightKindList = _copyrightKindList.Where(item => item.CrGroupCode == code).ToList();
            //initialize data for grid
            foreach (var item in _copyrightKindList)
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
            total.Text = _copyrightKindList.Count.ToString();
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSave.Text = "Додати";
            //clear data into bottom panel
            //refresh data for field 'Code'
            copyrightKindData = new CopyrightKind();
            bsCopyrightKind.DataSource = copyrightKindData;
            //refresh data for field 'Uk'
            ukCopyrightKind = new CopyrightKindTr();
            copyrightKindData.CopyrightKindTr.Add(ukCopyrightKind);
            bindingSourceUk.DataSource = ukCopyrightKind;
            //refresh data for field 'Ru'
            ruCopyrightKind = new CopyrightKindTr();
            copyrightKindData.CopyrightKindTr.Add(ruCopyrightKind);
            bindingSourceRu.DataSource = ruCopyrightKind;
            //refresh data for field 'Ru'
            enCopyrightKind = new CopyrightKindTr();
            copyrightKindData.CopyrightKindTr.Add(enCopyrightKind);
            bindingSourceEn.DataSource = enCopyrightKind;
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
            DataUpdateForBottomPanel();
            ////stop perform if elements have 'Enabled' -> false
            //if (!ControlEnabledActiveElements) return;
            ////change 'Enabled' state for elements
            //ControlEnabledActiveElements = false;
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            DictionaryService dictService = new DictionaryService();
            if (btnSave.Text == "Додати")
            {
                //send created object
                var result = dictService.CreateCopyrightKind(copyrightKindData);
                //set default state for 'Text' of the btnSave
                btnSave.Text = "Зберегти";
            } else if (btnSave.Text == "Зберегти")
            {
                //save changes
                var result = dictService.UpdateCopyrightKind(copyrightKindData);
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
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
            {
                if (btnSave.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSave.Text = "Зберегти";
                }
                //MessageBox.Show("Updated");
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
                //MessageBox.Show("Updated");
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
                //MessageBox.Show("Updated");
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
                //MessageBox.Show("Updated");
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
        }
    }
}
