using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlBankRequisites : UserControl
    {
        public MiddleControlBankRequisites()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties)
        {
            if (cust.BankAccount.Count == 0)
                cust.BankAccount.Add(new BankAccount { CustId = cust.CustId });
            var bankAccount = cust.BankAccount.FirstOrDefault();
            ctrlBankAccount.DataSource = bankAccount;
        }

        public bool Validator()
        {
            return ctrlBankAccount.Validator();
        }
    }
}
