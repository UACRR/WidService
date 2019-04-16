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
    public partial class BaseGenreTypeControl : UserControl
    {
        //Uk data item
        GenreTypeTr ukGenreType;
        //Ru data item
        GenreTypeTr ruGenreType;
        //En data item
        GenreTypeTr enGenreType;
        //data grid
        List<GenreType> _genreTypeList;
        //item data
        GenreType genreTypeData;
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
                txtSearchGenreType.Enabled = value;
                //filter for grid
                ddlFilterGenreType.Enabled = value;
                //grid element
                gridGenreTypeList.Enabled = value;
                //'Add' button
                btnAddGenreType.Enabled = value;
                //'Delete' button
                btnDeleteGenreType.Enabled = value;
                //'Save' button (bottom panel)
                btnSaveGenreType.Enabled = !value;
                //'Cancel' button (bottom panel)
                btnCancelGenreType.Enabled = !value;
            }
        }
        public BaseGenreTypeControl(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            //initialize connector
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchGenreType.SetUsageGrid(gridGenreTypeList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterGenreType.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            bsSimpleDictGenreType.DataSource = ddlFilterGenreType.DataSource;
            //save url for filter data into grid
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridGenreTypeList.DataSource = HandleDataForGrid(urlForComplexDict);
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
            _genreTypeList = _connector.GetList<GenreType>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _genreTypeList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    VariantObject = ddlFilterGenreType.Items.First(el => (int)el.Value == item.CategoryCode).Text,
                });
            }
            //show current count elements into grid
            totalGenreType.Text = _genreTypeList.Count.ToString();
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
            GridViewRowInfo rowDetail = gridGenreTypeList.CurrentRow;
            //get data of the current row
            var @curRow = rowDetail.DataBoundItem as ViewTable;
            //stop perform if data is not exist
            if (@curRow == null) return;
            //check field 'Code' on correct type 'int'
            if (!int.TryParse(@curRow.Code, out int code)) return;
            //save value 'code' -> fr refresh data when 'Cancel' action
            codeForRefresh = _genreTypeList.FindIndex(el => el.CodeI == code);
            //update data for bottom panel
            DataUpdateForBottomPanel();
        }

        //refresh changed data for bottom panel
        private void DataUpdateForBottomPanel()
        {
            DictionaryService dictService = new DictionaryService();
            //set default first item of the grid
            if (codeForRefresh == 0) codeForRefresh = _genreTypeList[0].CodeI;
            GenreType genreType = _genreTypeList[--codeForRefresh];
            //get object by parameter 'code' from service
            genreTypeData = dictService.GetGenreType(genreType.CodeI);
            //use data for binding source
            bsGenreType.DataSource = genreTypeData;
            //define binding for source of the 'Uk'
            ukGenreType = genreTypeData.GenreTypeTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukGenreType == null)
            {
                ukGenreType = new GenreTypeTr { Lang = "Uk" };
                genreTypeData.GenreTypeTr.Add(ukGenreType);
            }
            bsUkLangGenreType.DataSource = ukGenreType;
            //defined binding for source of the 'Ru'
            ruGenreType = genreTypeData.GenreTypeTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruGenreType == null)
            {
                ruGenreType = new GenreTypeTr { Lang = "Ru" };
                genreTypeData.GenreTypeTr.Add(ruGenreType);
            }
            bsRuLangGenreType.DataSource = ruGenreType;
            //define binding for source of the 'En'
            enGenreType = genreTypeData.GenreTypeTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enGenreType == null)
            {
                enGenreType = new GenreTypeTr { Lang = "En" };
                genreTypeData.GenreTypeTr.Add(enGenreType);
            }
            bsEnLangGenreType.DataSource = enGenreType;
        }

        //select item into drop down list for filtered data into grid
        private void ddlCommonKeyData_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //stop perform if position is not exist
            if (e.Position == -1) return;
            //get field 'value' of the current selected item
            int selectedItemData = (int)ddlFilterGenreType.Items[e.Position].Value;
            //set filtered data to grid
            gridGenreTypeList.DataSource = FilterDataIntoGrid(selectedItemData);
        }

        //filter data for grid
        private List<ViewTable> FilterDataIntoGrid(int code)
        {
            //initialzie empty data for result
            List<ViewTable> filteredData = new List<ViewTable>();
            //get all data of the 'CopyrightKind'
            _genreTypeList = _connector.GetList<GenreType>(urlDataGrid);
            //stop perform if data is not exist
            if (_genreTypeList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            _genreTypeList = _genreTypeList.Where(item => item.CategoryCode == code).ToList();
            //initialize data for grid
            foreach (var item in _genreTypeList)
            {
                filteredData.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    VariantObject = ddlFilterGenreType.SelectedItem.Text,
                });
            }
            //show current count elements into grid
            totalGenreType.Text = _genreTypeList.Count.ToString();
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveGenreType.Text = "Додати";
            //clear data into bottom panel
            //refresh data for field 'Code'
            genreTypeData = new GenreType { CategoryCode = 1 };
            bsGenreType.DataSource = genreTypeData;
            //refresh data for field 'Uk'
            ukGenreType = new GenreTypeTr { Lang = "Uk" };
            genreTypeData.GenreTypeTr.Add(ukGenreType);
            bsUkLangGenreType.DataSource = ukGenreType;
            //refresh data for field 'Ru'
            ruGenreType = new GenreTypeTr { Lang = "Ru" };
            genreTypeData.GenreTypeTr.Add(ruGenreType);
            bsRuLangGenreType.DataSource = ruGenreType;
            //refresh data for field 'Ru'
            enGenreType = new GenreTypeTr { Lang = "En" };
            genreTypeData.GenreTypeTr.Add(enGenreType);
            bsEnLangGenreType.DataSource = enGenreType;
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
            GenreType item = _genreTypeList[codeForRefresh];
            bool result = dictService.DeleteGenreType(item.CodeI);
            //update data for grid
            gridGenreTypeList.DataSource = HandleDataForGrid(urlDataGrid);
            DataUpdateForBottomPanel();
            gridGenreTypeList.CurrentRow = gridGenreTypeList.Rows[codeForRefresh];
        }

        //action 'Save' object to grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            //for save last index selected item
            int current = 0;

            DictionaryService dictService = new DictionaryService();
            if (btnSaveGenreType.Text == "Додати")
            {
                //send created object
                var result = dictService.CreateGenreType(genreTypeData);
                //set default state for 'Text' of the btnSave
                btnSaveGenreType.Text = "Зберегти";
                //save last selected item
                //current = gridGenreTypeList.CurrentRow.Index;
                //update data for grid
                gridGenreTypeList.DataSource = HandleDataForGrid(urlDataGrid);
                int newPosition = _genreTypeList.FindIndex(el => el.CodeI == result.CodeI);
                //select certain item into grid
                gridGenreTypeList.CurrentRow = gridGenreTypeList.Rows[newPosition];
            } else if (btnSaveGenreType.Text == "Зберегти")
            {
                //save changes
                GenreType result = dictService.UpdateGenreType(genreTypeData);
                //save last selected item
                current = gridGenreTypeList.CurrentRow.Index;
                //update data for grid
                gridGenreTypeList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridGenreTypeList.CurrentRow = gridGenreTypeList.Rows[current];
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
            //    if (btnSaveGenreType.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveGenreType.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void txtUkLangGenreType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveGenreType.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveGenreType.Text = "Зберегти";
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
            //    if (btnSaveGenreType.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveGenreType.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void txtRuLangGenreType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveGenreType.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveGenreType.Text = "Зберегти";
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
            //    if (btnSaveGenreType.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveGenreType.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void txtEnLangGenreType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnSaveGenreType.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveGenreType.Text = "Зберегти";
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
            //    if (btnSaveGenreType.Text != "Додати")
            //    {
            //        //change property 'Text' of the btnSave for 'Save' action
            //        btnSaveGenreType.Text = "Зберегти";
            //    }
            //    //stop perform if elements have 'Enabled' -> false
            //    if (!ControlEnabledActiveElements) return;
            //    //change 'Enabled' state for elements
            //    ControlEnabledActiveElements = false;
            //}
        }

        private void ddlEditKeyGenreType_Click(object sender, EventArgs e)
        {
            if (btnSaveGenreType.Text != "Додати")
            {
                //change property 'Text' of the btnSave for 'Save' action
                btnSaveGenreType.Text = "Зберегти";
            }
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        //allow input only number data
        private void txtCodeGenreType_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it 'number' or 'Backspace' -> allow input
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                if (btnSaveGenreType.Text != "Додати")
                {
                    //change property 'Text' of the btnSave for 'Save' action
                    btnSaveGenreType.Text = "Зберегти";
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
