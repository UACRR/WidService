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
    public partial class BaseKlr030Control : UserControl
    {
        //Uk data item
        KlR030tr ukKlr030;
        //Ru data item
        KlR030tr ruKlr030;
        //En data item
        KlR030tr enKlr030;
        //data grid
        List<KlR030> _klr030List;
        //item data
        KlR030 klr030Data;
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
            //initialize connector
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchKlr030.SetUsageGrid(gridKlr030List);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterKlr030.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            dictBaseTypeIBindingSource.DataSource = ddlFilterKlr030.DataSource;
            //save url for filter data into grid
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridKlr030List.DataSource = HandleDataForGrid(urlForComplexDict);
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
            _klr030List = _connector.GetList<KlR030>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _klr030List)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.R030,
                    NameUk = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Uk")?.R030Name ?? item.R030Name,
                    NameRu = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Ru")?.R030Name,
                    NameEn = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "En")?.R030Name,
                    VariantUse = ddlFilterKlr030.Items.First(el => (int)el.Value == item.R031).Text,
                });
            }
            //show current count elements into grid
            totalKlr030.Text = _klr030List.Count.ToString();
            return dataGrid;
        }

        //handle data for drop down list - 'Спосіб використання'
        private List<DictBaseTypeI> InitializeDataForFilter()
        {
            //define for result data
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
            if (codeForRefresh == 0) codeForRefresh = int.TryParse(_klr030List[0].R030, out int code) ? code : 0;
            //get object by parameter 'code' from service
            klr030Data = dictService.GetKlR030(codeForRefresh);
            //use data for binding source
            bsCopyrightKind.DataSource = klr030Data;
            //define binding for source of the 'Uk'
            ukKlr030 = klr030Data.KlR030tr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukKlr030 == null)
            {
                ukKlr030 = new KlR030tr { Lang = "Uk" };
                klr030Data.KlR030tr.Add(ukKlr030);
            }
            bindingSourceUk.DataSource = ukKlr030;
            //defined binding for source of the 'Ru'
            ruKlr030 = klr030Data.KlR030tr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruKlr030 == null)
            {
                ruKlr030 = new KlR030tr { Lang = "Ru" };
                klr030Data.KlR030tr.Add(ruKlr030);
            }
            bindingSourceRu.DataSource = ruKlr030;
            //define binding for source of the 'En'
            enKlr030 = klr030Data.KlR030tr.FirstOrDefault(rec => rec.Lang == "En");
            if (enKlr030 == null)
            {
                enKlr030 = new KlR030tr { Lang = "En" };
                klr030Data.KlR030tr.Add(enKlr030);
            }
            bindingSourceEn.DataSource = enKlr030;
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
            //initialzie empty data for result
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            _klr030List = _connector.GetList<KlR030>(urlDataGrid);
            //stop perform if data is not exist
            if (_klr030List == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            _klr030List = _klr030List.Where(item => item.R031 == code).ToList();
            //initialize data for grid
            foreach (var item in _klr030List)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.R030,
                    NameUk = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Uk")?.R030Name ?? item.R030Name,
                    NameRu = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Ru")?.R030Name,
                    NameEn = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "En")?.R030Name,
                    VariantUse = ddlFilterKlr030.SelectedItem.Text,
                });
            }
            //show current count elements into grid
            totalKlr030.Text = _klr030List.Count.ToString();
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveKlr030.Text = "Додати";
            //clear data into bottom panel
            //refresh data for field 'Code'
            klr030Data = new KlR030();
            bsCopyrightKind.DataSource = klr030Data;
            //refresh data for field 'Uk'
            ukKlr030 = new KlR030tr();
            klr030Data.KlR030tr.Add(ukKlr030);
            bindingSourceUk.DataSource = ukKlr030;
            //refresh data for field 'Ru'
            ruKlr030 = new KlR030tr();
            klr030Data.KlR030tr.Add(ruKlr030);
            bindingSourceRu.DataSource = ruKlr030;
            //refresh data for field 'Ru'
            enKlr030 = new KlR030tr();
            klr030Data.KlR030tr.Add(enKlr030);
            bindingSourceEn.DataSource = enKlr030;
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
            gridKlr030List.DataSource = HandleDataForGrid(urlDataGrid);
            DataUpdateForBottomPanel();
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            DictionaryService dictService = new DictionaryService();
            if (btnSaveKlr030.Text == "Додати")
            {
                //send created object
                var result = dictService.CreateKlR030(klr030Data);
                //set default state for 'Text' of the btnSave
                btnSaveKlr030.Text = "Зберегти";
            } else if (btnSaveKlr030.Text == "Зберегти")
            {
                //save changes
                var result = dictService.UpdateKlR030(klr030Data);
            }
            //update data for grid
            gridKlr030List.DataSource = HandleDataForGrid(urlDataGrid);
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
        }

        //changed data of the field 'Ru'
        private void bindingSourceRu_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
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
        }

        //changed data of the field 'En'
        private void bindingSourceEn_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
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
        }
    }
}
