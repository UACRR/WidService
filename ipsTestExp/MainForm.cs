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
        private bool isAdd = false;

        
        public MainForm()
        {
            InitializeComponent();
            LoadControls();
        }

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

        private CrkindGroup PackageData()
        {
            

            return new CrkindGroup();
        }

        private void rBtnAdd_Click(object sender, EventArgs e)
        {
            ChangePanelComponents();
        }

        private void rBtnEdit_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                //var v = dataChangeControl.PackageData();
                //conn.NewItem(comDirControl.Url,  v);
                dataChangeControl.AddNewItem();
                isAdd = false;
                ChangePanelComponents();
            }
            else
            {
                
            }
        }


        /// <summary>
        /// Зміна компонентів
        /// </summary>
        private void ChangePanelComponents()
        {
            comDirControl.Visible = !comDirControl.Visible;
            if (dataChangeControl == null)
            {
                InitializeDataChangeControl();
                dataChangeControl.InitializeConnectorAndUrl(conn, "api/Dictionary/extra/crkindgroup");
                dataChangeControl.SetGroupDropList();
                isAdd = true;

            }
            else
            {
                dataChangeControl.Dispose();
                dataChangeControl = null;
                isAdd = false;
            }

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
