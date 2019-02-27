using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;

namespace IpsViewComponentLibrary._trash
{

    public partial class ControlWithDataSource : UserControl
    {
        public ControlWithDataSource()
        {
            InitializeComponent();
        }

        //[Category("Data")]
        //[AttributeProvider(typeof(IListSource))]
        public object DataSource
        {

            get { return bindingSource1.DataSource; }
            set
            {

                bindingSource1.DataSource = value;
            }
        }

        [Category("Data")]
        [Bindable(true)]
        //[Browsable(true)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[EditorBrowsable(EditorBrowsableState.Always)]

        public string DisplayMember
        {
            get { return rdTextBox1.Text; }
            set { rdTextBox1.Text = value; }
        }

        //[Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design",  typeof(UITypeEditor))]
        public string DataMember
        {
            get { return bindingSource1.DataMember; }
            set { bindingSource1.DataMember = value; }
        }

        [Category("Data")]
        [Bindable(true)]
        public object selectedCountry
        {
            get => radDropDownList1.SelectedValue;
            set => radDropDownList1.SelectedValue = value; 
        }

    }
}
