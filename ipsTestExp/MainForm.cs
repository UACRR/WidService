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
    public partial class MainForm:RadForm
    {
        private readonly ApiConnector conn = new ApiConnector("http://localhost:54867/");
        private bool isAdd = false, isEdit = false, isSaveEdit = false;

        
        public MainForm()
        {
            InitializeComponent();
            LoadControls();
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

                isSaveEdit = false;
                ChangePanelComponents(0);
            }

            if (isEdit)
            {
                ChangePanelComponents(1);
                dataChangeControl.SetEditData();
                isSaveEdit = true;
                isEdit = false;
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
