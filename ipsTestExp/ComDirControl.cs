using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using sysAdminwp;
using Telerik.WinControls.UI;
using ipsmedserviceapp.Model;
using WebAPIConnector;

namespace ipsTestExp
{
    public partial class ComDirControl : UserControl
    {
        private ApiConnector connector;
        public string Url { get; set; }
        public ComDirControl()
        {
            InitializeComponent();
            //CreateUnboundHierarchy();
        }


        #region ALL METHODS

        private void SetupParent()
        {

        }

        /// <summary>
        /// Отримує дані з сервера та повертає у потрібному вигляді для контрола DataEditControl
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private List<ViewTable> GetDataParent(List<CrkindGroup> l)
        {
            List<ViewTable> view = new List<ViewTable>();
            ViewTable temp;
            foreach (var items in l)
            {
                temp = new ViewTable();
                temp.Code = items.CodeI;
                foreach (var itemName in items.CrkindGroupTr)
                {
                    if (itemName.Lang == "Uk")
                        temp.NameUk = itemName.Name;
                    if (itemName.Lang == "Ru")
                        temp.NameRu = itemName.Name;
                    if (itemName.Lang == "En")
                        temp.NameEn = itemName.Name;
                }
                view.Add(temp);
            }
            return view;
        }

        private List<ViewTableExt> GetDataChildren(List<CrkindGroup> l)
        {
            List<ViewTableExt> view = new List<ViewTableExt>();
            ViewTableExt temp;
            foreach (var allItems in l)
            {
                
                foreach (var childItemName in allItems.CopyrightKind)
                {
                    temp = new ViewTableExt();
                    temp.Index = allItems.CodeI;
                    temp.Code = childItemName.CodeI;
                    foreach (var itemName in childItemName.CopyrightKindTr)
                    {
                        
                        if (itemName.Lang == "Uk")
                            temp.NameUk = itemName.Name;
                        if (itemName.Lang == "Ru")
                            temp.NameRu = itemName.Name;
                        if (itemName.Lang == "En")
                            temp.NameEn = itemName.Name;
                    }
                    view.Add(temp);
                }
                
            }
            return view;
        }

        public void ViewData()
        {
            try
            {
                //rGViewComDir.DataSource = connector.GetList<CrkindGroup>(Url);
                //rGViewComDir.MasterTemplate.Columns["CodeI"].HeaderText = "Код";
                //rGViewComDir.MasterTemplate.Columns.Last().IsVisible = false;

                //rGViewComDir.DataSource = GetDataParent(connector.GetList<CrkindGroup>(Url));


                rGViewComDir.DataSource = GetDataChildren(connector.GetList<CrkindGroup>(Url));

                //Enabled = true;
            }
            catch (Exception e)
            {
                //Enabled = false;
            }
        }

        public void InitializeConnector(ApiConnector apiCon)
        {
            connector = apiCon;
        }

        #endregion

        public void CreateUnboundHierarchy()
        {
            using (this.rGViewComDir.DeferRefresh())
            {
                this.rGViewComDir.MasterTemplate.Reset();

                SetupMasterForUnbound();

                GridViewTemplate template = SetupChildForUnbound();
                
                GridViewRelation relation = new GridViewRelation(this.rGViewComDir.MasterTemplate, template);
                relation.RelationName = "Relation";
                relation.ParentColumnNames.Add("Code");
                relation.ChildColumnNames.Add("Code");
                
                
                rGViewComDir.Relations.Add(relation);
            }
                this.rGViewComDir.ChildRows[0].IsExpanded = true;
        }

        private void SetupMasterForUnbound()
        {
            this.rGViewComDir.TableElement.RowHeight = 50;
            //rGViewComDir.TableElement.BackColor=Color.DarkGray;
            rGViewComDir.TableElement.BorderColor=Color.Aqua;

            GridViewTextBoxColumn textColumnCode = new GridViewTextBoxColumn("Code");
            textColumnCode.Width = 10;
            
            textColumnCode.HeaderText = "Code";
            this.rGViewComDir.MasterTemplate.Columns.Add(textColumnCode);

            GridViewTextBoxColumn textColumnNameEn = new GridViewTextBoxColumn("NameEnP");
            textColumnNameEn.HeaderText = "Назва";
            this.rGViewComDir.MasterTemplate.Columns.Add(textColumnNameEn);

            GridViewTextBoxColumn textColumnNameRu = new GridViewTextBoxColumn("NameRuP");
            textColumnNameRu.HeaderText = "Название";
            this.rGViewComDir.MasterTemplate.Columns.Add(textColumnNameRu);

            GridViewTextBoxColumn textColumnNameUk = new GridViewTextBoxColumn("NameUkP");
            textColumnNameUk.HeaderText = "Name";
            this.rGViewComDir.MasterTemplate.Columns.Add(textColumnNameUk);

            //rGViewComDir.MasterTemplate.Rows[0].Cells[0].Style
            ((GridViewTextBoxColumn)this.rGViewComDir.Columns["Code"]).Multiline = true;
            ((GridViewTextBoxColumn)this.rGViewComDir.Columns["NameEnP"]).Multiline = true;
            ((GridViewTextBoxColumn)this.rGViewComDir.Columns["NameRuP"]).Multiline = true;
            ((GridViewTextBoxColumn)this.rGViewComDir.Columns["NameUkP"]).Multiline = true;


        }

        private GridViewTemplate SetupChildForUnbound()
        {
            GridViewTemplate template = new GridViewTemplate();
            template.AllowAddNewRow = true;
            

            GridViewTextBoxColumn textColumnCode1 = new GridViewTextBoxColumn("Code");
            textColumnCode1.IsVisible = false;
            //textColumnCode1.HeaderText = "Код";
            template.Columns.Add(textColumnCode1);

            GridViewTextBoxColumn textColumnCodeCh = new GridViewTextBoxColumn("CodeCh");
            textColumnCodeCh.Width = 10;
            textColumnCodeCh.HeaderText = "Код";
            template.Columns.Add(textColumnCodeCh);

            GridViewTextBoxColumn textColumnNameEnCh = new GridViewTextBoxColumn("NameEnCh");
            textColumnNameEnCh.HeaderText = "Опис";
            template.Columns.Add(textColumnNameEnCh);

            GridViewTextBoxColumn textColumnNameRuCh = new GridViewTextBoxColumn("NameRuCh");
            textColumnNameRuCh.HeaderText = "Описание";
            template.Columns.Add(textColumnNameRuCh);

            GridViewTextBoxColumn textColumnNameUkCh = new GridViewTextBoxColumn("NameUkCh");
            textColumnNameUkCh.HeaderText = "Description";
            template.Columns.Add(textColumnNameUkCh);

            textColumnNameEnCh.WrapText = true;
            textColumnNameRuCh.WrapText = true;
            textColumnNameUkCh.WrapText = true;

            textColumnNameEnCh.Multiline = true;
            textColumnNameRuCh.Multiline = true;
            textColumnNameUkCh.Multiline = true;

            //textColumnNameEnCh.Width = 
            //textColumnNameRuCh
            //textColumnNameUkCh

            //((GridViewTextBoxColumn)template.Columns["CodeCh"]).Multiline = true;
            //((GridViewTextBoxColumn)template.Columns["NameEnCh"]).Multiline = true;
            //((GridViewTextBoxColumn)template.Columns["NameRuCh"]).Multiline = true;
            //((GridViewTextBoxColumn)template.Columns["NameUkCh"]).Multiline = true;


            this.rGViewComDir.Templates.Add(template);

            LoadDataForUnbound();
            
            template.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            
            return template;
        }

        private void LoadDataForUnbound()
        {
            List<ViewTable> listParent;
            List<ViewTableExt>listChild;
            listParent = GetDataParent(connector.GetList<CrkindGroup>(Url));
            listChild = GetDataChildren(connector.GetList<CrkindGroup>(Url));

            //Random random = new Random((int)DateTime.Now.Ticks);
            GridViewTemplate template = this.rGViewComDir.MasterTemplate.Templates[0];

            foreach (var parent in listParent)
            {
                rGViewComDir.MasterTemplate.Rows.Add(parent.Code,parent.NameUk,parent.NameRu,parent.NameEn);
                foreach (var child in listChild)
                {
                    if (child.Index==parent.Code)
                    {
                        template.Rows.Add(child.Index, child.Code, child.NameUk, child.NameRu, child.NameEn);
                    }
                }
            }
        }

        #region ALL EVENTS

        private void rBtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void rBtnEdit_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
