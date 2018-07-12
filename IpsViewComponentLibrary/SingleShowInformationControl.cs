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
    [ComplexBindingProperties("ValueDataSource",  "ValueDataMemger")]
    public partial class SingleShowInformationControl : UserControl
    {
        private BindingSource _bindingSource = new BindingSource();
        private string _dataMember = string.Empty;
        private string _stringFormat = string.Empty;

        public SingleShowInformationControl()
        {
            InitializeComponent();
            splitContainer.IsSplitterFixed = true;
        }

        /// <summary>
        /// Джерело даних
        /// </summary>
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object ValueDataSource
        {
            get => _bindingSource.DataSource;
            set => _bindingSource.DataSource = value;
        }

        /// <summary>
        /// Назва поля для binding
        /// </summary>
        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string ValueDataMemger
        {
            get => _dataMember;
            set
            {
                if(_dataMember != value)
                {
                    _dataMember = value;
                    txtShow.DataBindings.Clear();
                    txtShow.DataBindings.Add("Text", _bindingSource, _dataMember, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty, _stringFormat);
                }
            }
        }

        /// <summary>
        /// Форматування тексту
        /// </summary>
        [Category("Data")]
        public string StringFormat
        {
            get => _stringFormat;
            set => _stringFormat = value;
        }



        /// <summary>
        /// Ширина зазви поля
        /// </summary>
        [Category("Data")]
        public int SplitterRatio
        {
            get => splitContainer.SplitterDistance;
            set => splitContainer.SplitterDistance = value;
        }

        [Category("Data")]
        public string TextTitle
        {
            get => lbltxtName.Text;
            set => lbltxtName.Text = value;
        }

        /// <summary>
        /// Значення текстового поля
        /// </summary>
        public string TextValue
        {
            get => txtShow.Text;
            set => txtShow.Text = value;
        }

        [Category("Data")]
        public ContentAlignment AlignmentTitle
        {
            get => lbltxtName.TextAlign;
            set => lbltxtName.TextAlign = value;
        }

        [Category("Data")]
        public ContentAlignment AlignmentValue
        {
            get => txtShow.TextAlignment;
            set => txtShow.TextAlignment = value;
        }
    }
}
