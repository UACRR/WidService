using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class ReportsControl : UserControl
    {
        private Customer _data;
        public ReportsControl()
        {
            InitializeComponent();
        }

        public void SetData(Customer data)
        {
            _data = data;
        }


        public void SetDataSourceForLicAgrGrid(object obj)
        {
            if(obj == null) return;
            gvLicenseAgr.DataSource = obj;
        }

        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            List<GridPeriodsReports> source = new List<GridPeriodsReports>();
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(11); i++)
            {
                source.Add(new GridPeriodsReports
                {
                    PeriodId = rnd.Next(100),
                    Amount = rnd.Next(5000),
                    Distribamount = rnd.Next(5000),
                    IsActFormed = rnd.Next(20) > 10 ? "Так" : "Ні",
                    PeriodName = "Період " + ( rnd.Next(10) + rnd.NextDouble() ),
                    ReportCounts = rnd.Next(5),
                    Status = rnd.Next(3)
                    
                });
            }

            gvPeriods.DataSource = source;

        }

        private void gvPeriods_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {

        }

        private void btnAddReport_Click(object sender, EventArgs e)
        {

        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (gvPeriodReports.Rows.Count == 0)
                MessageBox.Show("Звіти за обраний період не знайдено!", "Звіти відсутні!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void gvPeriods_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "CreateAct":
                    CreateAct();
                    break;
                case "ViewAct":
                    ViewAct();
                    break;
            }
            
        }

        private void CreateAct()
        {
            MessageBox.Show("Створення акту");
        }

        private void ViewAct()
        {
            MessageBox.Show("Перегляд акту");
        }
    }

    public class GridPeriodsReports
    {
        public int PeriodId { get; set; }

        public string PeriodName { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Distribamount { get; set; }
        public int ReportCounts { get; set; }
        public string IsActFormed { get; set; }
    }
}
