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
    public partial class BaseTypePlaceControl : UserControl
    {
        //Uk data item
        TypePlaceTr ukTypePlace;
        //Ru data item
        TypePlaceTr ruTypePlace;
        //En data item
        TypePlaceTr enTypePlace;
        //data grid
        List<TypePlace> _typePlaceList;
        //item data
        TypePlace typePlaceData;
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
                txtSearchTypePlace.Enabled = value;
                //filter for grid
                ddlFilterTypePlace.Enabled = value;
                //grid element
                gridTypePlaceList.Enabled = value;
                //'Add' button
                btnAddTypePlace.Enabled = value;
                //'Delete' button
                btnDeleteTypePlace.Enabled = value;
                //'Save' button (bottom panel)
                btnSaveTypePlace.Enabled = !value;
                //'Cancel' button (bottom panel)
                btnCancelTypePlace.Enabled = !value;
            }
        }
        public BaseTypePlaceControl(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            //initialize connector
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchTypePlace.SetUsageGrid(gridTypePlaceList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterTypePlace.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            dictBaseTypeIBindingSource.DataSource = ddlFilterTypePlace.DataSource;
            //save url for filter data into grid
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridTypePlaceList.DataSource = HandleDataForGrid(urlForComplexDict);
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
            _typePlaceList = _connector.GetList<TypePlace>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _typePlaceList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    Object = ddlFilterTypePlace.Items.First(el => (int)el.Value == item.ParamType).Text,
                });
            }
            //show current count elements into grid
            totalTypePlace.Text = _typePlaceList.Count.ToString();
            return dataGrid;
        }

        //handle data for drop down list - 'Спосіб використання'
        private List<DictBaseTypeI> InitializeDataForFilter()
        {
            //define for result data
            List<DictBaseTypeI> dataDropDownList = new List<DictBaseTypeI>();
            //get data for drop down list
            dataDropDownList = _connector.GetList<DictBaseTypeI>("dictionary/base/typePlaceParam");
            //check data
            return dataDropDownList != null ? dataDropDownList : new List<DictBaseTypeI>();
        }

        //show data for bottom panel
        private void gvCopyrightKindList_CellClick(object sender, GridViewCellEventArgs e)
        {
            //get id dictionary
            GridViewRowInfo rowDetail = gridTypePlaceList.CurrentRow;
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
            if (codeForRefresh == 0) codeForRefresh = _typePlaceList[0].CodeI;
            //get object by parameter 'code' from service
            typePlaceData = dictService.GetTypePlace(codeForRefresh);
            //use data for binding source
            bsCopyrightKind.DataSource = typePlaceData;
            //define binding for source of the 'Uk'
            ukTypePlace = typePlaceData.TypePlaceTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukTypePlace == null)
            {
                ukTypePlace = new TypePlaceTr { Lang = "Uk" };
                typePlaceData.TypePlaceTr.Add(ukTypePlace);
            }
            bindingSourceUk.DataSource = ukTypePlace;
            //defined binding for source of the 'Ru'
            ruTypePlace = typePlaceData.TypePlaceTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruTypePlace == null)
            {
                ruTypePlace = new TypePlaceTr { Lang = "Ru" };
                typePlaceData.TypePlaceTr.Add(ruTypePlace);
            }
            bindingSourceRu.DataSource = ruTypePlace;
            //define binding for source of the 'En'
            enTypePlace = typePlaceData.TypePlaceTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enTypePlace == null)
            {
                enTypePlace = new TypePlaceTr { Lang = "En" };
                typePlaceData.TypePlaceTr.Add(enTypePlace);
            }
            bindingSourceEn.DataSource = enTypePlace;
        }

        //select item into drop down list for filtered data into grid
        private void ddlCommonKeyData_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //stop perform if position is not exist
            if (e.Position == -1) return;
            //get field 'value' of the current selected item
            int selectedItemData = (int)ddlFilterTypePlace.Items[e.Position].Value;
            //set filtered data to grid
            gridTypePlaceList.DataSource = FilterDataIntoGrid(selectedItemData);
        }

        //filter data for grid
        private List<ViewTable> FilterDataIntoGrid(int code)
        {
            //initialzie empty data for result
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            _typePlaceList = _connector.GetList<TypePlace>(urlDataGrid);
            //stop perform if data is not exist
            if (_typePlaceList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            _typePlaceList = _typePlaceList.Where(item => item.ParamType == code).ToList();
            //initialize data for grid
            foreach (var item in _typePlaceList)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    Object = ddlFilterTypePlace.SelectedItem.Text,
                });
            }
            //show current count elements into grid
            totalTypePlace.Text = _typePlaceList.Count.ToString();
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveTypePlace.Text = "Додати";
            //clear data into bottom panel
            //refresh data for field 'Code'
            typePlaceData = new TypePlace();
            bsCopyrightKind.DataSource = typePlaceData;
            //refresh data for field 'Uk'
            ukTypePlace = new TypePlaceTr();
            typePlaceData.TypePlaceTr.Add(ukTypePlace);
            bindingSourceUk.DataSource = ukTypePlace;
            //refresh data for field 'Ru'
            ruTypePlace = new TypePlaceTr();
            typePlaceData.TypePlaceTr.Add(ruTypePlace);
            bindingSourceRu.DataSource = ruTypePlace;
            //refresh data for field 'Ru'
            enTypePlace = new TypePlaceTr();
            typePlaceData.TypePlaceTr.Add(enTypePlace);
            bindingSourceEn.DataSource = enTypePlace;
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
            gridTypePlaceList.DataSource = HandleDataForGrid(urlDataGrid);
            DataUpdateForBottomPanel();
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            DictionaryService dictService = new DictionaryService();
            if (btnSaveTypePlace.Text == "Додати")
            {
                //send created object
                var result = dictService.CreateTypePlace(typePlaceData);
                //set default state for 'Text' of the btnSave
                btnSaveTypePlace.Text = "Зберегти";
            } else if (btnSaveTypePlace.Text == "Зберегти")
            {
                //save changes
                var result = dictService.UpdateTypePlace(typePlaceData);
            }
            //update data for grid
            gridTypePlaceList.DataSource = HandleDataForGrid(urlDataGrid);
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
                if (btnSaveTypePlace.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveTypePlace.Text = "Зберегти";
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
                if (btnSaveTypePlace.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveTypePlace.Text = "Зберегти";
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
                if (btnSaveTypePlace.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveTypePlace.Text = "Зберегти";
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
                if (btnSaveTypePlace.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveTypePlace.Text = "Зберегти";
                }
                //stop perform if elements have 'Enabled' -> false
                if (!ControlEnabledActiveElements) return;
                //change 'Enabled' state for elements
                ControlEnabledActiveElements = false;
            }
        }
    }
}
