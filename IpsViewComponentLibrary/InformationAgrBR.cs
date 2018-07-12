using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class InformationAgrBR : UserControl
    {
        public event EventHandler OnSaveCommentNeed;

        public InformationAgrBR()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Джерело даних для коментаря
        /// </summary>
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object CommentDataSource
        {
            get => bindingSourceComment.DataSource;
            set => bindingSourceComment.DataSource = value;
        }

        public void SetDataSource(object obj)
        {
            
        }

        public object InfoDataSource
        {
            get => bsAgreementView.DataSource;
            set => bsAgreementView.DataSource = value;
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            if (txtNotation.Text != string.Empty)
                OnSaveCommentNeed?.Invoke(sender, e);
        }

        /*  - - - НАЗВИ ПОЛІВ
         *
         *NumberAgr = "";
         *DateAgr = "";
         *Agent = "";
         *PeriodReportind = "";
         *IsAttach = true;
         *DateBegin = "";
         *DateEnd = "";
         *IsProlongation = true;
         *IsTorn = ;
         *Percent = "";
         *MinPayment = "";
         *FixedPayment = "";
         *State = "";
         *Implementation = "";
         *IsPaid = true;
         *Bank = "";
         *Amount = "";
         *DistributedAmount = "";
         *Notation = "";
         *
         */
    }
}
