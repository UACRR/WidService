using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ViewAndPrintAgreement : Telerik.WinControls.UI.RadForm
    {
        WordEngine wordEngine;
        public ViewAndPrintAgreement()
        {
            InitializeComponent();
        }// = new WordEngine();

        public ViewAndPrintAgreement(AnketaDictionaties dictionaties, object data)
        {
            InitializeComponent();
            wordEngine = new WordEngine(dictionaties);
            //wordEngine
        }
    }
}
