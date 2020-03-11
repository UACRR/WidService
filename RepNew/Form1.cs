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
//using Telerik.Reporting;


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

        private void button1_Click(object sender, EventArgs e)
        {
            language.Currenlanguage = "uk-UA";
            var cultureInfo = new System.Globalization.CultureInfo(language.Currenlanguage);

            // Set the language for static text (i.e. column headings, titles)
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            // Set the language for dynamic text (i.e. date, time, money)
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            button2.BackColor = Color.FromArgb(233, 244, 249);
            button3.BackColor = Color.FromArgb(233, 244, 249);
            button1.BackColor = Color.Red;

            reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            language.Currenlanguage = "ru-RU";
            var cultureInfo = new System.Globalization.CultureInfo(language.Currenlanguage);

            // Set the language for static text (i.e. column headings, titles)
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            // Set the language for dynamic text (i.e. date, time, money)
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            button1.BackColor = Color.FromArgb(233, 244, 249);
            button3.BackColor = Color.FromArgb(233, 244, 249);
            button2.BackColor = Color.Red;
            reportViewer1.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            language.Currenlanguage = "en-US";
            var cultureInfo = new System.Globalization.CultureInfo(language.Currenlanguage);

            // Set the language for static text (i.e. column headings, titles)
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            // Set the language for dynamic text (i.e. date, time, money)
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            button1.BackColor = Color.FromArgb(233, 244, 249);
            button2.BackColor = Color.FromArgb(233, 244, 249);
            button3.BackColor = Color.Red;
            reportViewer1.RefreshReport();
        }
    }
}
