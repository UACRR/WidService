using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    public partial class GeneralAgrDetailInfoBr : UserControl
    {
        public GeneralAgrDetailInfoBr()
        {
            InitializeComponent();
        }

        public object DataSourceLicense
        {
            get => bsVbrLicense.DataSource;
            set
            {
                bsVbrLicense.DataSource = value;
                if (value is ipsFormsDesign.Interfaces.ConsumerBigRightView view)
                    txtActiveReqAndRef.Text = (view.CountLic2Active + view.CountLic3Active).ToString();
            }
        }
    }
}
