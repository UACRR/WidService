namespace Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class Report1 : Telerik.Reporting.Report
    {
        public Report1()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();


        }

        private void Report1_NeedDataSource(object sender, EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;

            // Transfer the value of the processing instance of ReportParameter
            // to the parameter value of the sqlDataSource component
            this.sqlDataSource2.Parameters[0].Value = report.Parameters["accId"].Value;

            // Set the SqlDataSource component as it's DataSource
            report.DataSource = this.sqlDataSource2;
            

        }
    }
}