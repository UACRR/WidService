using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ManagersControl : UserControl
    {
        private List<Employee> _sourceGridEmployees;
        private ContactPersonActionForm _contactPersonForm;
        private Customer _customer;
        public ManagersControl()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer cust)
        {
            _customer = cust;

            var relEmpl = _customer.Company?.RelEmployee?.FirstOrDefault(rec => rec.PositionCode == 1);
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
            
            SetGridDataSource();
        }

        public bool Validator()
        {
            return ctrlHeadBoss.Validator() && ctrlBookkeeper.Validator();
        }

        private void SetGridDataSource()
        {
            var source = _customer.Company?.RelEmployee?.Where(rec => rec.PositionCode >= 3);
            _sourceGridEmployees = new List<Employee>();
            foreach (var relEmployee in source)
                _sourceGridEmployees.Add(relEmployee.Empl);

            bsEmployee.DataSource = _sourceGridEmployees;
            bsEmployee.ResetBindings(true);
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            var temp = new RelEmployee
            {
                CustId = _customer.CustId,
                Empl = new Employee {CustId = _customer.CustId,},
                PositionCode = _customer.Company.RelEmployee.Any(rec => rec.PositionCode == 3) ? 4 : 3
            };


            _contactPersonForm = new ContactPersonActionForm(temp, FLoadType.Create)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (_contactPersonForm.ShowDialog() == DialogResult.OK)
            {
                _customer.Company?.RelEmployee.Add(temp);
            }

            SetGridDataSource();
        }

        private void gvContactPersons_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var item = _customer.Company?.RelEmployee.SingleOrDefault(rec => rec.Empl == e.Row.DataBoundItem as Employee);

            switch (e.Column.FieldName)
            {
                case "deleteBtn":
                    if (MessageBox.Show("Видалити контакту особу?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _customer.Company?.RelEmployee.Remove(item);
                    }
                    break;
                case "editBtn":
                    var temp = new RelEmployee
                    {
                        Empl = new Employee()
                    };
                    temp.SetFields(item);
                    temp.Empl.SetFields(item.Empl);
                    _contactPersonForm = new ContactPersonActionForm(temp, FLoadType.Edit)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    if (_contactPersonForm.ShowDialog() == DialogResult.OK)
                    {
                        item.SetFields(temp);
                        item.Empl.SetFields(temp.Empl);
                    }
                    break;
            }
            SetGridDataSource();
        }
    }
}
