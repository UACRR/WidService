using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using WebAPIConnector;

namespace sysAdminwp
{
    public partial class DataEditControl : UserControl
    {
        private bool addRow = false;
        private ApiConnector connector;// = new ApiConnector("http://localhost:54867/");

        public string Url { get; set; }

        public DataEditControl()
        {
            InitializeComponent();

            rBtnAdd.Click += RBtnAdd_Click;
            rBtnRemove.Click += RBtnRemove_Click;
            rBtnSave.Click += RBtnSave_Click;
            rBtnCancel.Click += RBtnCancel_Click;

            rGridViewData.CurrentRowChanged += RGridViewData_CurrentRowChanged; //зміна даних на панелі при виборі рядка
            rGridViewData.CustomFiltering += RGridViewData_CustomFiltering;
            rTxtBSearchData.TextChanged += RTxtBSearchData_TextChanged;

            rTxtBCode.TextChanging += RTxtBCode_TextChanging;
            rTxtBNameEn.TextChanging += RTxtBNameEn_TextChanging;
            rTxtBNameRu.TextChanging += RTxtBNameRu_TextChanging;
            rTxtBNameUa.TextChanging += RTxtBNameUa_TextChanging;

            rMItemSaveConfig.Click += RMItemSaveConfig_Click;
            rMItemsSetDefaultSett.Click += RMItemsSetDefaultSett_Click;

            //LoadOverviewCfg();

            this.Enabled = false;

        }

        #region ALL EVENTS

            //default конфігурація
        private void RMItemsSetDefaultSett_Click(object sender, EventArgs e)
        {
            if (File.Exists("defaultoverviewconfig.xml"))
            {
                rGridViewData.LoadLayout("defaultoverviewconfig.xml");
                rGridViewData.SaveLayout("overviewconfig.xml");
            }
            else
            {
                MessageBox.Show("Неможливо автоматично відновити стандартні налаштування! " +
                                "Видаліть файл конфігурації '" + Path.GetFullPath("overviewconfig.xml") + "' та перезапустіть програму.",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

            //збереження конфігурації
        private void RMItemSaveConfig_Click(object sender, EventArgs e)
        {
            string s = "overviewconfig.xml";
            rGridViewData.SaveLayout(s);
        }



        #region textboxes [data] text changing events

        private void RTxtBCode_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            ChangeEnableElements(false, 2);
        }

        private void RTxtBNameEn_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            ChangeEnableElements(false, 2);
        }

        private void RTxtBNameRu_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            ChangeEnableElements(false, 2);
        }

        private void RTxtBNameUa_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            ChangeEnableElements(false, 2);
        }

        #endregion


        //пошук в таблиці по слову..
        private void RGridViewData_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(rTxtBSearchData.Text))
            {
                rGridViewData.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < rGridViewData.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                rGridViewData.EndUpdate(false);
                return;
            }

            rGridViewData.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < rGridViewData.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(rTxtBSearchData.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                rGridViewData.EndUpdate(false);
            }
        }
            //..refresh
        private void RTxtBSearchData_TextChanged(object sender, EventArgs e)
        {
            rGridViewData.MasterTemplate.Refresh();
        }

            //при зміні обраного рядка
        private void RGridViewData_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            UpdateEditPanel();
        }


            //кнопки
        private void RBtnCancel_Click(object sender, EventArgs e)
        {
            ChangeEnableElements(true, 2);
            UpdateEditPanel();
        }

        private void RBtnSave_Click(object sender, EventArgs e)
        {
            if (addRow)
                AddNewRow();
            else
                SaveChanges();
        }

        private void RBtnRemove_Click(object sender, EventArgs e)
        {
            RemoveRow();
        }

        private void RBtnAdd_Click(object sender, EventArgs e)
        {
            rBtnSave.Text = "Додати";
            ChangeEnableElements(false, 2);
            rTxtBCode.Clear();
            rTxtBNameEn.Clear();
            rTxtBNameRu.Clear();
            rTxtBNameUa.Clear();
            addRow = true;
        }

        #endregion

        #region ALL METHODS

        //privates
        /// <summary>
        /// Отримує дані з сервера та повертає у потрібному вигляді для контрола DataEditControl
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private List<ViewTable> GetData(List<DictBaseTypeI> l)
        {
            List<ViewTable> view = new List<ViewTable>();
            ViewTable temp;
            foreach (var items in l)
            {
                temp = new ViewTable();
                temp.Code = items.CodeI.ToString();
                foreach (var itemName in items.DictTrI)
                {
                    if (itemName.Lang == "Uk")
                        temp.NameUk = itemName.Name;
                    if (itemName.Lang == "Ru")
                        temp.NameRu = itemName.Name;
                    if (itemName.Lang == "En")
                        temp.NameEn = itemName.Name;
                }
                view.Add(temp);
            }
            return view;
        }
        //
        /// <summary>
        /// Оновлення даних на панелі редагування
        /// </summary>
        private void UpdateEditPanel()
        {
            //відписуємось від події - обрали інший рядок, зміни не внесено
            rTxtBCode.TextChanging -= RTxtBCode_TextChanging;
            rTxtBNameEn.TextChanging -= RTxtBNameEn_TextChanging;
            rTxtBNameRu.TextChanging -= RTxtBNameRu_TextChanging;
            rTxtBNameUa.TextChanging -= RTxtBNameUa_TextChanging;
            try
            {
                rTxtBCode.Text = rGridViewData.CurrentRow.Cells["Code"].Value.ToString();
                rTxtBNameUa.Text = rGridViewData.CurrentRow.Cells["NameUk"].Value.ToString();
                rTxtBNameRu.Text = rGridViewData.CurrentRow.Cells["NameRu"].Value.ToString();
                rTxtBNameEn.Text = rGridViewData.CurrentRow.Cells["NameEn"].Value.ToString();
            }
            catch (Exception)
            {
                rTxtBCode.Text = default(string);
                rTxtBNameUa.Text =default(string);
                rTxtBNameRu.Text =default(string);
                rTxtBNameEn.Text = default(string);
            }

            rTxtBCode.TextChanging += RTxtBCode_TextChanging;
            rTxtBNameEn.TextChanging += RTxtBNameEn_TextChanging;
            rTxtBNameRu.TextChanging += RTxtBNameRu_TextChanging;
            rTxtBNameUa.TextChanging += RTxtBNameUa_TextChanging;
        }
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isEnable"></param>
        /// <param name="type">1 - all, 2 - edit</param>
        private void ChangeEnableElements(bool isEnable, byte type)
        {
            switch (type)
            {
                case 1:
                {
                    rGridViewData.Enabled = isEnable;
                    radLblSearch.Enabled = isEnable;
                    rTxtBSearchData.Enabled = isEnable;
                    rMainMenu.Enabled = isEnable;
                    rBtnAdd.Enabled = isEnable;
                    rBtnRemove.Enabled = isEnable;
                    rPanelChange.Enabled = isEnable;
                } break;
                case 2:
                {
                    rGridViewData.Enabled = isEnable;
                    radLblSearch.Enabled = isEnable;
                    rTxtBSearchData.Enabled = isEnable;
                    rMainMenu.Enabled = isEnable;
                    rBtnAdd.Enabled = isEnable;
                    rBtnRemove.Enabled = isEnable;
                } break;
            }


          //rGridViewData.Enabled = isEnable;
          //radLblSearch.Enabled = isEnable;
          //rTxtBSearchData.Enabled = isEnable;
          //rMainMenu.Enabled = isEnable;
          //rBtnAdd.Enabled = isEnable;
          //rBtnRemove.Enabled = isEnable;
          //rPanelChange.Enabled = isEnable;

        }
        //
        /// <summary>
        /// Додавання нового запису
        /// </summary>
        private void AddNewRow()
        {
            if ((rTxtBCode.Text != string.Empty))
            {
                try
                {
                    Convert.ToInt32(rTxtBCode.Text);
                    DictBaseTypeI dataI = PackDataI();
                    bool retCode = connector.NewItem(Url, dataI);

                    rGridViewData.DataSource = GetData(connector.GetList<DictBaseTypeI>(Url));
                    UpdateEditPanel();
                    ChangeEnableElements(true, 2);
                    addRow = false;
                }
                catch (Exception e)
                {
                    rTxtBCode.Text = string.Empty;
                    MessageBox.Show(e.Message,"Не числове значення!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Поле '" + radLabelCode.Text + "' не повинно бути пустим!",
                    "Заповніть поле!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }
        //
        /// <summary>
        /// Видалення обраного рядка
        /// </summary>
        private void RemoveRow()
        {
            if (rGridViewData.CurrentRow.Cells["code"].Value.ToString() != string.Empty)
            {
                bool retCode = connector.DeleteItem(Url, rGridViewData.CurrentRow.Cells["code"].Value.ToString());
                rGridViewData.DataSource = GetData(connector.GetList<DictBaseTypeI>(Url));
                UpdateEditPanel();
            }
        }
        //
        /// <summary>
        /// Збереження змін
        /// </summary>
        private void SaveChanges()
        {
            try
            {
                Convert.ToInt32(rTxtBCode.Text);
                DictBaseTypeI dataI = PackDataI();
                bool retCode = connector.UpdateItem<DictBaseTypeI>(Url, dataI.CodeI.ToString(), (DictBaseTypeI)dataI);

                rGridViewData.DataSource = GetData(connector.GetList<DictBaseTypeI>(Url));
                UpdateEditPanel();
                ChangeEnableElements(true, 2);
            }
            catch (Exception e)
            {
                rTxtBCode.Text = rGridViewData.CurrentRow.Cells["Code"].Value.ToString();
                MessageBox.Show(e.Message, "Не коректне значення!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }
        //
        /// <summary>
        /// Упаковка даних для передачі int
        /// </summary>
        /// <returns></returns>
        private DictBaseTypeI PackDataI()
        {
            DictBaseTypeI dataI = new DictBaseTypeI();
            var dataTrI = new DictTrI[3];
            dataTrI[0] = new DictTrI() { CodeI = Convert.ToInt32(rTxtBCode.Text), Lang = "En", Name = rTxtBNameEn.Text };
            dataTrI[1] = new DictTrI() { CodeI = Convert.ToInt32(rTxtBCode.Text), Lang = "Ru", Name = rTxtBNameRu.Text };
            dataTrI[2] = new DictTrI() { CodeI = Convert.ToInt32(rTxtBCode.Text), Lang = "Uk", Name = rTxtBNameUa.Text };

            dataI.CodeI = dataTrI[0].CodeI;
            dataI.Name = rTxtBNameUa.Text;
            dataI.DictTrI = new List<DictTrI>
            {
                dataTrI[0],dataTrI[1],dataTrI[2]
            };
            return dataI;
        }
        //
        /// <summary>
        /// Завантаження конфігурації вигляду в грід
        /// </summary>
        public void LoadOverviewCfg()
        {
            string s = "overviewconfig.xml",
                def = "defaultoverviewconfig.xml";
            if (File.Exists(s))
                rGridViewData.LoadLayout(s);
            else if (File.Exists(def))
            {
                rGridViewData.LoadLayout(def);
            }
            else
            {
                rGridViewData.SaveLayout(def);
                rGridViewData.LoadLayout(def);
            }
        }


        //publics

        //виведення даних
        public void ViewData()
        {
            try
            {
                rGridViewData.DataSource = GetData(connector.GetList<DictBaseTypeI>(Url));
                Enabled = true;
            }
            catch (Exception e)
            {
                Enabled = false;
            }
        }

        public void InitializeConnector(ApiConnector apiCon)
        {
            connector = apiCon;
        }

        #endregion



    }
}
