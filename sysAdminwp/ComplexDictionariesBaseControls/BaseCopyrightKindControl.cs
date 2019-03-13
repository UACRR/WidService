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
        //data grid
        List<CopyrightKind> _copyrightKindList;
        //define connector
        private readonly ApiConnector _connector;
        //url for get data to grid
        private readonly string urlDataGrid;
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
            
            DictionaryService dictService = new DictionaryService();

            //check field 'Code' on correct type 'int'
            if (!int.TryParse(@curRow.Code, out int code)) return;
            //get object by parameter 'code' from service
            CopyrightKind copyrightKindData = dictService.GetCopyrightKind(code);
            //stop perform if data is not exist
            if (copyrightKindData == null) return;
            //use data for binding source
            dsCopyrightKind.DataSource = copyrightKindData;
            //define binding for source of the 'Uk'
            SetupBindSourcw(copyrightKindData, "Uk", bindingSourceUk);
            //defined binding for source of the 'Ru'
            SetupBindSourcw(copyrightKindData, "Ru", bindingSourceRu);
            //define binding for source of the 'En'
            SetupBindSourcw(copyrightKindData, "En", bindingSourceEn);
        }

        //binding for textBox elements
        private void SetupBindSourcw(CopyrightKind copyrightKindData, string Lang, BindingSource dest)
        {
            // get object by 'Lang'
            var copyKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == Lang);
            if (copyKind == null)
            {
                copyKind = new CopyrightKindTr { Lang = Lang };
                copyrightKindData.CopyrightKindTr.Add(copyKind);
            }
            //use data for source
            dest.DataSource = copyKind;
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
    }
}
