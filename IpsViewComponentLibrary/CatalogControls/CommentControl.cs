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

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CommentControl : UserControl
    {
        public CommentControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CatalogFile Data Source
        /// </summary>
        public object DataSource
        {
            get => bsComment.DataSource;
            set => bsComment.DataSource = value;
        }
    }
}
