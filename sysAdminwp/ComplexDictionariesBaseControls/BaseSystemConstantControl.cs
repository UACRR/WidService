using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WebAPIConnector;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using ipsFormsDesign.Services;

namespace sysAdminwp.ComplexDictionariesBaseControls
{
    public partial class BaseSystemConstantControl : UserControl
    {
        private DictionaryService _dictService;
        //define data for different languages
        private SystemConstantTr ukSystemConstant;
        private SystemConstantTr ruSystemConstant;
        private SystemConstantTr enSystemConstant;
        //define grid data
        private List<SystemConstant> _systemConstantList;
        public List<SystemConstant> SystemConstantList
        {
            get { return _systemConstantList; }
            set
            {
                if (value != null)
                {
                    _systemConstantList = value;
                    totalSystemConstant.Text = _systemConstantList.Count.ToString();
                }
            }
        }
        //item data
        private SystemConstant systemConstantData;
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
                txtSearchSystemConstant.Enabled = value;
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
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchSystemConstant.SetUsageGrid(gridSystemConstantList);
            //save url for filter data into grid
            urlDataGrid = urlForComplexDict;
            //set data to grid
            gridSystemConstantList.DataSource = HandleDataForGrid(urlForComplexDict);
            int codeIDefault = SystemConstantList[0].CodeI;
            //set default data for bottom panel
            DataUpdateForBottomPanel(codeIDefault);
            //set 'Enabled' state by default
            ControlEnabledActiveElements = true;
        }

        private DictionaryService GetInstance()
        {
            if (_dictService == null)
            {
                _dictService = new DictionaryService();
            }
            return _dictService;
        }
        
        //handle data for grid
        private List<ViewTable> HandleDataForGrid(string urlForGetDataDictionaries)
        {
            //check on valid state parameter
            if (urlForGetDataDictionaries == null) return new List<ViewTable>();
            List<ViewTable> dataGrid = new List<ViewTable>();
            //get data dictionaries -> for grid
            SystemConstantList = _connector.GetList<SystemConstant>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in SystemConstantList)
            {
                dataGrid.Add(new ViewTable
                {
                    Code = item.CodeI.ToString(),
                    NameUk = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                    NameRu = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                });
            }
            return dataGrid;
        }

        //show data for bottom panel
        private void gvCopyrightKindList_CellClick(object sender, GridViewCellEventArgs e)
        {
            //get id dictionary
            GridViewRowInfo rowDetail = gridSystemConstantList.CurrentRow;
            //get data of the current row
            ViewTable @curRow = rowDetail.DataBoundItem as ViewTable;
            //stop perform if data is not exist
            if (@curRow == null) return;
            //check field 'Code' on correct type 'int'
            if (!int.TryParse(@curRow.Code, out int code)) return;
            //save value 'code' -> fr refresh data when 'Cancel' action
            indexSelectedElem = SystemConstantList.FindIndex(el => el.CodeI == code);
            //update data for bottom panel
            DataUpdateForBottomPanel(code);
        }

        //refresh changed data for bottom panel
        private void DataUpdateForBottomPanel(int codeI)
        {
            DictionaryService dictService = GetInstance();
            //get object by parameter 'code' from service
            systemConstantData = dictService.GetSystemConstant(codeI);
            //use data for binding source
            bsSystemConstant.DataSource = systemConstantData;
            //define binding for source of the 'Uk'
            ukSystemConstant = systemConstantData.SystemConstantTr.FirstOrDefault(rec => rec.Lang == "Uk");
            if (ukSystemConstant == null)
            {
                ukSystemConstant = new SystemConstantTr { Lang = "Uk" };
                systemConstantData.SystemConstantTr.Add(ukSystemConstant);
            }
            bsUkLangSystemConstant.DataSource = ukSystemConstant;
            //defined binding for source of the 'Ru'
            ruSystemConstant = systemConstantData.SystemConstantTr.FirstOrDefault(rec => rec.Lang == "Ru");
            if (ruSystemConstant == null)
            {
                ruSystemConstant = new SystemConstantTr { Lang = "Ru" };
                systemConstantData.SystemConstantTr.Add(ruSystemConstant);
            }
            bsRuLangSystemConstant.DataSource = ruSystemConstant;
            //define binding for source of the 'En'
            enSystemConstant = systemConstantData.SystemConstantTr.FirstOrDefault(rec => rec.Lang == "En");
            if (enSystemConstant == null)
            {
                enSystemConstant = new SystemConstantTr { Lang = "En" };
                systemConstantData.SystemConstantTr.Add(enSystemConstant);
            }
            bsEnLangSystemConstant.DataSource = enSystemConstant;
        }

        /// <summary>
        /// check after 'Get' query
        /// </summary>
        /// <param name="codeI"></param>
        /// <returns></returns>
        private SystemConstant CheckAfterGetQuery(int codeI)
        {
            DictionaryService dictService = GetInstance();
            SystemConstant result = dictService.GetSystemConstant(codeI);
            if (result == null)
            {
                MessageBox.Show("об'єкт не знайдено");
                //set select first element of grid
                result = SystemConstantList[0];
            }
            return result;
        }

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveSystemConstant.Text = "Додати";
            //refresh data for field 'Code'
            systemConstantData = new SystemConstant();
            bsSystemConstant.DataSource = systemConstantData;
            //refresh data for field 'Uk'
            ukSystemConstant = new SystemConstantTr { Lang = "Uk" };
            systemConstantData.SystemConstantTr.Add(ukSystemConstant);
            bsUkLangSystemConstant.DataSource = ukSystemConstant;
            //refresh data for field 'Ru'
            ruSystemConstant = new SystemConstantTr { Lang = "Ru" };
            systemConstantData.SystemConstantTr.Add(ruSystemConstant);
            bsRuLangSystemConstant.DataSource = ruSystemConstant;
            //refresh data for field 'Ru'
            enSystemConstant = new SystemConstantTr { Lang = "En" };
            systemConstantData.SystemConstantTr.Add(enSystemConstant);
            bsEnLangSystemConstant.DataSource = enSystemConstant;
            //stop perform if elements have 'Enabled' -> false
            if (!ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = false;
        }

        //action 'Delete' exist object from grid
        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            DictionaryService dictService = GetInstance();
            //delete selected item of grid by field 'Code'
            SystemConstant item = _systemConstantList[indexSelectedElem];
            bool result = CheckAfterDelete(item.CodeI);
            //update data for grid
            gridSystemConstantList.DataSource = HandleDataForGrid(urlDataGrid);
            //step up in grid position
            if (result) --indexSelectedElem;
            if (indexSelectedElem < 0) indexSelectedElem = 0;
            gridSystemConstantList.CurrentRow = gridSystemConstantList.Rows[indexSelectedElem];
            int codeNew = SystemConstantList[indexSelectedElem].CodeI;
            DataUpdateForBottomPanel(codeNew);
        }

        /// <summary>
        /// control delete state
        /// </summary>
        /// <param name="codeI"></param>
        /// <returns></returns>
        private bool CheckAfterDelete(int codeI)
        {
            DictionaryService dictService = GetInstance();
            bool result = dictService.DeleteCreativeRoleType(codeI);
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
            if (btnSaveSystemConstant.Text == "Додати")
            {
                //send created object
                SystemConstant result = CheckAfterCreate(systemConstantData);
                codeIAfter = result.CodeI;
                //update data for grid
                gridSystemConstantList.DataSource = HandleDataForGrid(urlDataGrid);
                indexSelectedElem = _systemConstantList.FindIndex(el => el.CodeI == result.CodeI);
                //select certain item into grid
                gridSystemConstantList.CurrentRow = gridSystemConstantList.Rows[indexSelectedElem];
                btnSaveSystemConstant.Text = "Зберегти";
            } else if (btnSaveSystemConstant.Text == "Зберегти")
            {
                //save changes
                SystemConstant result = CheckAfterUpdate(systemConstantData);
                codeIAfter = result.CodeI;
                //save last selected item
                indexSelectedElem = gridSystemConstantList.CurrentRow.Index;
                //update data for grid
                gridSystemConstantList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridSystemConstantList.CurrentRow = gridSystemConstantList.Rows[indexSelectedElem];
            }
            DataUpdateForBottomPanel(codeIAfter);
            //stop perform if elements have 'Enabled' -> true
            if (ControlEnabledActiveElements) return;
            //change 'Enabled' state for elements
            ControlEnabledActiveElements = true;
        }

        /// <summary>
        /// check result data after 'Craete'
        /// </summary>
        /// <param name="createItem"></param>
        /// <returns></returns>
        private SystemConstant CheckAfterCreate(SystemConstant createItem)
        {
            DictionaryService dictService = GetInstance();
            SystemConstant result = dictService.CreateSystemConstant(createItem);
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = SystemConstantList[0];
            }
            return result;
        }

        /// <summary>
        /// check result data after 'Update'
        /// </summary>
        /// <param name="updateItem"></param>
        /// <returns></returns>
        private SystemConstant CheckAfterUpdate(SystemConstant updateItem)
        {
            DictionaryService dictService = GetInstance();
            SystemConstant result = dictService.UpdateSystemConstant(systemConstantData);
            if (result == null)
            {
                MessageBox.Show("Помилка формату");
                //select first element of grid by default
                result = SystemConstantList[0];
            }
            return result;
        }

        //action 'Cancel' reset changed data for selected item
        private void btnCancel_Click(object sender, EventArgs e)
        {
            int codeICurrent = SystemConstantList[indexSelectedElem].CodeI;
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
        private void txtUkLangSystemConstant_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// changed data of the field 'Ru'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRuLangSystemConstant_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// changed data of the field 'En'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEnLangSystemConstant_KeyPress(object sender, KeyPressEventArgs e)
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

        //allow input only number data
        private void txtCodeSystemConstant_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it 'number' or 'Backspace' -> allow input
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
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
                return;
            }
            else
                //disallow input
                e.Handled = true;
        }
    }
}
