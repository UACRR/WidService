using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class FormRightHolderGroup : Form
    {
        private Dictionary<string, FormExceptionSet.GenericRightHolder> genericRightHolders;
        public string genericRightHolder;

        public FormRightHolderGroup(Dictionary<string, FormExceptionSet.GenericRightHolder> genericRightHolders)
        {
            InitializeComponent();
            this.genericRightHolders = genericRightHolders;
        }

        private void FormRightHolderGroup_Load(object sender, EventArgs e)
        {

        }

        private void radBtnAdd_Click(object sender, EventArgs e)
        {
            if (genericRightHolders.ContainsKey(radTbName.Text))
            {
                MessageBox.Show("Правовласники з такою узагальненою назвою вже додані до списку виключень", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cnt = 0;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select count(*) from WID_IPI..TBLIPINAME where name like @name";
                cmd.Parameters.AddWithValue("@name", $"%{radTbName.Text}%");
                cnt = (int)cmd.ExecuteScalar();
            });

            if (cnt == 0)
            {
                MessageBox.Show("Не знайдено жодного правовласника, що відповідає введеній загальній назві", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cnt > 1000)
            {
                if (MessageBox.Show($"Знайдено {cnt} правовласників, що відповідають введеній загальній назві. Продовжити?"
                    , "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            genericRightHolder = radTbName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
