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
        SystemConstantTr ukSystemConstant;
        //Ru data item
        SystemConstantTr ruSystemConstant;
        //En data item
        SystemConstantTr enSystemConstant;
        //data grid
        List<SystemConstant> _systemConstantList;
        //item data
        SystemConstant systemConstantData;
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
            _systemConstantList = _connector.GetList<SystemConstant>(urlForGetDataDictionaries);
            //initialize grid data
            foreach (var item in _systemConstantList)
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
            totalSystemConstant.Text = _systemConstantList.Count.ToString();
            return dataGrid;
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
            if (codeForRefresh == 0) codeForRefresh = _systemConstantList[0].CodeI;
            //get object by parameter 'code' from service
            systemConstantData = dictService.GetSystemConstant(codeForRefresh);
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

        //action 'Add' new object to grid
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            //change property 'Text' of the btnSave for 'Add' action
            btnSaveSystemConstant.Text = "Додати";
            //clear data into bottom panel
            //refresh data for field 'Code'
            systemConstantData = new SystemConstant();
            bsSystemConstant.DataSource = systemConstantData;
            //refresh data for field 'Uk'
            ukSystemConstant = new SystemConstantTr();
            systemConstantData.SystemConstantTr.Add(ukSystemConstant);
            bsUkLangSystemConstant.DataSource = ukSystemConstant;
            //refresh data for field 'Ru'
            ruSystemConstant = new SystemConstantTr();
            systemConstantData.SystemConstantTr.Add(ruSystemConstant);
            bsRuLangSystemConstant.DataSource = ruSystemConstant;
            //refresh data for field 'Ru'
            enSystemConstant = new SystemConstantTr();
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
            //for save last index selected item
            int current = 0;

            DictionaryService dictService = new DictionaryService();
            if (btnSaveSystemConstant.Text == "Додати")
            {
                //send created object
                var result = dictService.CreateSystemConstant(systemConstantData);
                //set default state for 'Text' of the btnSave
                btnSaveSystemConstant.Text = "Зберегти";
                //save last selected item
                current = gridSystemConstantList.CurrentRow.Index;
                //update data for grid
                gridSystemConstantList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridSystemConstantList.CurrentRow = result != null ? gridSystemConstantList.Rows[gridSystemConstantList.RowCount - 1]
                                                                  : gridSystemConstantList.Rows[current];
            } else if (btnSaveSystemConstant.Text == "Зберегти")
            {
                //save changes
                var result = dictService.UpdateSystemConstant(systemConstantData);
                //save last selected item
                current = gridSystemConstantList.CurrentRow.Index;
                //update data for grid
                gridSystemConstantList.DataSource = HandleDataForGrid(urlDataGrid);
                //select certain item into grid
                gridSystemConstantList.CurrentRow = gridSystemConstantList.Rows[current];
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

        //allow input only number data
        private void txtCodeSystemConstant_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if it 'number' or 'Backspace' -> allow input
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else
                //disallow input
                e.Handled = true;
        }
    }
}
