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
    public partial class SingleShowInformationControl : UserControl
    {
        public SingleShowInformationControl()
        {
            InitializeComponent();
            splitContainer.IsSplitterFixed = true;
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
