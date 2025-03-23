using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class UcWidGroupStatistics : UserControl
    {
        public UcWidGroupStatistics()
        {
            InitializeComponent();

            lvStatistics.Columns.Add("Name", 300);
            lvStatistics.Columns.Add("Value", 100).TextAlign = HorizontalAlignment.Right;
        }

        public void SetGroup(int? groupId)
        {
            lvStatistics.Items.Clear();
            if(groupId == null)
            {
                return;
            }

            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupStatistics";
                cmd.Parameters.AddWithValue("@groupId", groupId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    int i = 0;
                    lvStatistics.Items.Add("Загальна кількість творів")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Готові до передачі")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Існували в WID")
                        .SubItems.Add(r.GetInt32(i++).ToString());
            
                    lvStatistics.Items.Add("Додані в результаті публікації")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Потребують попередньої обробки")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Передані, очікують відповідь")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Передані повторно, очікують відповідь")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Опубліковані без зауважень")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Опубліковані з зауваженнями")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Відхилені як такі, що вже існують")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Відхилені, потребують обробки")
                        .SubItems.Add(r.GetInt32(i++).ToString());

                    lvStatistics.Items.Add("Відхилені остаточно")
                        .SubItems.Add(r.GetInt32(i++).ToString());
                }
            });
        }
    }
}
