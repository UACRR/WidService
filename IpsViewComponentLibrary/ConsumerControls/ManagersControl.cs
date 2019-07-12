using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using ipsFormsDesign;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ManagersControl : UserControl
    {
        private const string ConfirmDeleteContactPersonMsg = "Видалити контакту особу?";

        private List<Employee> _sourceGridEmployees;
        private ContactPersonActionForm _contactPersonForm;
        private Customer _customer;

        public ManagersControl()
        {
            InitializeComponent();
            gvContactPersons.ToolTipTextNeeded += GvContactPersons_ToolTipTextNeeded;
        }

        private void GvContactPersons_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        public void SetDataSources(Customer cust)
        {
            _customer = cust;

            // на основі чого діє
            var relEmpl = _customer.Company?.RelEmployee?.FirstOrDefault(rec => rec.PositionCode == 1);
            if (relEmpl == null)
            {
                relEmpl = new RelEmployee { Empl = new Employee(), PositionCode = 1 };
                cust?.Company?.RelEmployee?.Add(relEmpl);
            }
            bsRelEmployeeBoss.DataSource = relEmpl;

            // керівник
            ctrlHeadBoss.DataSource = relEmpl.Empl;

            var relEmplBuh = cust?.Company?.RelEmployee?.FirstOrDefault(rec => rec?.PositionCode == 2);
            if (relEmplBuh == null)
            {
                relEmplBuh = new RelEmployee { Empl = new Employee(), PositionCode = 2 };
                cust?.Company?.RelEmployee?.Add(relEmplBuh);
            }

            // бухгалтер
            ctrlBookkeeper.DataSource = relEmplBuh.Empl; 
            
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


            _contactPersonForm = new ContactPersonActionForm(temp, FLoadType.Create);

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
                    if (MessageShow.ConfirmAction(ConfirmDeleteContactPersonMsg) == DialogResult.Yes)
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
                    _contactPersonForm = new ContactPersonActionForm(temp, FLoadType.Edit);

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
