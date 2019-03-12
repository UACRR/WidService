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
        public BaseCopyrightKindControl(ApiConnector connector, string urlForComplexDict)
        {
            InitializeComponent();
            //initialize connector
            _connector = connector;
            //setup search posibility for textBox element
            txtSearchComplex.SetUsageGrid(gvCopyrightKindList);
            //initialize data for drop down list - 'Спосіб використання'
            ddlCommonKeyData.DataSource = InitializeDataForFilter();
            dictBaseTypeIBindingSource.DataSource = ddlCommonKeyData.DataSource;
            //initialize data for grid
            gvCopyrightKindList.DataSource = HandleDataForGrid(urlForComplexDict);
            
        }
        
        //handle data for grid
        private List<ViewTable> HandleDataForGrid(string urlForGetDataDictionaries)
        {
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
                //show current count elements into grid
                total.Text = _copyrightKindList.Count.ToString();
            }
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
            var @curRow = rowDetail.DataBoundItem as ViewTable;
            if (@curRow == null) return;

            DictionaryService dictService = new DictionaryService();
            CopyrightKind copyrightKindData = dictService.GetCopyrightKind( int.Parse(@curRow.Code));
            if (copyrightKindData == null) return;
            dsCopyrightKind.DataSource = copyrightKindData;
            SetupBindSourcw(copyrightKindData, "Uk", bindingSourceUk );
            SetupBindSourcw(copyrightKindData, "Ru", bindingSourceRu );
            SetupBindSourcw(copyrightKindData, "En", bindingSourceEn );
        }

        private void SetupBindSourcw(CopyrightKind copyrightKindData, string Lang, BindingSource dest)
        {
            var copyKind = copyrightKindData.CopyrightKindTr.FirstOrDefault(rec => rec.Lang == Lang);
            if (copyKind == null)
            {
                copyKind = new CopyrightKindTr { Lang = Lang };
                copyrightKindData.CopyrightKindTr.Add(copyKind);
            }
            dest.DataSource = copyKind;
        }
    }
}
