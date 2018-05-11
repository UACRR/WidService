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
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsBankAccountControl : UserControl
    {
        //private object _dataSource;
        //private string _dataMember;

        public IpsBankAccountControl()
        {
            InitializeComponent();
        }

        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        //[Category("Data")]
        //[DefaultValue(null)]
        public object DataSource // IBankAccount, IAnketaCompany (???)
        {
            get { return BankAccountBindingSource.DataSource; }
            set { BankAccountBindingSource.DataSource = value; }

            //get
            //{
            //    return _dataSource;
            //}

            //set
            //{
            //    _dataSource = value;

            //    //BindingSource bs = new BindingSource(_dataSource, _dataMember);
            //    //bs.DataSource = bs;

            //    txtMfoName.DataBindings.Add("Text", _dataSource, "MfoName");
            //    txtMfo.DataBindings.Add("Text", _dataSource, "Mfo");
            //    txtMfoOkpo.DataBindings.Add("Text", _dataSource, "MfoOkpo");
            //    txtTransitNumber.DataBindings.Add("Text", _dataSource, "TransitNumber");
            //    txtAccountNumber.DataBindings.Add("Text", _dataSource, "AccountNumber");
            //}
        }

        //[Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        //[DefaultValue("")]
        public string DataMember
        {
            get { return BankAccountBindingSource.DataMember; }
            set { BankAccountBindingSource.DataMember = value; }

            //get
            //{
            //    return _dataMember;
            //}

            //set
            //{
            //    _dataMember = value;
            //}
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtMfo
        {
            get
            {
                return txtMfo;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtMfoName
        {
            get
            {
                return txtMfoName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtMfoOkpo
        {
            get
            {
                return txtMfoOkpo;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtTransitNumber
        {
            get
            {
                return txtTransitNumber;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtAccountNumber
        {
            get
            {
                return txtAccountNumber;
            }
        }
    }
}
