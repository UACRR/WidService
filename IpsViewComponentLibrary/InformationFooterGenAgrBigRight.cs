using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class InformationFooterGenAgrBigRight : UserControl
    {
        public InformationFooterGenAgrBigRight()
        {
            InitializeComponent();
        }

        public object DataSourceLicense
        {
            get => bsVbrLicense.DataSource;
            set
            {
                bsVbrLicense.DataSource = value;
                if (int.TryParse(bindRequest.Text, out int req) && int.TryParse(bindReference.Text, out int refer))
                    activeRequestReference.TextValue = (req + refer).ToString();
                else
                    activeRequestReference.TextValue = "0";
            }
        }
    }
}
