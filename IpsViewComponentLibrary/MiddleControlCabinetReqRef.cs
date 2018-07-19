using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetReqRef : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;
        private AnketaDictionaties _dictionaties;
        private IList<BigRightRequestBidAuthors> _authors;
        private ControlRequestOrReferenceType _typeControl = ControlRequestOrReferenceType.None;
        public MiddleControlCabinetReqRef()
        {
            InitializeComponent();
        }

        public void SetAnketaDictionary(AnketaDictionaties dictionaties)
        {
            _dictionaties = dictionaties;
            bsDictionary.DataSource = _dictionaties.workType;
        }

        /// <summary>
        /// Дані для контрола
        /// </summary>
        /// <param name="comsumerBigRightView"></param>
        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<BigRightRequests> listRequests, IList<BigRightRequestBidAuthors> author)
        {
            _customer = customer;
            _authors = author;
            _bigRightView = bigRightView;

            ctrlAgrInfo.DataSource = _bigRightView;
            gvViewRequests.DataSource = listRequests;
            
            // gvCreativeRole.DataSource = author;
        }

        public ControlRequestOrReferenceType TypeControl
        {
            get => _typeControl;
            set
            {
                _typeControl = value;
                SetTypeControl(value);
            }
        }

        private void SetTypeControl(ControlRequestOrReferenceType type)
        {
            switch (type)
            {
                case ControlRequestOrReferenceType.None:
                    break;
                case ControlRequestOrReferenceType.Request:
                {
                    btnToReference.Visible = true;
                    btnCreate.Text = "Нова заявка";
                    btnDelete.Text = "Вилучити заявку";
                }
                    break;
                case ControlRequestOrReferenceType.Reference:
                {
                    btnToReference.Visible = false;
                    btnCreate.Text = "Створити ліцензію";
                    btnDelete.Text = "Вилучити довідку";
                }
                    break;
            }
        }

        private void gvViewRequests_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }

        private void gvViewRequests_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if(e?.CurrentRow == null || gvViewRequests.RowCount == 0)
            {
                bindingSource1.DataSource = typeof(BigRightRequestBidAuthors);
                return;
            }

            var item = e.CurrentRow.DataBoundItem as BigRightRequests;
            bindingSource1.DataSource = _authors.Where(rec => rec.LicId == item?.LicId).ToList();
        }

        #region FILTERING (пошук)

        private void gvViewRequests_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvViewRequests.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvViewRequests.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvViewRequests.EndUpdate(false);
                return;
            }

            //фільтр не пустий
            gvViewRequests.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvViewRequests.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
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

                gvViewRequests.EndUpdate(false);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvViewRequests.MasterTemplate.Refresh();
        }

        #endregion

        private void gvCreativeRole_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            var item = e.Row.DataBoundItem as BigRightRequestBidAuthors;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            switch (_typeControl)
            {
                case ControlRequestOrReferenceType.None:
                    break;
                case ControlRequestOrReferenceType.Request:
                {
                    RequestForm requestForm = new RequestForm(_customer, _bigRightView, _dictionaties);
                    if(requestForm.ShowDialog() == DialogResult.OK)
                    ; //TODO save changes
                }
                    break;
                case ControlRequestOrReferenceType.Reference:
                    break;
            }
        }
    }
}
