using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    public partial class UcTools : UserControl
    {
        internal enum ToolEnum
        {
            IP_BASE_TO_NAME,
            IP_CODES,
        }


        internal class Tool
        {
            internal ToolEnum ToolEnum { get; set; }
            internal string Title { get; set; }
            internal string Description { get; set; }
        }

        private List<Tool> _toolList = new List<Tool>() {
            new Tool {
                ToolEnum = ToolEnum.IP_BASE_TO_NAME,
                Title = "Отримання міжнародного коду назви за базовим кодом правовласника",
                Description = "Скористайтесь цим інструментом, якщо в СМАРТ є твори, для яких прописані базові міжнародні "
                    + "коди, але не вказані відповідні коди назви"
            },
            new Tool {
                ToolEnum = ToolEnum.IP_CODES,
                Title = "Отримання міжнародних кодів правовласника",
                Description = "Цей інструмент надає можливість аналізу відсутньої інформацій і занесення отриманих даних в БД СМАРТ. "
                    + "Для отримання міжнародних кодів слід скористуватись іншими засобами,  "
                    + "сам по собі цей інструмент такої змоги не надає."
            },
        };

        private TableLayoutPanel panelTblMain;

        public UcTools()
        {
            InitializeComponent();
        }

        private void UcTools_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            panelTblMain = new TableLayoutPanel();

            panelTblMain.SuspendLayout();

            panelTblMain.Dock = DockStyle.Fill;
            //panelTblMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // Встановлюємо розміри і скидаємо стандартні налаштування
            panelTblMain.ColumnCount = 2;
            panelTblMain.RowCount = _toolList.Count * 2 + 1;
            panelTblMain.ColumnStyles.Clear();
            panelTblMain.RowStyles.Clear();

            // Встановлюємо стилі колонок
            panelTblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panelTblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));

            var rowIdx = 0;
            _toolList.ForEach(tool => {
                panelTblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                panelTblMain.Controls.Add(
                    new Label {
                        Text = tool.Title,
                        Dock = DockStyle.Fill,
                        Font = new Font(Label.DefaultFont, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleLeft,
                        AutoSize = true,
                    },
                    0, rowIdx);

                var btn = new Button {
                    Text = "Виконати ...",
                    Dock = DockStyle.Fill,
                    Font = new Font(Button.DefaultFont.FontFamily, 8),
                };
                btn.Click += (object sender, EventArgs e) => { RunTool(tool); };
                panelTblMain.Controls.Add(btn, 1, rowIdx);
                rowIdx++;

                panelTblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                var lab = new Label {
                    Text = tool.Description,
                    Dock = DockStyle.Fill,
                    BackColor = Color.LightYellow,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                };
                panelTblMain.Controls.Add(lab, 0, rowIdx);
                panelTblMain.SetColumnSpan(lab, 2);
                rowIdx++;
            });

            panelTblMain.ResumeLayout();

            this.Controls.Add(panelTblMain);
        }

        private void RunTool(Tool tool)
        {
            Form form;
            switch(tool.ToolEnum)
            {
                case ToolEnum.IP_BASE_TO_NAME:
                    form = new FormIpBaseToName();
                    form.ShowDialog();
                    break;
                case ToolEnum.IP_CODES:
                    form = new FormIpCodesLost();
                    form.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Not implemented");
                    break;

            }
        }
    }
}
