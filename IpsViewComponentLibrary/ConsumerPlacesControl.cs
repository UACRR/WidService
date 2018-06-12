using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IpsViewComponentLibrary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Model;

namespace ipsAnketaClient
{
    public partial class ConsumerPlacesControl : UserControl
    {
        #region FIELDS

        private Customer data;
        private List<ClnPlaceHoll> newPlace;
        private IpsPremisesTypeControl premisesType;
        private AddPremisesForm newPremises;
        private AddPremisesForm editPremises;
        private TypePlace typePlace;
        private bool IsNeedPremissesType = false, 
                     isNewInst = false;
        private byte typePremises;

        #endregion

        public int IdItemOfSelectRow { get; set; }

        public delegate void EnabledChangeWhenEdit();

        public event EnabledChangeWhenEdit OnEnabledChangeWhenEditOrAddPremises;

        public ConsumerPlacesControl()
        {
            InitializeComponent();
        }

        #region ALL METHODS
        // * * * PUBLICS

        /// <summary>
        /// Встановити джерело даних для Grid
        /// </summary>
        /// <param name="data"></param>
        public void SetGridDataSource(object dataSource)
        {
            if (dataSource!=null)
            {
                rGridViewInstitution.DataSource = new List<ClnBusinessPlace>
                {
                    new ClnBusinessPlace()
                };
                rGridViewInstitution.DataSource = dataSource;
            }
            else
            {
                rGridViewInstitution.DataSource = new List<ClnBusinessPlace>();
                //return;
            }

            rGridViewInstitution.Update();
            rGridViewInstitution.MasterTemplate.Refresh();
            rGridViewInstitution.Refresh();
        }

        /// <summary>
        /// Встановити дані для контрола
        /// </summary>
        /// <param name="Data"></param>
        public void SetData(Customer Data)
        {
            if(Data != null)
                data = Data;
        }

        /// <summary>
        /// Отримати дані з контрола
        /// </summary>
        /// <returns></returns>
        public Customer GetData()
        {
            return data ?? new Customer();
        }

        // * * * PRIVATES
        /// <summary>
        /// Створення контрола з грідом та додаванням нового типу приміщення
        /// </summary>
        private void InitializePremiseslComponent()
        {
            rTxtBoxCountOrMeters.Visible = false;
            lblLocation.Visible = false;
            lblLocation.Text = string.Empty;

            premisesType = new IpsPremisesTypeControl();
            premisesType.OnBtnAddPremisesClick += PremisesType_OnBtnAddPremisesClick; ;
            premisesType.OnBtnDeletePremisesClick += PremisesType_OnBtnDeletePremisesClick; ;
            premisesType.OnBtnEditPremisesClick += PremisesType_OnBtnEditPremisesClick; ;
            premisesType.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            premisesType.Location = new Point(10, 155); ;
            premisesType.Width = addressControl.Width;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, rPanelAdd.Height + 235);//   + 240

            rPanelAdd.Controls.Add(premisesType);
        }

        /// <summary>
        /// Встановлення початкового стану екрану та очищення даних
        /// </summary>
        private void SetDefaultState()
        {
            rPanelAdd.Visible = false;
            rDropDownBtnAddInst.Enabled = true;
            rTxtBoxNameInst.Clear();
            rTxtBoxTypeInst.Clear();
            rTxtBoxCountOrMeters.Clear();
            addressControl.SetEmpty();

            if (premisesType != null)
            {
                rPanelAdd.Controls.Remove(premisesType);
                rPanelAdd.ClientSize = new Size(rPanelAdd.Width, rPanelAdd.Height - 235);//   - 240
                rPanelAdd.Refresh();
                premisesType.OnBtnAddPremisesClick -= PremisesType_OnBtnAddPremisesClick;
                premisesType.OnBtnDeletePremisesClick -= PremisesType_OnBtnDeletePremisesClick;
                premisesType.OnBtnEditPremisesClick -= PremisesType_OnBtnEditPremisesClick;
                premisesType.Dispose();
                premisesType = null;
                GC.Collect();
            }
            rLblName.ForeColor = Color.Black;
            lblLocation.ForeColor = Color.Black;
            addressControl.DefaultColorLabels();
            rGridViewInstitution.Enabled = true;
            IsNeedPremissesType = false;
            rBtnEditInst.Enabled = true;
            isNewInst = false;
            newPlace = new List<ClnPlaceHoll>();

            if(data.Client.ClnBusinessPlace.Count != 0)
                SetGridDataSource(data.Client.ClnBusinessPlace);
        }

        public void ClearData()
        {
            SetDefaultState();
        }

        /// <summary>
        /// Перевірка на правильність полів
        /// </summary>
        /// <returns></returns>
        private bool Validator()
        {
            bool valid = true;
            bool isInt = true;
            if (rTxtBoxNameInst.Text == string.Empty)
            {
                valid = false;
                rLblName.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                rLblName.ForeColor = Color.Black;

            if (!IsNeedPremissesType && rTxtBoxCountOrMeters.Text == string.Empty)
            {
                valid = false;
                lblLocation.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else if (!IsNeedPremissesType && rTxtBoxCountOrMeters.Text != string.Empty && !Int32.TryParse(rTxtBoxCountOrMeters.Text, out int parse))
            {
                isInt = false;
                lblLocation.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                lblLocation.ForeColor = Color.Black;

            if (!addressControl.ValidatorAddressCtrl())
                valid = false;

            if (!valid)
            {
                MessageBox.Show("Деякі поля не можуть бути пустими!", "Заповніть всі поля!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (valid && !isInt)
            {
                MessageBox.Show("Деякі поля повинні бути числовими!", "Заповніть всі поля правильно!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            rLblName.ForeColor = Color.Black;
            lblLocation.ForeColor = Color.Black;
            addressControl.DefaultColorLabels();
            return true;
        }

        #endregion

        #region DATASOURCES

        //[Category("Dictionaries")]
        //[AttributeProvider(typeof(IListSource))]
        //public object RegionsPlacesCtrlDataSource
        //{
        //    get => addressControl.RegionsPlacesCtrlDataSource;
        //    set => addressControl.RegionsPlacesCtrlDataSource = value;
        //}
        //
        //[Category("Dictionaries")]
        //public string RegionsPlacesCtrlDataMember
        //{
        //    get => addressControl.RegionsPlacesCtrlDataMember;
        //    set => addressControl.RegionsPlacesCtrlDataMember = value;
        //}
        //
        //[Category("Dictionaries")]
        //public string RegionsPlacesCtrlDisplayMember
        //{
        //    get => addressControl.RegionsPlacesCtrlDisplayMember;
        //    set => addressControl.RegionsPlacesCtrlDisplayMember = value;
        //}
        //
        //[Category("Dictionaries")]
        //public string RegionsPlacesCtrlValueMember
        //{
        //    get => addressControl.RegionsPlacesCtrlValueMember;
        //    set => addressControl.RegionsPlacesCtrlValueMember = value;
        //}
        //
        //[Category("Dictionaries")]
        //public RadListDataItem RegionSelectedItem
        //{
        //    get => addressControl.RegionBind.SelectedItem;
        //    set => addressControl.RegionBind.SelectedItem = value;
        //}
        //
        //[Category("Dictionaries")]
        //public object RegionSelectedValue
        //{
        //    get => addressControl.RegionBind.SelectedValue;
        //    set => addressControl.RegionBind.SelectedValue = value;
        //}
        #endregion

        #region Premises ctrl button click EVENTS 

        /// <summary>
        /// Додати приміщення
        /// </summary>
        private void PremisesType_OnBtnAddPremisesClick()
        {
            if (isNewInst)//новий заклад
            {
                newPremises = new AddPremisesForm();
                newPremises.OnInsertData += NewPremises_OnInsertData; ;
                newPremises.StartPosition = FormStartPosition.CenterScreen;
                newPremises.SetTypePremises(typePremises);
                newPremises.ShowDialog();
                newPremises.OnInsertData -= NewPremises_OnInsertData;
                newPremises = null;

            }
            else//існуючий заклад
            {
                int idRow = Convert.ToInt32(rGridViewInstitution.CurrentRow.Cells[0].Value);
                newPremises = new AddPremisesForm(premisesType.GetData(idRow), idRow);
                //premisesType.IdSelectedRow;
                newPremises.OnInsertData += NewPremises_OnInsertData;
                newPremises.StartPosition = FormStartPosition.CenterScreen;
                newPremises.SetTypePremises(Convert.ToByte(data.Client.ClnBusinessPlace.SingleOrDefault(item => item.PlaceId == idRow).PlCode));
                newPremises.ShowDialog();
                newPremises.OnInsertData -= NewPremises_OnInsertData;
                newPremises = null;
            }
            GC.Collect();
        }

        /// <summary>
        /// Редагувати приміщення
        /// </summary>
        private void PremisesType_OnBtnEditPremisesClick()
        {
            int idRow = 0;
            if(rGridViewInstitution.Rows.Count != 0)
                idRow = Convert.ToInt32(rGridViewInstitution.CurrentRow.Cells[0].Value);

            if (premisesType.IdSelectedRow != 0)
                editPremises = new AddPremisesForm(premisesType.GetData(idRow), premisesType.IdSelectedRow, idRow);
            else
                editPremises = new AddPremisesForm(premisesType.GetData(idRow), premisesType.IdSelectedRow, idRow, premisesType.IdSelectedRowStr);
            editPremises.OnUpdateData += EditPremises_OnUpdateData; ;
            editPremises.StartPosition = FormStartPosition.CenterScreen;
            editPremises.SetTypePremises(Convert.ToByte(data.Client.ClnBusinessPlace.SingleOrDefault(item => item.PlaceId == idRow).PlCode));
            editPremises.ShowDialog();
            editPremises.OnUpdateData -= EditPremises_OnUpdateData;
            editPremises = null;
            GC.Collect();
            //MessageBox.Show(premisesType.IdSelectedRow.ToString());
        }

        #region FORM add/edit premises events

        private void NewPremises_OnInsertData()
        {
            var temp = newPremises.DataFotInsert();

            if (isNewInst)//новий заклад
            {
                newPlace.Add(temp.SingleOrDefault());
                premisesType.SetDataSource(newPlace);
                premisesType.RefreshGrid();

                //* * * ЗБЕРЕГТИ ЗМІНИ
            }
            else//існуючий заклад
            {
                var editdata = data.Client.ClnBusinessPlace.Where(iditem => iditem.PlaceId == IdItemOfSelectRow).Select(item => item.ClnPlaceHoll).SingleOrDefault();

                editdata.Add(temp.LastOrDefault());
                premisesType.SetDataSource(data, IdItemOfSelectRow);
                premisesType.RefreshGrid();

                //* * * ЗБЕРЕГТИ ЗМІНИ
            }
        }

        private void EditPremises_OnUpdateData()
        {
            var editdata = data.Client.ClnBusinessPlace.Where(iditem => iditem.PlaceId == IdItemOfSelectRow).Select(item => item.ClnPlaceHoll).SingleOrDefault();
            premisesType.SetDataSource(data,IdItemOfSelectRow);
            premisesType.RefreshGrid();
        }

        #endregion


        /// <summary>
        /// Видалити приміщення
        /// </summary>
        private void PremisesType_OnBtnDeletePremisesClick()
        {
            MessageBox.Show(premisesType.IdSelectedRow.ToString());
        }



        #endregion

        #region ALL BUTTONS

        #region ДОДАТИ ЗАКЛАД

        //  ГОТЕЛЬ
        private void rBtnAddHotel_Click(object sender, EventArgs e)
        {
            typePlace = new TypePlace
                {
                    CodeI = 1,
                    Name = "Готель",
                    ClnBusinessPlace = null,
                    TypePlaceTr = new List<TypePlaceTr> {
                        new TypePlaceTr{ CodeI = 1, Name = "Hotel", Lang = "En" },
                        new TypePlaceTr{ CodeI = 1, Name = "Гостиница", Lang = "Ru" },
                        new TypePlaceTr{ CodeI = 1, Name = "Готель", Lang = "Uk" } }
                };
            newPlace = new List<ClnPlaceHoll>();
            rTxtBoxTypeInst.Text = rBtnAddHotel.Text;
            InitializePremiseslComponent();
            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            IsNeedPremissesType = true;
            rGridViewInstitution.Enabled = false;
            rBtnEditInst.Enabled = false;
            isNewInst = true;
            premisesType.SetGridType(1);
            typePremises = 1;
        }
        
        //  РЕСТОРАН
        private void rBtnAddRestaurant_Click(object sender, EventArgs e)
        {
            typePlace = new TypePlace
            {
                CodeI = 2,
                Name = "Ресторан",
                ClnBusinessPlace = null,
                TypePlaceTr = new List<TypePlaceTr> {
                    new TypePlaceTr{ CodeI = 2, Name = "Restaurant", Lang = "En" },
                    new TypePlaceTr{ CodeI = 2, Name = "Ресторан", Lang = "Ru" },
                    new TypePlaceTr{ CodeI = 2, Name = "Ресторан", Lang = "Uk" } }
            };
            newPlace = new List<ClnPlaceHoll>();
            rTxtBoxTypeInst.Text = rBtnAddRestaurant.Text;
            InitializePremiseslComponent();
            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            IsNeedPremissesType = true;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            isNewInst = true;
            premisesType.SetGridType(2);
            typePremises = 2;
        }
        
        //  НІЧНИЙ КЛУБ
        private void rBtnAddNightClub_Click(object sender, EventArgs e)
        {
            typePlace = new TypePlace
            {
                CodeI = 4,
                Name = "Нічні клуби/Платний вхід",
                ClnBusinessPlace = null,
                TypePlaceTr = new List<TypePlaceTr> {
                    new TypePlaceTr{ CodeI = 4, Name = "Night clubs/Paid entrance", Lang = "En" },
                    new TypePlaceTr{ CodeI = 4, Name = "Ночные клубы/Платный вход", Lang = "Ru" },
                    new TypePlaceTr{ CodeI = 4, Name = "Нічні клуби/Платний вхід", Lang = "Uk" } }
            };
            rTxtBoxTypeInst.Text = rBtnAddNightClub.Text;
            rPanelAdd.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
            isNewInst = true;
        }
        
        //  НІЧНИЙ КЛУБ БЕЗКОШТОВНИЙ ВХІД
        private void rBtnAddNightClubFree_Click(object sender, EventArgs e)
        {
            typePlace = new TypePlace
            {
                CodeI = 3,
                Name = "Нічні клуби/Безкоштовний вхід",
                ClnBusinessPlace = null,
                TypePlaceTr = new List<TypePlaceTr> {
                    new TypePlaceTr{ CodeI = 3, Name = "Night clubs/Free entrance", Lang = "En" },
                    new TypePlaceTr{ CodeI = 3, Name = "Ночные клубы/Бесплатный вход", Lang = "Ru" },
                    new TypePlaceTr{ CodeI = 3, Name = "Нічні клуби/Безкоштовний вхід", Lang = "Uk" } }
            };
            rTxtBoxTypeInst.Text = rBtnAddNightClubFree.Text;
            rPanelAdd.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Visible = true;
            lblLocation.Text = "Метраж";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
            isNewInst = true;
        }
        
        //  КАФЕ-БАР-ЇДАЛЬНЯ
        private void rBtnAddCaffeOrBar_Click(object sender, EventArgs e)
        {
            typePlace = new TypePlace
            {
                CodeI = 5,
                Name = "Кафе/Бар - Їдальня",
                ClnBusinessPlace = null,
                TypePlaceTr = new List<TypePlaceTr> {
                    new TypePlaceTr{ CodeI = 5, Name = "Cafe / Bar / Bistro", Lang = "En" },
                    new TypePlaceTr{ CodeI = 5, Name = "Кафе / Бар - Столовая", Lang = "Ru" },
                    new TypePlaceTr{ CodeI = 5, Name = "Кафе / Бар - Їдальня", Lang = "Uk" } }
            };
            rTxtBoxTypeInst.Text = rBtnAddCaffeOrBar.Text;
            rPanelAdd.Visible = true;
            lblLocation.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
            isNewInst = true;
        }
        
        //  ТЕАТР-ОПЕРА
        private void rBtnAddTheaterOrOpera_Click(object sender, EventArgs e)
        {
            typePlace = new TypePlace
            {
                CodeI = 6,
                Name = "Театр/Оперета",
                ClnBusinessPlace = null,
                TypePlaceTr = new List<TypePlaceTr> {
                    new TypePlaceTr{ CodeI = 6, Name = "", Lang = "En" },
                    new TypePlaceTr{ CodeI = 6, Name = "", Lang = "Ru" },
                    new TypePlaceTr{ CodeI = 6, Name = "Театр/Оперета", Lang = "Uk" } }
            };
            rTxtBoxTypeInst.Text = rBtnAddTheaterOrOpera.Text;
            rPanelAdd.Visible = true;
            lblLocation.Visible = true;
            rTxtBoxCountOrMeters.Visible = true;
            lblLocation.Text = "Кількість місць";
            rDropDownBtnAddInst.Enabled = false;
            rBtnEditInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rPanelAdd.ClientSize = new Size(rPanelAdd.Width, 215);// без додаткового гріда
            isNewInst = true;
        }
        
        #endregion


        /// <summary>
        /// РЕДАГУВАТИ ЗАКЛАД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnEditInst_Click(object sender, EventArgs e)
        {
            if(rGridViewInstitution.RowCount == 0 || rGridViewInstitution.CurrentRow.Cells[0].Value.ToString() == "0")
                return;
            if (rGridViewInstitution.CurrentRow.Cells[0].Value.GetType() != typeof(Int32))
                return;
            IdItemOfSelectRow = (int)rGridViewInstitution.CurrentRow.Cells[0].Value;
            var typePlace = data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == IdItemOfSelectRow).Select(item => item.PlCodeNavigation).SingleOrDefault();
            if (typePlace != null)
                if (typePlace.CodeI == 1 || typePlace.CodeI == 2)
                {
                    InitializePremiseslComponent();
                    IsNeedPremissesType = true;
                    premisesType.SetDataSource(data, IdItemOfSelectRow);

                }
                else if (typePlace.CodeI > 2)
                {
                    var countOrMeters = data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == IdItemOfSelectRow).Select(item => item.ClnPlaceHoll).SingleOrDefault();
                    var count = countOrMeters?.Select(item => item.HollNum).FirstOrDefault();
                    rTxtBoxCountOrMeters.Text = count != null ? count.ToString() : countOrMeters?.Select(item => item.SqHoll).SingleOrDefault().ToString();
                    lblLocation.Text = count!=null? "Кількість місць" : "Метраж";
                    rTxtBoxCountOrMeters.Visible = true;
                    lblLocation.Visible = true;
                }

            rTxtBoxNameInst.Text = data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == IdItemOfSelectRow).Select(item => item.PlaceName).SingleOrDefault();
            var type = data.Client.ClnBusinessPlace.Where(itemId => itemId.PlaceId == IdItemOfSelectRow).Select(item => item.PlCodeNavigation).SingleOrDefault();
            if (type != null)
                rTxtBoxTypeInst.Text = type.Name;
            addressControl.SetAddressForEditCustomer(data, IdItemOfSelectRow);

            rPanelAdd.Visible = true;
            rDropDownBtnAddInst.Enabled = false;
            rGridViewInstitution.Enabled = false;
            rBtnEditInst.Enabled = false;

            OnEnabledChangeWhenEditOrAddPremises?.Invoke();
        }

        /// <summary>
        /// ЗБЕРЕГТИ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnSave_Click(object sender, EventArgs e)
        {
            addressControl.SetValues();

            if (!Validator())
                return;

            if (isNewInst) // новий заклад
            {
                var newInst = new ClnBusinessPlace
                {
                    //PlaceId = 100, //id елемента, null?
                    CustId = data.Client.CustId,
                    PlCode = typePlace.CodeI, //код типу закладу,
                    PlaceName = rTxtBoxNameInst.Text,
                    PlaceCountry = "804",
                    PlaceRegion = addressControl.RegionCode,
                    PlaceCity = addressControl.TownName,
                    PlaceAddress = addressControl.StreetName,
                    FreeEntry = typePlace.CodeI != 4, // безкоштовний/платний вхід
                    PlCodeNavigation = typePlace, //тип закладу,
                    ClnPlaceHoll = IsNeedPremissesType ? newPlace : new List<ClnPlaceHoll>
                    {
                        new ClnPlaceHoll
                        {
                            HollNum = typePlace.CodeI == 3 ? null : new int?(Convert.ToInt32(rTxtBoxCountOrMeters.Text)),
                            SqHoll = typePlace.CodeI == 3 ? new int?(Convert.ToInt32(rTxtBoxCountOrMeters.Text)) : null,
                        }
                    } //приміщення: IsNeedPremissesType-treu якщо з приміщеннями
                };

                 data.Client.ClnBusinessPlace.Add(newInst);
            }
            else // існуючий заклад
            {
                int idRow = Convert.ToInt32(rGridViewInstitution.CurrentRow.Cells[0].Value);
                var item = data.Client.ClnBusinessPlace.SingleOrDefault(idItem => idItem.PlaceId == idRow);
                if (item != null)
                {
                    item.PlaceName = rTxtBoxNameInst.Text;
                    item.PlaceRegion = addressControl.RegionCode;
                    item.PlaceCity = addressControl.TownName;
                    item.PlaceAddress = addressControl.StreetName;
                    if (item.ClnPlaceHoll.Count == 1)
                    {
                        var place = item.ClnPlaceHoll.SingleOrDefault();
                        if (place != null)
                        {
                            place.HollNum = lblLocation.Text == "Кількість місць"
                                ? new int?(Convert.ToInt32(rTxtBoxCountOrMeters.Text))
                                : null;
                            place.SqHoll = lblLocation.Text == "Метраж"
                                ? new int?(Convert.ToInt32(rTxtBoxCountOrMeters.Text))
                                : null;
                        }
                    }
                }
            }

            // * * * ЗБЕРЕЖЕННЯ ДАНИХ

            SetDefaultState();
            //var v = data.Client.ClnBusinessPlace;
            //some code

        }

        /// <summary>
        /// СКАСУВАТИ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rBtnCancel_Click(object sender, EventArgs e)
        {
            SetDefaultState();
        }

        #endregion
    }
}
