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
    internal interface IExtraDicRow
    {
        int CodeI { get;  }
        int? parentId { get; }
        string nameEn { get; set; }
        string nameUk { get; set; }
        string nameRu { get; set; }

    }

    internal class BindExtraGrpRow : IExtraDicRow
    {
        private CrkindGroup _body;

        public BindExtraGrpRow(CrkindGroup item )
        {
            _body = item;
        }
        int IExtraDicRow.CodeI { get => _body.CodeI; }

        int? IExtraDicRow.parentId => null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        private CrkindGroupTr getTr( string lang )
        {
            var trRow = _body.CrkindGroupTr.Where(row => row.Lang == lang).SingleOrDefault();
            if (trRow != null) return trRow;

            CrkindGroupTr newItem = new CrkindGroupTr { CodeI = _body.CodeI, Lang = lang, Name = "" };
            _body.CrkindGroupTr.Add(newItem);
            return newItem;
        }
        string IExtraDicRow.nameEn { get => getTr("En").Name; set => getTr("En").Name = value; }
        string IExtraDicRow.nameUk { get => getTr("Uk").Name; set => getTr("Uk").Name = value; }
        string IExtraDicRow.nameRu { get => getTr("Ru").Name; set => getTr("Ru").Name = value; }
    }

    internal class BindExtraKindRow : IExtraDicRow
    {
        private CopyrightKind _body;

        public BindExtraKindRow(CopyrightKind item)
        {
            _body = item;
        }
        int IExtraDicRow.CodeI { get => _body.CodeI; }

        int? IExtraDicRow.parentId => _body.CrGroupCode;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        private CopyrightKindTr getTr(string lang)
        {
            var trRow = _body.CopyrightKindTr.Where(row => row.Lang == lang).SingleOrDefault();
            if (trRow != null) return trRow;

            CopyrightKindTr newItem = new CopyrightKindTr { CodeI = _body.CodeI, Lang = lang, Name = "" };
            _body.CopyrightKindTr.Add(newItem);
            return newItem;
        }
        string IExtraDicRow.nameEn { get => getTr("En").Name; set => getTr("En").Name = value; }
        string IExtraDicRow.nameUk { get => getTr("Uk").Name; set => getTr("Uk").Name = value; }
        string IExtraDicRow.nameRu { get => getTr("Ru").Name; set => getTr("Ru").Name = value; }
    }


    public partial class MainForm:RadForm
    {
        private readonly ApiConnector conn = new ApiConnector("http://localhost:54867/");
        private bool isAdd = false, isEdit = false, isSaveEdit = false;

        
        public MainForm()
        {
            InitializeComponent();
            LoadControls();
            LoadGridControl();
            LoadIntoGridViewSelfRef();
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


        void LoadIntoGridViewSelfRef()
        {
            var list = conn.GetList<CrkindGroup>("api/Dictionary/extra/crkindgroup");
            var bindForList = from item in list
                              select  new BindExtraGrpRow(item);


            radGridViewSelfRef.Relations.AddSelfReference(radGridViewSelfRef.MasterTemplate, "CodeI", "CrGroupCode");
            radGridViewSelfRef.DataSource = list;
            radGridViewSelfRef.MasterTemplate.SelfReferenceExpanderColumn = radGridViewSelfRef.Columns["CrGroupCode"];

        }

        private void LoadGridControl()
        {
            comDirControl.InitializeConnector(conn);
            comDirControl.Url = "api/Dictionary/extra/crkindgroup";
            comDirControl.ViewData();
        }



        private void rBtnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            isSaveEdit = false;
            ChangePanelComponents(0);
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

            if(dataChangeControl!=null)
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
