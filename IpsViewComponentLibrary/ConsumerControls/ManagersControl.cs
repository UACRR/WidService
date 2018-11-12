using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerDialogForms;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ManagersControl : UserControl
    {
        private List<Employee> _sourceGridEmployees = new List<Employee>();
        private List<RelEmployee> _relEmployees;
        private int _custId;
        public ManagersControl()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer cust)
        {
            _custId = cust.CustId;
            AnketaCompany anketa = cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec?.Version == cust?.AnkVersion);
            bsAnketaCompany.DataSource = anketa;

            RelEmployee relEmpl = cust?.Company?.RelEmployee?.FirstOrDefault(rec => rec.PositionCode == 1);
            if (relEmpl == null)
            {
                relEmpl = new RelEmployee { Empl = new Employee(), PositionCode = 1 };
                cust?.Company?.RelEmployee?.Add(relEmpl);
            }

            txtOnBasicsIfHeadBoss.DataBindings.Clear();
            txtOnBasicsIfHeadBoss.DataBindings.Add("Text", relEmpl, "RelDocument", true); // на основі чого діє


            ctrlHeadBoss.DataSource = relEmpl.Empl;             // - - -  Керівник

            var relEmplBuh = cust?.Company?.RelEmployee?.FirstOrDefault(rec => rec?.PositionCode == 2);
            if (relEmplBuh == null)
            {
                relEmplBuh = new RelEmployee { Empl = new Employee(), PositionCode = 2 };
                cust?.Company?.RelEmployee?.Add(relEmplBuh);
            }
            ctrlBookkeeper.DataSource = relEmplBuh.Empl;         // - - - Бухгалтер

            _relEmployees = cust?.Company?.RelEmployee?.Where(rec => rec.PositionCode >= 3).ToList();
            SetGridDataSource();

            // rdnt
            //var relEmplContPers = cust?.Company?.RelEmployee?.FirstOrDefault(rec => rec?.PositionCode == 3);
            //if (relEmplContPers == null)
            //{
            //    relEmplContPers = new RelEmployee { Empl = new Employee(), PositionCode = 3 };
            //    cust?.Company?.RelEmployee?.Add(relEmplContPers);
            //}
            
        }

        public bool Validator()
        {
            return ctrlHeadBoss.Validator() && ctrlBookkeeper.Validator();
        }

        private void SetGridDataSource()
        {
            foreach (var relEmployee in _relEmployees)
                _sourceGridEmployees.Add(relEmployee.Empl);

            bsEmployee.DataSource = _sourceGridEmployees;
            bsEmployee.ResetBindings(true);
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            var temp = new RelEmployee
            {
                CustId = _custId,
                Empl = new Employee {CustId = _custId,},
                PositionCode = _relEmployees.Any(rec => rec.PositionCode == 3) ? 4 : 3
            };


            var contactPersonForm = new ContactPersonActionForm(temp, FLoadType.Create)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (contactPersonForm.ShowDialog() == DialogResult.OK)
                _relEmployees.Add(temp);
            
            SetGridDataSource();
        }

        private void gvContactPersons_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            bsSingleEmpl.DataSource = e?.CurrentRow.DataBoundItem as Employee;
        }

        private void gvContactPersons_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "deleteBtn":
                    if (MessageBox.Show("Видалити контакту особу?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        ;
                    break;
                case "editBtn":
                    break;
            }
        }
    }
}
