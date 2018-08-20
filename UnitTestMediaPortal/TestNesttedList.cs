using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace UnitTestMediaPortal
{
    public partial class TestNesttedList : Telerik.WinControls.UI.RadForm
    {
        public TestNesttedList()
        {
            InitializeComponent();
        }

        Register _register;
        public Register Register {
            get => _register;
            set { _register = value; bindingRegisterItem.DataSource = _register?.RegisterItem.ToList(); }
        }
    }
}
