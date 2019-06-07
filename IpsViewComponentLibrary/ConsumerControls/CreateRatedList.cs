using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class CreateRatedList : Form
    {
        public CreateRatedList()
        {
            InitializeComponent();
        }

        private RegisterRatedList ratedList = null;
        public RegisterRatedList RatedList
        {
            get { return ratedList; }
            set {
                ratedList = value;
                setEnable();
            }
        }

        private void setEnable()
        {
            if( ratedList == null )
            {
                radTextPeriod.Enabled = false;
                radTextAmount.Enabled = false;
                radTextRoyalty.Enabled = false;
                radTextCntReport.Enabled = false;
                bindingSourceRatedList.DataSource = typeof( RegisterRatedList);
                bindingPeriod.DataSource = typeof(PaidPeriod);
            }
            else 
            {
                radTextPeriod.Enabled = false;
                radTextAmount.Enabled = true;
                radTextRoyalty.Enabled = true;
                radTextCntReport.Enabled = true;
                bindingSourceRatedList.DataSource = ratedList;
                bindingPeriod.DataSource = ratedList.Period;

            }
        }
    }
}
