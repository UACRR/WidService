using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerControls.Places.Components;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class PlaceDetailForm : RadForm
    {
        private readonly Size _standartSize = new Size(600, 236);
        private readonly Size _premisesSize = new Size(600, 410);
        private readonly Size _additionallySize = new Size(0, 0);

        private readonly ClnBusinessPlace _businessPlace;

        private PremisesControl _premisesControl;
        private SingleParameterCountControl _singleParameterControl;
        private SingleParameterSquareControl _singleParameterSquareControl;

        private SingleAdditionalParameterControl _singleAdditionalParameterControl;

        public PlaceDetailForm(ClnBusinessPlace businessPlace)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            internalPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            _businessPlace = businessPlace;
            ctrlPlaceParameters.BusinessPlaceDataSource = _businessPlace;

            //SetupPremisesForm();
            SetupStandartForm();
        }

        private void SetupPremisesForm()
        {
            _premisesControl = new PremisesControl
            {
                Dock = DockStyle.Fill,
                PlaceHollDataSource = _businessPlace.ClnPlaceHoll,
            };
            internalPanel.Controls.Add(_premisesControl);

            Size = _premisesSize;
            MinimumSize = _premisesSize;
        }

        private void SetupStandartForm()
        {
            _singleParameterControl = new SingleParameterCountControl
            {
                Location = new Point(13, 5),
                DataSource = _businessPlace,
            };
            internalPanel.Controls.Add(_singleParameterControl);

            Size = _standartSize;
            MinimumSize = _standartSize;
        }
    }
}
