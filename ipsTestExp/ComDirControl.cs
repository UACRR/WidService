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
        private CurrentRowChangedEventArgs tempE;
        private ApiConnector connector;
        public string Url { get; set; }
        public ComDirControl()
        {
            InitializeComponent();
            //CreateUnboundHierarchy();
        }


        #region ALL METHODS



        /// <summary>
        /// Дані для верхнього рівня ієрархії
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

        /// <summary>
        /// Дані для нижнього рівня ієрархії
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Виклик серії методів в класах, що використовують контрол для формування і виведення даних на грід 
        /// </summary>
        public void ViewData()
        {
            try
            {
                CreateHierarchy();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Ініціалізатор конектора
        /// </summary>
        /// <param name="apiCon"></param>
        public void InitializeConnector(ApiConnector apiCon)
        {
            connector = apiCon;
        }

        public void GetDataForChange()
        {
            
        }

        #endregion

        /// <summary>
        /// Створення ієрархії 
        /// </summary>
        private void CreateHierarchy()
        {
            using (this.rGViewComDir.DeferRefresh())
            {
                this.rGViewComDir.MasterTemplate.Reset();

                SetupMaster();

                GridViewTemplate template = SetupChild();
                
                GridViewRelation relation = new GridViewRelation(this.rGViewComDir.MasterTemplate, template);
                relation.RelationName = "Relation";
                relation.ParentColumnNames.Add("Code");
                relation.ChildColumnNames.Add("Code");
                
                
                rGViewComDir.Relations.Add(relation);
            }
                this.rGViewComDir.ChildRows[0].IsExpanded = true;
        }

        /// <summary>
        /// Верхній рівень ієрархії - заголовки
        /// </summary>
        private void SetupMaster()
        {
            this.rGViewComDir.TableElement.RowHeight = 40;

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

        /// <summary>
        /// Дочірній рівень ієрархії - заголовки
        /// </summary>
        /// <returns></returns>
        private GridViewTemplate SetupChild()
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
            
            this.rGViewComDir.Templates.Add(template);

            LoadData();
            
            template.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            foreach (var row in template.Rows)
            {
                row.Height = 100;
            }
            
            return template;
        }

        /// <summary>
        /// Заповнення даними ієрархії
        /// </summary>
        private void LoadData()
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

        #endregion

    }
}
