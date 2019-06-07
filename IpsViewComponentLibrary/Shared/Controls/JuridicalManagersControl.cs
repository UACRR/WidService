using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class JuridicalManagersControl : UserControl
    {
        public JuridicalManagersControl()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer customer)
        {
            if (customer == null)
                return;

            var relEmpl = customer.Company?.RelEmployee?.FirstOrDefault(rec => rec.PositionCode == 1);
            if (relEmpl == null)
            {
                relEmpl = new RelEmployee { Empl = new Employee(), PositionCode = 1 };
                customer.Company?.RelEmployee?.Add(relEmpl);
            }

            bsRelEmployee.DataSource = relEmpl;
            ctrlHeadBoss.DataSource = relEmpl.Empl;             // - - -  Керівник

            var relEmplBuh = customer.Company?.RelEmployee?.FirstOrDefault(rec => rec?.PositionCode == 2);
            if (relEmplBuh == null)
            {
                relEmplBuh = new RelEmployee { Empl = new Employee(), PositionCode = 2 };
                customer.Company?.RelEmployee?.Add(relEmplBuh);
            }
            ctrlBookkeeper.DataSource = relEmplBuh.Empl;         // - - - Бухгалтер

            var relEmplContPers = customer.Company?.RelEmployee?.FirstOrDefault(rec => rec?.PositionCode == 3);
            if (relEmplContPers == null)
            {
                relEmplContPers = new RelEmployee { Empl = new Employee(), PositionCode = 3 };
                customer.Company?.RelEmployee?.Add(relEmplContPers);
            }
            ctrlContactPerson.DataSource = relEmplContPers.Empl; // - - - Контакта особа
        }

        public bool Validator()
        {
            return ctrlHeadBoss.Validator() && ctrlBookkeeper.Validator() && ctrlContactPerson.Validator();
        }
    }
}
