using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
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
        private readonly Size _additionallySize = new Size(600, 289);
        private readonly Point _pointForSingleParam = new Point(13, 5);

        private PremisesControl _premisesControl;
        private SingleParameterCountControl _singleParameterCountControl;
        private SingleParameterSquareControl _singleParameterSquareControl;
        private SingleAdditionalParameterControl _singleAdditionalParameterControl;

        private readonly ClnBusinessPlace _businessPlace;

        public PlaceDetailForm(ClnBusinessPlace businessPlace)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            internalPanel.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            _businessPlace = businessPlace;
            ctrlPlaceParameters.BusinessPlaceDataSource = _businessPlace;

            SetupPlaceForm();
        }

        private void SetupPlaceForm()
        {
            var placeCode = _businessPlace.PlCode;
            var typePlace = IpsGlobal.AnketaDictionaties.typePlace.SingleOrDefault(rec => rec.CodeI == placeCode);
            if (typePlace?.IsHoll ?? false)
            {
                SetupMultiplyPremisesForm();
                return;
            }

            switch (typePlace?.ParamType)
            {
                case 1:
                    SetupSingleSquareForm();
                    break;
                case 2:
                    SetupSingleCountForm();
                    break;
                case 3:
                    SetupSingleAdditionallyForm();
                    break;
            }
        }

        /// <summary>
        /// Параметр для бізнес-точок з наявними холами (приміщення)
        /// </summary>
        private void SetupMultiplyPremisesForm()
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

        /// <summary>
        /// Параметр для площі [1]
        /// </summary>
        private void SetupSingleSquareForm()
        {
            _singleParameterSquareControl = new SingleParameterSquareControl
            {
                Location = _pointForSingleParam,
                DataSource = _businessPlace,
            };
            internalPanel.Controls.Add(_singleParameterSquareControl);

            Size = _standartSize;
            MinimumSize = _standartSize;
        }

        /// <summary>
        /// Параметр для кількості місць [2]
        /// </summary>
        private void SetupSingleCountForm()
        {
            _singleParameterCountControl = new SingleParameterCountControl
            {
                Location = _pointForSingleParam,
                DataSource = _businessPlace,
            };
            internalPanel.Controls.Add(_singleParameterCountControl);

            Size = _standartSize;
            MinimumSize = _standartSize;
        }

        /// <summary>
        /// Параметр для іншого [3]
        /// </summary>
        private void SetupSingleAdditionallyForm()
        {
            _singleAdditionalParameterControl = new SingleAdditionalParameterControl
            {
                Dock = DockStyle.Fill,
                DataSource = _businessPlace,
            };
            internalPanel.Controls.Add(_singleAdditionalParameterControl);

            Size = _additionallySize;
            MinimumSize = _additionallySize;
        }
    }
}
