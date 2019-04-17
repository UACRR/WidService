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
    public partial class BaseTypePlaceControl : UserControl
    {
        //define data for different languages
        private TypePlaceTr ukTypePlace;
        private TypePlaceTr ruTypePlace;
        private TypePlaceTr enTypePlace;
        //define grid data
        private List<TypePlace> _typePlaceList;
        public List<TypePlace> TypePlaceList
        {
            get { return _typePlaceList; }
            set
            {
                if (value != null)
                {
                    _typePlaceList = value;
                    totalTypePlace.Text = _typePlaceList.Count.ToString();
                }
            }
        }
        //item data
        private TypePlace typePlaceData;
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
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchTypePlace.SetUsageGrid(gridTypePlaceList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlFilterTypePlace.DataSource = InitializeDataForFilter();
            //initialize data for binding source of the Dictionaries 'dropDownList'
            bsSimpleDictTypePlace.DataSource = ddlFilterTypePlace.DataSource;
            urlDataGrid = urlForComplexDict;
            //initialize data for grid
            gridTypePlaceList.DataSource = HandleDataForGrid(urlForComplexDict);
            int codeIDefault = TypePlaceList[0].CodeI;
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
            TypePlaceList = _connector.GetList<TypePlace>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in TypePlaceList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                    Object = item.ParamType != null ? ddlFilterTypePlace.Items.First(el => (int)el.Value == item.ParamType).Text : "",
                });
            }
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
            ViewTable @curRow = rowDetail.DataBoundItem as ViewTable;
            //stop perform if data is not exist
            if (@curRow == null) return;
            //check field 'Code' on correct type 'int'
            if (!int.TryParse(@curRow.Code, out int code)) return;
            //save value 'code' -> fr refresh data when 'Cancel' action
            indexSelectedElem = TypePlaceList.FindIndex(el => el.CodeI == code);
            //update data for bottom panel
            DataUpdateForBottomPanel(code);
        }

        //refresh changed data for bottom panel
        private void DataUpdateForBottomPanel(int codeI)
        {
            DictionaryService dictService = new DictionaryService();
            //get object by parameter 'code' from service
            typePlaceData = dictService.GetTypePlace(codeI);
            //use data for binding source
            bsTypePlace.DataSource = typePlaceData;
            //define binding for source of the 'Uk'
            ukTypePlace = typePlaceData.TypePlaceTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukTypePlace == null)
            {
                ukTypePlace = new TypePlaceTr { Lang = "Uk" };
                typePlaceData.TypePlaceTr.Add(ukTypePlace);
            }
            bsUkLangTypePlace.DataSource = ukTypePlace;
            //defined binding for source of the 'Ru'
            ruTypePlace = typePlaceData.TypePlaceTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruTypePlace == null)
            {
                ruTypePlace = new TypePlaceTr { Lang = "Ru" };
                typePlaceData.TypePlaceTr.Add(ruTypePlace);
            }
            bsRuLangTypePlace.DataSource = ruTypePlace;
            //define binding for source of the 'En'
            enTypePlace = typePlaceData.TypePlaceTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enTypePlace == null)
            {
                enTypePlace = new TypePlaceTr { Lang = "En" };
                typePlaceData.TypePlaceTr.Add(enTypePlace);
            }
            bsEnLangTypePlace.DataSource = enTypePlace;
        }

        private TypePlace CheckAfterGetQuery(int codeI)
        {
            DictionaryService dictService = new DictionaryService();
            TypePlace result = dictService.GetTypePlace(codeI);
            if (result == null)
            {
                MessageBox.Show("об'єкт не знайдено");
                //set select first element of grid
                result = TypePlaceList[0];
            }
            return result;
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
            TypePlaceList = _connector.GetList<TypePlace>(urlDataGrid);
            //stop perform if data is not exist
            if (TypePlaceList == null) return new List<ViewTable>();
            //filter data by parameter 'code'
            TypePlaceList = TypePlaceList.Where(item => item.ParamType == code).ToList();
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
            return filteredData;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveTypePlace.Text = "Додати";
            //refresh data for field 'Code'
            typePlaceData = new TypePlace { ParamType = 1 };
            bsTypePlace.DataSource = typePlaceData;
            //refresh data for field 'Uk'
            ukTypePlace = new TypePlaceTr { Lang = "Uk" };
            typePlaceData.TypePlaceTr.Add(ukTypePlace);
            bsUkLangTypePlace.DataSource = ukTypePlace;
            //refresh data for field 'Ru'
            ruTypePlace = new TypePlaceTr { Lang = "Ru" };
            typePlaceData.TypePlaceTr.Add(ruTypePlace);
            bsRuLangTypePlace.DataSource = ruTypePlace;
            //refresh data for field 'Ru'
            enTypePlace = new TypePlaceTr { Lang = "En" };
            typePlaceData.TypePlaceTr.Add(enTypePlace);
            bsEnLangTypePlace.DataSource = enTypePlace;
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
            TypePlace item = _typePlaceList[indexSelectedElem];
            bool result = dictService.DeleteTypePlace(item.CodeI);
            //update data for grid
            gridTypePlaceList.DataSource = HandleDataForGrid(urlDataGrid);
            //step up in grid position
            if (result) --indexSelectedElem;
            if (indexSelectedElem < 0) indexSelectedElem = 0;
            gridTypePlaceList.CurrentRow = gridTypePlaceList.Rows[indexSelectedElem];
            //define new currentRow
            int codeNew = TypePlaceList[indexSelectedElem].CodeI;
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
            bool result = dictService.DeleteTypePlace(codeI);
            if (!result)
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
            if (btnSaveTypePlace.Text == "Додати")
            {
                //send created object
                TypePlace result = CheckAfterCreate(typePlaceData);
                codeIAfter = result.CodeI;
                //update data for grid
                gridTypePlaceList.DataSource = HandleDataForGrid(urlDataGrid);
                indexSelectedElem = _typePlaceList.FindIndex(el => el.CodeI == result.CodeI);
                //select certain item into grid
                gridTypePlaceList.CurrentRow = gridTypePlaceList.Rows[indexSelectedElem];
                //set default state for 'Text' of the btnSave
                btnSaveTypePlace.Text = "Зберегти";
            } else if (btnSaveTypePlace.Text == "Зберегти")
            {
                //save changes
                TypePlace result = CheckAfterUpdate(typePlaceData);
                codeIAfter = result.CodeI;
                //save last selected item
                indexSelectedElem = gridTypePlaceList.CurrentRow.Index;
                //update data for grid
                gridTypePlaceList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridTypePlaceList.CurrentRow = gridTypePlaceList.Rows[indexSelectedElem];
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
        private TypePlace CheckAfterCreate(TypePlace createItem)
        {
            DictionaryService dictService = new DictionaryService();
            TypePlace result = dictService.CreateTypePlace(createItem);
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = TypePlaceList[0];
            }
            return result;
        }

        /// <summary>
        /// check result data after 'Update'
        /// </summary>
        /// <param name="updateItem"></param>
        /// <returns></returns>
        private TypePlace CheckAfterUpdate(TypePlace updateItem)
        {
            DictionaryService dictService = new DictionaryService();
            TypePlace result = dictService.UpdateTypePlace(typePlaceData);
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = TypePlaceList[0];
            }
            return result;
        }

        //action 'Cancel' reset changed data for selected item
        private void btnCancel_Click(object sender, EventArgs e)
        {
            int codeICurrent = TypePlaceList[indexSelectedElem].CodeI;
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
        private void txtUkLangTypePlace_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// changed data of the field 'Ru'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRuLangTypePlace_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// changed data of the field 'En'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEnLangTypePlace_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// event for field 'Code' and for dropDownList (bottom panel)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlEditKeyTypePlace_Click(object sender, EventArgs e)
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

        //allow input only number data
        private void txtCodeTypePlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it 'number' or 'Backspace' -> allow input
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
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
                return;
            }
            else
                //disallow input
                e.Handled = true;
        }

        private void checkBox_isHoll_Click(object sender, EventArgs e)
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
