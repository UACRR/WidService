using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    public partial class CommonPlaceParametersControl : UserControl
    {
        public CommonPlaceParametersControl()
        {
            InitializeComponent();
            if (IpsGlobal.AnketaDictionaties != null)
            {
                bsDictRegion.DataSource = IpsGlobal.AnketaDictionaties.region;
                bsDictTypePlace.DataSource = IpsGlobal.AnketaDictionaties.typePlace;
            }
        }


        public object BusinessPlaceDataSource
        {
            get => bsClnBusinessPlace.DataSource;
            set
            {
                if (value == null)
                {
                    bsClnBusinessPlace.DataSource = typeof(ClnBusinessPlace);
                    return;
                }

                bsClnBusinessPlace.DataSource = value;
                txtPlaceType.Text = (bsDictTypePlace.DataSource as List<TypePlace>)?.SingleOrDefault(rec => rec.CodeI == (value as ClnBusinessPlace)?.PlCode)?.Name;
            }
        }

        private bool Validator()
        {
            bool isValid = true;

            if (txtPlaceName.Text == string.Empty)
            {
                isValid = false;
                rLblName.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                rLblName.ForeColor = Color.Black;

            return isValid;
        }
    }
}
