using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            ///  var typeReportSource = new Telerik.Reporting.TypeReportSource();
                  ///var typeReportSource = new Telerik.Reporting.UriReportSource();
                  ///typeReportSource.Uri = "D:\\work_new\\reports\\Report2.trdp";        
                  ///this.reportViewer1.ReportSource = typeReportSource;
                  reportViewer1.RefreshReport();
          /*     
            Telerik.Reporting.InstanceReportSource instanceReportSource = (Telerik.Reporting.InstanceReportSource)this.reportViewer1.ReportSource;
            Telerik.Reporting.InstanceReportSource instanceReportSource = (Telerik.Reporting.InstanceReportSource)this.reportViewer1.ReportSource;
            Telerik.Reporting.Report report = (Telerik.Reporting.Report)instanceReportSource.ReportDocument;
            this.reportViewer1.RefreshReport();
        */
        }
    }
}
