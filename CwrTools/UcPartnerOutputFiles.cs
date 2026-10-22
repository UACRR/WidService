using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwrTools
{
    public partial class UcPartnerOutputFiles : UserControl
    {

        private string[] PeriodTypeTitle =
        {
            "Місяць",
            "Квартал",
            "Півріччя",
            "Рік",
        };

        public class PartnerInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int PeriodTypeId { get; set; }
        }

        private PartnerInfo _partnerInfo;

        public UcPartnerOutputFiles()
        {
            InitializeComponent();
        }

        private void UcPartnerOutputFiles_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvFiles.MultiSelect = false;
            lvFiles.View = View.Details;

            lvFiles.Columns.Clear();
            lvFiles.Columns.Add("Код", 100);
            lvFiles.Columns.Add("Рік", 100);
            lvFiles.Columns.Add("", 100);
            lvFiles.Columns.Add("Назва файлу", 200);
            lvFiles.Columns.Add("Статус", 200);
        }

        private void LoadPartnerInfo(int partnerId)
        {
            Helpers.RunSqlCwr(cmd => {
                cmd.CommandText = @"
                    select t1.Id, Name, PeriodType, t2.Id
                    from Partners t1
                        join PeriodType t2 on t1.PeriodType = t2.Id
                    where t1.Id = @partnerId
                ";
                cmd.Parameters.AddWithValue("@partnerId", partnerId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    _partnerInfo = new PartnerInfo
                    {
                        Id = r.GetInt32(0),
                        Name = r.GetString(1),
                        PeriodTypeId = r.GetInt32(2),
                    };
                }
            });
        }

        private void PlanPartnerDeliveries()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spPlanPartnerDeliveries";
                cmd.Parameters.AddWithValue("@partnerId", _partnerInfo.Id);
                cmd.ExecuteNonQuery();
            });
        }

        private void UpdateNames()
        {
            labTitle.Text = $"{_partnerInfo.Name} - передача файлів за розкладом РАЗ НА {PeriodTypeTitle[_partnerInfo.PeriodTypeId - 1].ToUpper()}";
            lvFiles.Columns[2].Text = PeriodTypeTitle[_partnerInfo.PeriodTypeId - 1];
        }

        public void RefreshData(int partnerId)
        {
            LoadPartnerInfo(partnerId);
            PlanPartnerDeliveries();
            UpdateNames();
            LoadPartnerFiles();
        }

        private void LoadPartnerFiles()
        {
            Helpers.RunSqlCwr(cmd =>
            {
            });
        }

    }
}
