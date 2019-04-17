using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportsLibrary;
using Telerik.Reporting;


namespace RepNew
{
    public partial class Аналітика : Form
    {
        public Аналітика()
        {
            language.Currenlanguage = "uk-UA";
            var cultureInfo = new System.Globalization.CultureInfo(language.Currenlanguage);

            // Set the language for static text (i.e. column headings, titles)
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    
    }
}
