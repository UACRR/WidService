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
using Telerik.WinControls.UI;

namespace TestControls
{

    public partial class PaysRecieving : Telerik.WinControls.UI.RadForm
    {
        private MoneyReceived _pay = null;
        LicenseAgrParam _lic = null;

        public PaysRecieving( MoneyReceived pay, LicenseAgrParam lic )
        {
            _pay = pay;
            _lic = lic;

            InitializeComponent();
        }


    }

    class rowInfo
    {
        public GridViewRowInfo Row { get; set; }
        public bool ManualEdit { get; set; }
    }
    class Calculator
    {
        private List<rowInfo> List = new List<rowInfo>();
        private decimal Rest = 0;

        public void rebindList( decimal rest, RadGridView grid )
        {
            Rest = rest;
            List.Clear();
            foreach( var item in grid.Rows )
            {
                rowInfo addRow = new rowInfo { Row = item, ManualEdit = false };
                List.Add(addRow);
            }
        }

        public void Calculate()
        {
            decimal manualRest = List.Where( rec => rec.ManualEdit == true).Sum(rec=> Convert.ToDecimal( rec.Row.Cells["InputAmmount"].Value) );
            decimal freeRest = Rest - manualRest;
            if (freeRest == 0)
                return;

            foreach( var item in List.Where(rec => rec.ManualEdit == false) )
            {
                var inputCell = item.Row.Cells["InputAmmount"];
                var Debt = Convert.ToDecimal( item.Row.Cells["Debt"]);
                decimal curRest = Math.Min(freeRest, Debt);
                inputCell.Value = curRest;
                freeRest -= curRest;

                if (freeRest == 0)
                    break;
            }

        }

    }
}
