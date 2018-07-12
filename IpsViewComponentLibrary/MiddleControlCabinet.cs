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
    public partial class MiddleControlCabinet : UserControl
    {

        /// <summary>
        /// Виникиє при необхідності зберегти Customer
        /// </summary>
        public event EventHandler OnSaveCustomerNeed;

        public MiddleControlCabinet()
        {
            InitializeComponent();
        }
    }
}
