using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary
{
    public partial class RightholderPersonInfo : UserControl
    {
        private AnketaDictionaties _dictionaries;

        public RightholderPersonInfo()
        {
            InitializeComponent();
        }

        public void SetDictionaries(AnketaDictionaties dictionaries)
        {
            _dictionaries = dictionaries;
        }

        public void SetData(AnketaPerson anketa)
        {
            lblName.Text = anketa.LastName + " " + anketa.FirstName + " " + anketa.SurName;
            lblBirthDate.Text = anketa.BirthDate.ToString();
            lblSex.Text = _dictionaries.sexType.FirstOrDefault(s => s.CodeI == anketa.Sex)?.Name;
        }
    }
}
