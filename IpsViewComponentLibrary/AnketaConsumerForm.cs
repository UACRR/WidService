using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class AnketaConsumerForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        private AnketaDictionaties _dictionaties;

        public AnketaConsumerForm()
        {
            InitializeComponent();
        }

        public AnketaConsumerForm(Customer customer, AnketaDictionaties dictionaties)
        {
            InitializeComponent();
            _customer = customer;
            _dictionaties = dictionaties;
            ctrlConsumerAnketa.SetDataAndDictionaries(customer, dictionaties);
            ctrlConsumerAnketa.InitializeControl(true);
        }

    }
}
