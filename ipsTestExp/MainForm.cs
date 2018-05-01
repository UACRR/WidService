using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ipsTestExp;
using System.Windows.Forms;
using sysAdminwp;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using WebAPIConnector;
using ipsmedserviceapp;
using ipsmedserviceapp.Model;


namespace ipsTestExp
{

    public partial class MainForm : RadForm
    {
        private readonly ApiConnector conn = new ApiConnector("http://localhost:54867/");
        private bool isAdd = false, isEdit = false, isSaveEdit = false;


        public MainForm()
        {
            InitializeComponent();
            LoadControls();
            LoadGridControl();
            LoadSelfRefData();
        }

        /// <summary>
        /// Завантаження контролів
        /// </summary>
        private void LoadControls()
        {
            dataEditControl.InitializeConnector(conn);
            dataEditControl.Url = "api/dictionary/base/activitytype";
            dataEditControl.ViewData();
            dataEditControl.LoadOverviewCfg();
        }

        private void LoadGridControl()
        {
            comDirControl.InitializeConnector(conn);
            comDirControl.Url = "api/Dictionary/extra/crkindgroup";
            comDirControl.ViewData();
        }

        void ExpandAllRows(GridViewTemplate template, bool expanded)
        {
            foreach (GridViewRowInfo row in template.Rows)
            {
                row.IsExpanded = expanded;
            }
            if (template.Templates.Count > 0)
            {
                foreach (GridViewTemplate childTemplate in template.Templates)
                {
                    ExpandAllRows(childTemplate, true);
                }
            }
        }

        private void LoadSelfRefData()
        {
            var originList = conn.GetList<CrkindGroup>("api/Dictionary/extra/crkindgroup");
            BindingList<IDicRow> listItems = new BindingList<IDicRow>();
            (from itemGrp in originList
             select new DicGroup(itemGrp))
                    .ToList()
                    .ForEach(item => item.getDicItems().ForEach(dicRow => listItems.Add(dicRow)));

            this.radGridView2.Relations.AddSelfReference(this.radGridView2.MasterTemplate, "Code", "ParentCode");
            this.radGridView2.MasterTemplate.SelfReferenceExpanderColumn = this.radGridView2.Columns["ParentCode"];
            radGridView2.DataSource = listItems;

            ExpandAllRows(radGridView2.MasterTemplate, true);
        }



        private void rBtnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            isSaveEdit = false;
            ChangePanelComponents(0);
        }


        private void radGridView2_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Row.DataBoundItem != null 
                && e.Row.DataBoundItem is DicKind 
                && e.CellElement.ColumnInfo.FieldName.Contains("Name")
                && e.CellElement.Padding.Left != 20 )
            {
                e.CellElement.Padding = new Padding( 20,0,0,0);
            }
            if (e.Row.DataBoundItem != null && e.Row.DataBoundItem is DicGroup && e.CellElement.Padding.Left != 0)
            {
                e.CellElement.Padding = new Padding(0,0,0,0);
            }
        }

 

        private void rBtnEdit_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                dataChangeControl.AddNewItem();//додає новий елемент 
                ChangePanelComponents(0);
            }
            else
            {
                isEdit = true;
            }

            if (isSaveEdit)
            {
                //method
                dataChangeControl.SaveEditItem();
                isSaveEdit = false;
                ChangePanelComponents(0);
            }

            if (isEdit)
            {
                var data = comDirControl.GetDataForChange();
                if (data != null)
                {
                    ChangePanelComponents(1);
                    dataChangeControl.SetEditData(data);
                    isSaveEdit = true;
                    isEdit = false;
                }
            }

            if (dataChangeControl != null)
                comDirControl.ViewData();
        }


        /// <summary>
        /// Зміна компонентів
        /// </summary>
        private void ChangePanelComponents(byte typeVisible)
        {
            comDirControl.Visible = !comDirControl.Visible;
            if (dataChangeControl == null)
            {
                InitializeDataChangeControl();
                dataChangeControl.InitializeConnectorAndUrl(conn, "api/Dictionary/extra/crkindgroup");
                dataChangeControl.SetGroupDropList();
                dataChangeControl.SetVisible(typeVisible);
            }
            else
            {
                comDirControl.ViewData();
                dataChangeControl.Dispose();
                dataChangeControl = null;
                isAdd = false;
            }


            //зміна тексту на кнопках
            if (rBtnAddOrCancel.Text != "Відміна" && rBtnEditOrSave.Text != "Зберегти")
            {
                rBtnAddOrCancel.Text = "Відміна";
                rBtnEditOrSave.Text = "Зберегти";
            }
            else
            {
                rBtnAddOrCancel.Text = "Додати";
                rBtnEditOrSave.Text = "Змінити";
            }
        }
    }

}
