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
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
       
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly ApiConnector conn = new ApiConnector("http://localhost:54867/");
        private bool isAdd = false, isEdit = false, isSaveEdit = false;




        private void rBtnAdd_Click(object sender, EventArgs e)
        {
        }



        private void rBtnEdit_Click(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Зміна компонентів
        /// </summary>
        private void ChangePanelComponents(byte typeVisible)
        {
        }
    }

}
