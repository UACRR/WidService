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
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlManagers : UserControl, IMiddleCtrlAnketaConsumer
    {
        public MiddleControlManagers()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties)
        {
            AnketaCompany anketa = cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec?.Version == cust?.AnkVersion);
            anketaCompanyBindingSource.DataSource = anketa;

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

            var relEmplContPers = cust?.Company?.RelEmployee?.FirstOrDefault(rec => rec?.PositionCode == 3);
            if (relEmplContPers == null)
            {
                relEmplContPers = new RelEmployee { Empl = new Employee(), PositionCode = 3 };
                cust?.Company?.RelEmployee?.Add(relEmplContPers);
            }
            ctrlContactPerson.DataSource = relEmplContPers.Empl; // - - - Контакта особа


        }

        public bool Validator()
        {
            return ctrlHeadBoss.Validator() && ctrlBookkeeper.Validator() && ctrlContactPerson.Validator();
        }
    }
}
