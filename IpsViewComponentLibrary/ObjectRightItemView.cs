using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class ObjectRightItemView : Telerik.WinControls.UI.RadForm, IObjectRightItemView
    {
        private ObjectRightItemPresenter _presenter;
        public ObjectRightItemPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        //private IList<ViewCustomer> _rightholderList = new List<ViewCustomer>();
        //public IList<ViewCustomer> RightholderList
        //{
        //    set
        //    {
        //        _rightholderList = value;
        //    }
        //}

        //private ObjectRight _objectRight;
        //public ObjectRight ObjectRight
        //{
        //    get { return _objectRight; }
        //    set
        //    {
        //        _objectRight = value;
        //        UpdateObjectRightDataSources();
        //    }
        //}

        public IList<ViewCustomer> RightholderList { private get; set; }
        public ObjectRight ObjectRight { get; set; }

        public ObjectAuthorRightholder SelectedObjectAuthorRightholder
        {
            get
            {
                return gvObjectAuthorsRightholders.CurrentRow.DataBoundItem as ObjectAuthorRightholder;
            }
        }

        public ObjectRightItemView()
        {
            InitializeComponent();

            // filter only add names
            FilterDescriptor filterByName = new FilterDescriptor();
            filterByName.PropertyName = "CodeI";
            filterByName.Operator = FilterOperator.IsEqualTo;
            filterByName.Value = 1;
            filterByName.IsFilterEditor = true;
            gvObjectAddNames.FilterDescriptors.Add(filterByName);

            // filter only performers
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
            // TODO: move map to presenter and bind to binding sources exposes from view - think about it

            ObjectRight = objectRight;

            if (rightholderList == null)
                rightholderList = new List<ViewCustomer>();

            objectRightBindingSource.DataSource = ObjectRight;
            mediaTrackBindingSource.DataSource = ObjectRight.MediaTrack;

            ObjectRight.SeekObject = ObjectRight.SeekObject;
            seekObjectBindingSource.DataSource = ObjectRight.SeekObject;

            // map Authors and Copyright table into single table
            var objectAuthorRightholderList = ObjectRight.Authors.Select(a =>
            {

                var foundedCopyright = ObjectRight.CopyRight.FirstOrDefault(c => c.CustId == a.CustId && c.RoleCode == a.RoleCode);
                var foundedRightholder = rightholderList.FirstOrDefault(r => r.custId == a.CustId);

                return new ObjectAuthorRightholder
                {
                    AuthId = a.AuthId,
                    ObjId = a.ObjId,
                    RoleCode = a.RoleCode,
                    FolkType = a.FolkType,
                    AuthorName = a.AuthorName,
                    IsRightholder = a.CustId != null,
                    CustId = a.CustId,
                    CRightId = foundedCopyright?.CRightId,
                    CopyrightStatus = foundedCopyright?.Status,
                    CommunityName = foundedRightholder?.Community_Name,
                    Rate = foundedCopyright?.Rate,
                    BeginDate = foundedCopyright?.BeginDate,
                    EndDate = foundedCopyright?.EndDate,
                };
            }).ToList();

            objectAuthorRightholderBindingSource.DataSource = objectAuthorRightholderList;
        }




        private void UpdateAutocompliteItems(string filter)
        {
            var objects = Presenter.GetObjectsForAutocomplite(filter);

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
                Presenter.ObjectNameAutocompliteListItemSelected(obj.ObjId);
            }
        }

        private void btnNewObject_Click(object sender, EventArgs e)
        {
            if (ObjectRight == null)
                return;

            Presenter.NewObject();
        }

        private void gvObjectAuthorsRightholders_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            GridViewTooltipHelper.SetTooltipTextForColumnHeader(sender, e);
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
                //EditObjectAuthorRightholder(); // to fix
            }
            else if (currentColumnName == "DeleteColumn")
            {
                //DeleteObjectAuthorRightholder(); // to fix
            }
        }

        private void gvObjectAuthorsRightholders_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            //EditObjectAuthorRightholder(); // to fix
        }

        private void btnAddAuthorRightholder_Click(object sender, EventArgs e) // to fix
        {
            //var objectAuthorRightholder = new ObjectAuthorRightholder(_forRightholder);

            //EditObjectAuthorRightholder(objectAuthorRightholder);
        }

        private void btnObjectRightItemCancel_Click(object sender, EventArgs e) // to fix
        {
            //_forRightholder = null;
            //objectsPageView.SelectedPage = _previousPage;
            //actualObjectsPageView.SelectedPage = actualObjectsListPage;
        }

        private void btnObjectRightItemSave_Click(object sender, EventArgs e) // to fix
        {
            //if (_objectRight == null)
            //{
            //    return;
            //}

            //_forRightholder = null;

            //// transform from single table to Authors and Copyright tables
            //_objectRight.Authors.Clear();
            //_objectRight.CopyRight.Clear();

            //var objectAuthorRightholderList = objectAuthorRightholderBindingSource.List.Cast<ObjectAuthorRightholder>().ToList();
            //objectAuthorRightholderList.ForEach(ar => _objectRight.AddObjectAuthorRightholder(ar));

            //if (_objectRight.CopyRight.GetTotalRate() > 100)
            //{
            //    MessageBox.Show("Загальний відсоток володіння не може бути більше 100.", "Помилка");
            //    return;
            //}

            //_objectRightService.Save(_objectRight);

            //if (_previousPage == actualObjectsPage)
            //{
            //    ctrlObjectRightList.UpdateList(new ObjectRightMainView { ObjId = _objectRight.ObjId });
            //    ctrlRightholdersObjectsRight.UpdateList();
            //}
            //else if (_previousPage == rightholdersObjectsPage)
            //{
            //    ctrlRightholdersObjectsRight.UpdateList(new ObjectRightForRightholder { ObjId = _objectRight.ObjId });
            //    ctrlObjectRightList.UpdateList();
            //}

            //objectsPageView.SelectedPage = _previousPage;
            //actualObjectsPageView.SelectedPage = actualObjectsListPage;

            //UpdateRightholdersList(SelectedRightholder);
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
    }
}
