using ipsFormsDesign.Dictionary;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.RightholderControls;
using RightholderWorkplace.Localisation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace RightholderWorkplace
{
    public partial class RightholderWorkplace : Telerik.WinControls.UI.RadForm
    {
        RightholderService _rightholderService = new RightholderService();
        ObjectRightService _objectRightService = new ObjectRightService();

        public RightholderWorkplace()
        {
            InitializeComponent();

            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new RadGridViewUkraineLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new RadMessageUkraineLocalizationProvider();

            var copyrightRequestPresenter = new CopyrightRequestPresenter(ctrlCopyrightRequests, _rightholderService);
        }

        #region Rightholders page

        private void miNewRightholderPerson_Click(object sender, EventArgs e)
        {
            ShowNewRightholder(1);
        }

        private void miNewRigthholderCompany_Click(object sender, EventArgs e)
        {
            ShowNewRightholder(3);
        }

        private static void ShowNewRightholder(int custType)
        {
            // TODO: move to rightholder list control + add AllowAdd property
            using (var rightholderView = new NewRightholderView())
            {
                var rightholderPresenter = new RightholderPresenter(rightholderView);
                rightholderPresenter.ShowNew(custType);
            }
        }

        private void ctrlRightholderList_RightholderSelected(object sender, RightholderMainView selectedRightholder)
        {
            // TODO: move to rightholder list control + handle double click in two way: 1. For edit by default, 2. For selection using e.Cancel (in rightholder selection control)
            using (var rightholderView = new RightholderView())
            {
                var rightholderPresenter = new RightholderPresenter(rightholderView);
                rightholderPresenter.Show(selectedRightholder.CustId);
            }
        }

        #endregion

        private void RightholderWorkplace_Load(object sender, EventArgs e)
        {
            // Change rightholders page init
            GridViewRelation relation = new GridViewRelation(gvChangeCopyrights.MasterTemplate, gvChangeCopyrightsTemplate);
            relation.RelationName = "RightholdersObjects";
            relation.ParentColumnNames.Add("ObjId");
            relation.ChildColumnNames.Add("ObjId");
            gvChangeCopyrights.Relations.Add(relation);

            dtChangeCopyrightDateFrom.Value = DateTime.Now;
            dtChangeCopyrightDateTill.Value = DateTime.Now;

            ctrlChangeRightholderOperation.SelectedValue = 3;
        }

        #region Objectrights page

        private void miAddMusicalComposition_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                int category;
                if (int.TryParse(menuItem.Tag.ToString(), out category))
                {
                    // TODO: move to presenter
                    AddObjectRight(category);
                }
            }
        }

        private void AddObjectRight(int category, RightholderMainView defaultRightholder = null)
        {
            if (category == 0)
                return;

            using (var view = new ObjectRightSrView())
            {
                var presenter = new ObjectRightSrPresenter(view);
                presenter.DefaultRightholder = defaultRightholder;
                presenter.ShowNew(category);
            }
        }

        private void ctrlObjectRightList_EditCommandExecuted(object sender, ObjectRightMainView selectedObject)
        {
            EditObjectRight(selectedObject);
        }

        private void ctrlObjectRightList_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            EditObjectRight(selectedObject);
        }

        private void EditObjectRight(ObjectRightMainView objectRight)
        {
            if (objectRight.Category == "M")
            {
                using (var view = new ObjectRightSrView())
                {
                    var presenter = new ObjectRightSrPresenter(view);
                    presenter.Show(objectRight.ObjId);
                }
            }
            else
            {
                using (var view = new ObjectRightBrView())
                {
                    var presenter = new ObjectRightBrPresenter(view);
                    presenter.Show(objectRight.ObjId);
                }
            }
        }

        #endregion

        #region Change rightholders page

        private BindingList<ObjectCopyright> _objectsCopyrightList = new BindingList<ObjectCopyright>();

        private void ctrlRightholdersObjectsForChange_RightholderChanged(object sender, RightholderMainView selectedRightholder)
        {
            objectRightForChangeBindingSource.DataSource = ctrlRightholdersObjectsForChange.ObjectsRightsList;
            _objectsCopyrightList.Clear();
            objectCopyrightBindingSource.DataSource = _objectsCopyrightList;
        }

        private void ctrlChangeRightholderOperation_SelectedValueChanged(object sender, EventArgs e)
        {
            var isTransfer = ctrlChangeRightholderOperation.SelectedValue == 5;
            var isDeath = ctrlChangeRightholderOperation.SelectedValue == 3;

            lblChangeCopyrightDateTill.Visible = isTransfer;
            dtChangeCopyrightDateTill.Visible = isTransfer;
        }

        private void btnAddNewRightholder_Click(object sender, EventArgs e)
        {
            if (ctrlRightholdersObjectsForChange.SelectedRightholder == null)
            {
                MessageBox.Show("Виберіть правовласника, чиї об'єкти треба передати.");
                return;
            }
            if (ctrlRightholdersObjectsForChange.SelectedRightholder != null && ctrlRightholdersObjectsForChange.ObjectsRightsList.Count == 0)
            {
                MessageBox.Show("У вибраного правовласника відсутні об'єкти для передачі.");
                return;
            }

            using (var selectionView = new RightholderSelectionView())
            {
                selectionView.SetAllowedStatuses(new[] {
                    AgreementStatuses.NotAccepted,
                    AgreementStatuses.OnAcception,
                    AgreementStatuses.Active,
                    AgreementStatuses.Inheritance,
                });
                selectionView.RightholderSelected += SelectionView_RightholderSelected;
                selectionView.ShowDialog();
            }
        }

        private void SelectionView_RightholderSelected(object sender, RightholderMainView addedRightholder)
        {
            if (ctrlRightholdersObjectsForChange.SelectedRightholder.CustId == addedRightholder.CustId)
            {
                MessageBox.Show("Не можна додати правовласника, з якого передаються об'єкти, в якості правонаступника.");
                return;
            }
            if (_objectsCopyrightList.Any(oc => oc.CustId == addedRightholder.CustId))
            {
                MessageBox.Show("Вибраний правовласник вже є в списку правонаступників.");
                return;
            }

            var objectsRightsList = ctrlRightholdersObjectsForChange.ObjectsRightsList;

            using (gvChangeCopyrights.DeferRefresh())
            {

                objectsRightsList.ForEach(or =>
                {
                    var newObjectCopyright = new ObjectCopyright
                    {
                        ObjId = or.ObjId,
                        CustId = addedRightholder.CustId,
                        //RoleCode = or.RoleCode, ???
                        InnerCode = addedRightholder.InnerCode,
                        InterCode = addedRightholder.InterCode,
                        Name = addedRightholder.Name,
                        Rate = 0,
                        Rightholder = addedRightholder,
                    };
                    _objectsCopyrightList.Add(newObjectCopyright);
                });

                DistributePersent();

                gvChangeCopyrights.MasterTemplate.ExpandAll();
            }
        }

        private void DistributePersent()
        {
            foreach (var row in gvChangeCopyrights.Rows)
            {
                // if manual distribution is set then continue
                if (row.Cells["IsManualPersent"].Value != null && (bool)row.Cells["IsManualPersent"].Value)
                    continue;

                var obj = row.DataBoundItem as ObjectRightForRightholder;

                var copyrightList = _objectsCopyrightList.Where(cr => cr.ObjId == obj.ObjId);
                var copyrightCount = copyrightList.Count();
                double newRate = (obj.RateRh ?? 0) / copyrightCount;
                double newRoundRate = Math.Round(newRate, 2);
                var delta = (newRate - newRoundRate) * copyrightCount;

                foreach (var copyright in copyrightList)
                {
                    copyright.Rate = newRoundRate + delta;
                    delta = 0.0;
                }
            }
        }

        private void gvChangeCopyrights_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.ViewTemplate.Parent == null)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = Color.LightGray;
                e.RowElement.Font = new Font(e.RowElement.Font, FontStyle.Bold);
            }
        }

        private void gvChangeCopyrights_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.Name == "Rate")
            {
                var parentRow = e.Row.Parent as GridViewHierarchyRowInfo;

                // if manual distribution is not set then cancel
                if (parentRow.Cells["IsManualPersent"].Value == null || !(bool)parentRow.Cells["IsManualPersent"].Value)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSaveNewCopyrights_Click(object sender, EventArgs e)
        {
            if (_objectsCopyrightList.Count == 0)
            {
                MessageBox.Show("Додайте нових правонаступників.");
                return;
            }

            var rightholders = new List<RightHolder>();

            // old rightholder
            var oldRightholder = new RightHolder
            {
                CustId = ctrlRightholdersObjectsForChange.SelectedRightholder.CustId,
                CopyRight = new ObservableListSource<CopyRight>(),
            };

            oldRightholder.CopyRight.Add(new CopyRight { EndDate = dtChangeCopyrightDateFrom.Value.AddDays(-1) });
            
            rightholders.Add(oldRightholder);


            // new copyrighs
            var groupedCopyright = _objectsCopyrightList
                .Where(oc => oc.Rate != 0)
                .GroupBy(oc => oc.CustId);

            foreach (var rightholderGroup in groupedCopyright)
            {
                var newRightholder = new RightHolder
                {
                    CustId = rightholderGroup.Key,
                    Cust = new Customer { Status = 9 },
                    CopyRight = new ObservableListSource<CopyRight>(),
                };

                foreach (var copyright in rightholderGroup)
                {
                    var newCprt = new CopyRight
                    {
                        CustId = newRightholder.CustId,
                        ObjId = copyright.ObjId,
                        RoleCode = 8, // Правовласник
                        LBasis = 3,
                        Rate = (decimal)copyright.Rate, // decimal or double?
                        BeginDate = dtChangeCopyrightDateFrom.Value,
                        EndDate = new DateTime(3000, 1, 1),
                        //ParentId = 
                        Obj = new ObjectRight(),
                    };
                    newCprt.Obj.Authors.Add(new Authors
                    {
                        CustId = newRightholder.CustId,
                        ObjId = copyright.ObjId,
                        FolkType = 1,
                        RoleCode = 8, // Правовласник
                        AuthorName = copyright.Name,
                    });
                    newRightholder.CopyRight.Add(newCprt);
                }
                rightholders.Add(newRightholder);
            }

            var result = _rightholderService.Inherit(ctrlRightholdersObjectsForChange.SelectedRightholder.CustId, rightholders);

            MessageBox.Show("Зміна правовласників виконана успішно.");

            ctrlRightholdersObjectsForChange.SelectedRightholder = _objectsCopyrightList.FirstOrDefault()?.Rightholder;
        }

        private void btnCancelNewCopyright_Click(object sender, EventArgs e)
        {
            ctrlRightholdersObjectsForChange.SelectedRightholder = null;
        }

        private void ctrlRightholdersObjectsForChange_EditObjectCommandExecuted(object sender, ObjectRightForRightholder selectedObject)
        {
            EditObjectRight(selectedObject);
        }

        #endregion
    }
}
