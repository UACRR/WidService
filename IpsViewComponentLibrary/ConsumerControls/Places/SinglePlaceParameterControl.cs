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

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class SinglePlaceParameterControl : UserControl
    {
        private const string FullCount = "К-сть місць";
        private const string FullArea = "Площа";
        private MeasurementOfPlaces _placesType = MeasurementOfPlaces.Empty;

        public SinglePlaceParameterControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Тип приміщення
        /// </summary>
        public MeasurementOfPlaces PlaceType
        {
            get => _placesType;
            set
            {
                _placesType = value;
                switch (value)
                {
                    case MeasurementOfPlaces.Area:
                        titleParametr.Text = FullArea;
                        break;
                    case MeasurementOfPlaces.Number:
                        titleParametr.Text = FullCount;
                        break;
                    case MeasurementOfPlaces.Empty:
                        titleParametr.Text = string.Empty;
                        break;
                }
            }
        }



        /// <summary>
        /// Джерело даних майданчиків/приміщень
        /// </summary>
        public object BusinessPlaceDataSource
        {
            get => bsClnBusinessPlace.DataSource;
            set
            {
                bsClnBusinessPlace.DataSource = value;
                if ((value as ClnBusinessPlace)?.ClnPlaceHoll?.SingleOrDefault() is ClnPlaceHoll placeHoll)
                {
                    bsClnPlaceHoll.DataSource = placeHoll;
                }

                txtPlaceType.Text = (bsDictTypePlace.DataSource as List<TypePlace>)?.SingleOrDefault(rec => rec.CodeI == (value as ClnBusinessPlace)?.PlCode)?.Name;
            }
        }

        /// <summary>
        /// Словник регіонів
        /// </summary>
        public object DictionaryRegion
        {
            get => bsDictRegion.DataSource;
            set => bsDictRegion.DataSource = value;
        }

        /// <summary>
        /// Словник типу майданчиків
        /// </summary>
        public object DictionaryTypePlace
        {
            get => bsDictTypePlace.DataSource;
            set => bsDictTypePlace.DataSource = value;
        }
    }
}
