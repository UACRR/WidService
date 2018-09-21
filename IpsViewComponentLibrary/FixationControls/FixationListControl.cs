using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.FixationControls
{
    public partial class FixationListControl : UserControl
    {
        private FixationListPresenter _presenter;

        public FixationListControl()
        {
            InitializeComponent();

            _presenter = new FixationListPresenter(this);
        }
    }
}
