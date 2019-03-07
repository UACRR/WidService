using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary.InternalControlsModel;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    public partial class MusicDesignHeaderInfoControl : UserControl
    {
        public MusicDesignHeaderInfoControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Об'єкт MusicDesignHeaderInfo
        /// </summary>
        public object DataSource
        {
            get => bsSpectacleView.DataSource;
            set
            {
                if (value is MusicDesignHeaderInfo info)
                    bsSpectacleView.DataSource = info;
            }
        }
    }
}
