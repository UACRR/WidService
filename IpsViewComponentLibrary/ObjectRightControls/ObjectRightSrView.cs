using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightSrView : RadForm, IObjectRightItemView
    {
        private const int DefaultObjectRightGenreTypeSongCode = 41;

        private ObjectRightSrPresenter _presenter;
        public ObjectRightSrPresenter Presenter
        {
            get => _presenter;
            set
            {
                if (_presenter == null)
                    _presenter = value;
            }
        }

        public IList<ViewCustomer> RightholderList { private get; set; }
        public ObjectRight ObjectRight { get; set; }

        public ObjectAuthorRightholder SelectedObjectAuthorRightholder => gvObjectAuthorsRightholders.CurrentRow.DataBoundItem as ObjectAuthorRightholder;

        private readonly BindingList<ObjectAuthorRightholder> _objectAuthorRightholderList = new BindingList<ObjectAuthorRightholder>();
        public Collection<ObjectAuthorRightholder> ObjectAuthorRightholderList => _objectAuthorRightholderList;

        public ObjectRightSrView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            gvObjectAuthorsRightholders.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);
            gvObjectAuthorsRightholders.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);

            InitializeGridFilters();
        }

        private void InitializeGridFilters()
        {
            // filter - only add names
            FilterDescriptor filterByName = new FilterDescriptor();
            filterByName.PropertyName = "CodeI";
            filterByName.Operator = FilterOperator.IsEqualTo;
            filterByName.Value = 1;
            filterByName.IsFilterEditor = true;
            gvObjectAddNames.FilterDescriptors.Add(filterByName);

            // filter - only performers
            FilterDescriptor filterByPerformer = new FilterDescriptor();
            filterByPerformer.PropertyName = "CodeI";
            filterByPerformer.Operator = FilterOperator.IsEqualTo;
            filterByPerformer.Value = 2;
            filterByPerformer.IsFilterEditor = true;
            gvObjectPerformers.FilterDescriptors.Add(filterByPerformer);
        }

        public void Run()
        {
            ShowDialog();
        }

        public void SetDictionaries(ObjectRightDictionaries dictionaries, int category)
        {
            ddlGenreType.DataSource = dictionaries.genreType.Where(g => g.CategoryCode == category);
            ddlGenreType.ValueMember = "CodeI";
            ddlGenreType.DisplayMember = "Name";

            ddlSpecType.DataSource = dictionaries.specType;
            ddlSpecType.ValueMember = "CodeI";
            ddlSpecType.DisplayMember = "Name";

            var columnRoleCode = gvObjectAuthorsRightholders.Columns["RoleCode"] as GridViewComboBoxColumn;
            columnRoleCode.DataSource = dictionaries.creativeRoleType;
            columnRoleCode.ValueMember = "CodeI";
            columnRoleCode.DisplayMember = "Name";

            var columnFolkType = gvObjectAuthorsRightholders.Columns["FolkType"] as GridViewComboBoxColumn;
            columnFolkType.DataSource = dictionaries.folkType;
            columnFolkType.ValueMember = "CodeI";
            columnFolkType.DisplayMember = "Name";
        }

        public void UpdateObjectRightDataSources(ObjectRight objectRight, IList<ViewCustomer> rightholderList)
        {
            // TODO: (implemented) move map to presenter and bind to binding sources exposes from view - think about it (there is ObjectAuthorRightholderList property)
            // TODO: move to constructor, move other binding initialization to constructor, set bindings for MediaTrack, SeekObject in the presenter throught property

            ObjectRight = objectRight;

            if (ObjectRight.GenreType == null)
                ObjectRight.GenreType = DefaultObjectRightGenreTypeSongCode;

            objectRightBindingSource.DataSource = ObjectRight;
            mediaTrackBindingSource.DataSource = ObjectRight.MediaTrack;

            ObjectRight.SeekObject = ObjectRight.SeekObject;
            seekObjectBindingSource.DataSource = ObjectRight.SeekObject;

            objectAuthorRightholderBindingSource.DataSource = _objectAuthorRightholderList;
        }

        public void SetHeader(string header)
        {
            Text = header + " - Об'єкт права";
        }

        private void UpdateAutocompliteItems(string filter)
        {
            var objects = _presenter.GetObjectsForAutocomplite(filter);

            objects.ForEach(o => autoObjectName.AutoCompleteItems.Add(
                new RadListDataItem($"{o.Name} / {o.Author} / {o.Performer}", o))
            );
        }

        private void autoObjectName_TextChanged(object sender, EventArgs e)
        {
            if (autoObjectName.Text.Length >= 2 && autoObjectName.AutoCompleteItems.Count == 0)
            {
                UpdateAutocompliteItems(autoObjectName.Text);
            }

            if (autoObjectName.Text.Length < 2 && autoObjectName.AutoCompleteItems.Count != 0)
            {
                autoObjectName.AutoCompleteItems.Clear();
            }
        }

        private void autoObjectName_ListItemSelected(object sender, RadListDataItem item)
        {
            if (item.Value is ObjectRightMainView obj)
            {
                _presenter.ObjectNameAutocompliteListItemSelected(obj.ObjId);
            }
        }

        private void btnNewObject_Click(object sender, EventArgs e)
        {
            if (ObjectRight == null)
                return;

            _presenter.NewObject();
        }

        private void gvObjectAuthorsRightholders_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void gvObjectAuthorsRightholders_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "EndDate" && e.CellElement.Text == (new DateTime(3000, 1, 1)).ToShortDateString())
            {
                e.CellElement.Text = "Не обмежено";
            }
        }

        private void gvObjectAuthorsRightholders_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                _presenter.EditObjectAuthorRightholder(SelectedObjectAuthorRightholder);
            }
            else if (currentColumnName == "DeleteColumn")
            {
                _presenter.DeleteObjectAuthorRightholder(SelectedObjectAuthorRightholder);
            }
        }

        private void gvObjectAuthorsRightholders_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            _presenter.EditObjectAuthorRightholder(SelectedObjectAuthorRightholder);
        }

        private void btnAddAuthorRightholder_Click(object sender, EventArgs e)
        {
            _presenter.AddObjectAuthorRightholder();
        }

        private void btnObjectRightItemSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Не вірно введені дані. Об'єкт не записаний.");
                DialogResult = DialogResult.None;
                return;
            }

            _presenter.Save();
        }

        private void objectAuthorRightholderBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateTotalPersent();
        }

        private void btnAddObjectAddName_Click(object sender, EventArgs e)
        {
            AddRowToGrid(gvObjectAddNames);
        }

        private void btnDeleteObjectAddName_Click(object sender, EventArgs e)
        {
            gvObjectAddNames.Rows.Remove(gvObjectAddNames.CurrentRow);
        }

        private void btnAddObjectPerformer_Click(object sender, EventArgs e)
        {
            AddRowToGrid(gvObjectPerformers);
        }

        private void btnDeleteObjectPerformer_Click(object sender, EventArgs e)
        {
            gvObjectPerformers.Rows.Remove(gvObjectPerformers.CurrentRow);
        }

        private void AddRowToGrid(RadGridView gridView)
        {
            var filterValue = gridView.FilterDescriptors.FirstOrDefault()?.Value;

            var newRow = gridView.Rows.AddNew();
            newRow.Cells["CodeI"].Value = filterValue;
            newRow.Cells["Name"].BeginEdit();
        }

        private void UpdateTotalPersent()
        {
            var totalPersent = ObjectAuthorRightholderList.Where(ar => ar.Rate != null).Sum(s => s.Rate);

            txtTotalPersent.Text = totalPersent.ToString();

            if (totalPersent == 100)
                txtTotalPersent.ForeColor = Color.Green;
            else if (totalPersent > 100)
                txtTotalPersent.ForeColor = Color.Red;
            else
                txtTotalPersent.ForeColor = SystemColors.ControlText;
        }

        private void ObjectRightSrView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.Close();
            e.Cancel = true;
        }

        #region Validation

        private void autoObjectName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(autoObjectName.Text))
            {
                errorProvider.SetError(autoObjectName, "Назва об'єкта є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(autoObjectName, "");
        }

        #endregion
    }
}
