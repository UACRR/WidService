using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace DdexInvoicing
{
public partial class FormDataLoadSettings : Form
    {
        LoadSettings loadSettings;

        private FormDataLoadSettings()
        {
            InitializeComponent();
        }

        public FormDataLoadSettings(LoadSettings loadSettings)
        {
            InitializeComponent();
            this.loadSettings = loadSettings;
        }

        private void FormDataLoadSettings_Load(object sender, EventArgs e)
        {
            radComboStatus.Items.Add(new RadListDataItem("Всі твори"));
            radComboStatus.Items.Add(new RadListDataItem("Тільки необроблені (0)"));
            radComboStatus.Items.Add(new RadListDataItem("Тільки не ідентифіковані (1)"));
            radComboStatus.Items.Add(new RadListDataItem("Тільки ідентифіковані (2)"));
            radComboStatus.Items.Add(new RadListDataItem("Тільки відкладені (3)"));
            radComboStatus.Items.Add(new RadListDataItem("Назва не знайдена (10)"));
            radComboStatus.Items.Add(new RadListDataItem("Назва знайдена, автори не знайдені (20)"));
            radComboStatus.Items.Add(new RadListDataItem("Назва знайдена, один автор знайдений (21)"));
            radComboStatus.Items.Add(new RadListDataItem("Назва знайдена, кілька авторів знайдено (22)"));
            radComboStatus.Items.Add(new RadListDataItem("Альтернативна назва знайдена, автори не знайдені (30)"));
            radComboStatus.Items.Add(new RadListDataItem("Альтернативна назва знайдена, один автор знайдений (31)"));
            radComboStatus.Items.Add(new RadListDataItem("Альтернативна назва знайдена, кілька авторів знайдено (32)"));

            radComboSortCol.Items.Add(new RadListDataItem("За прибутком"));
            radComboSortCol.Items.Add(new RadListDataItem("За назвою запису"));
            radComboSortCol.Items.Add(new RadListDataItem("За назвою твору"));
            radComboSortCol.Items.Add(new RadListDataItem("За авторами"));
            radComboSortCol.Items.Add(new RadListDataItem("За виконавцями"));
            
            radComboSortOrder.Items.Add(new RadListDataItem("зростання"));
            radComboSortOrder.Items.Add(new RadListDataItem("спадання"));

            //radSpinRowCount.Value = loadSettings.rowCount;
            for(int i = 0; i < 50; i++)
            {
                radComboRange.Items.Add(new RadListDataItem($"{i * 1000 + 1} - {(i + 1) * 1000}"));
            }
            radComboRange.SelectedIndex = (loadSettings.firstRowIndex - 1) / 1000;

            int selectIndex = loadSettings.filterType == FilterType.all ? 0 : loadSettings.filterTypeIndex;
            radComboStatus.Items[selectIndex].Selected = true;
            radComboSortCol.Items[(int)loadSettings.orderType].Selected = true;
            radComboSortOrder.Items[(int)loadSettings.orderDir].Selected = true;
        }

        private void radBtnOk_Click(object sender, EventArgs e)
        {
            loadSettings.firstRowIndex = radComboRange.SelectedIndex * 1000 + 1;
            loadSettings.lastRowIndex = (radComboRange.SelectedIndex + 1) * 1000;

            Type type = typeof(FilterType);
            loadSettings.filterTypeIndex = radComboStatus.SelectedIndex == 0 ? type.GetFields().Length - 1 : radComboStatus.SelectedIndex;
            FieldInfo fi = type.GetFields()[loadSettings.filterTypeIndex];
            FilterType filterType = (FilterType)fi.GetValue(null);
            loadSettings.filterType = filterType;
            loadSettings.orderType = (OrderType)radComboSortCol.SelectedIndex;
            loadSettings.orderDir = (OrderDir)radComboSortOrder.SelectedIndex;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
