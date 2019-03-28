using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.ObjectsRight;
using ipsFormsDesign.ViewModels.Rightholders;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.RightholderControls;
using IpsViewComponentLibrary.Utilities;
using RightholderWorkplace.Localisation;
using RightholderWorkplace.Presenters;
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
    public partial class RightholderWorkplace : RadForm
    {
        RightholderService _rightholderService = new RightholderService();
        ObjectRightService _objectRightService = new ObjectRightService();
        AmountDistributor _persentDistributor = new AmountDistributor();
        private CommunityPresenter _communityPresenter;  // main presenter for community


        public RightholderWorkplace()
        {
            var objectrightService = new ObjectRightService();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());

            IpsGlobal.Properties.Add("OwnerName", _rightholderService.GetOwnerName()?.Name );

            InitializeComponent();

            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new IpsUARadGridLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new RadMessageUkraineLocalizationProvider();
            var _communityService = new CommunityService();
            _communityPresenter = new CommunityPresenter(_communityService, ctrlCommunity);

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
            GridViewRelation relation = new GridViewRelation(gvObjectRightForTransfering.MasterTemplate, gvChangeCopyrightsTemplate);
            relation.RelationName = "RightholdersObjects";
            relation.ParentColumnNames.Add("ObjId");
            relation.ChildColumnNames.Add("ObjId");
            gvObjectRightForTransfering.Relations.Add(relation);
            gvObjectRightForTransfering.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);

            dtChangeCopyrightDateFrom.Value = DateTime.Now;

            ctrlChangeRightholderOperation.SelectedValue = (int)LegalBasisType.Transfer;
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

        private BindingList<ObjectRightForTransfering> _objects = new BindingList<ObjectRightForTransfering>();
        private BindingList<ObjectCopyright> _copyrights = new BindingList<ObjectCopyright>();

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
            if (_copyrights.Any(oc => oc.CustId == addedRightholder.CustId))
            {
                MessageBox.Show("Вибраний правовласник вже є в списку правонаступників.");
                return;
            }

            using (gvObjectRightForTransfering.DeferRefresh())
            {
                foreach (var obj in _objects)
                {
                    var newObjectCopyright = new ObjectCopyright
                    {
                        ObjId = obj.ObjId,
                        CustId = addedRightholder.CustId,
                        //RoleCode = or.RoleCode, ???
                        InnerCode = addedRightholder.InnerCode,
                        InterCode = addedRightholder.InterCode,
                        Name = addedRightholder.Name,
                        Rate = 0,
                        Rightholder = addedRightholder,
                    };
                    _copyrights.Add(newObjectCopyright);
                }

                DistributeAllPersents();

                gvObjectRightForTransfering.MasterTemplate.ExpandAll();
            }
        }

        private void DistributeAllPersents()
        {
            foreach (var obj in _objects.Where(obj => !obj.ManualDistribution).ToList())
            {
                DistributePersentForObject(obj);
            }
        }

        private void gvObjectRightForTransfering_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ManualDistribution")
                if (e.Row.DataBoundItem is ObjectRightForTransfering obj)
                    if (!obj.ManualDistribution)
                        DistributePersentForObject(obj);
        }

        private void DistributePersentForObject(ObjectRightForTransfering obj)
        {
            var copyrightList = _copyrights.Where(cr => cr.ObjId == obj.ObjId);

            _persentDistributor.DistributeByEqualAmount(copyrightList, obj.RateRh, cr => cr.Rate);
        }

        private void ctrlRightholdersObjectsForChange_MarkedObjectsRightsChanged(object sender, EventArgs e)
        {
            UpdateTransferButtonsEnabling();
        }

        private void ctrlChangeRightholderOperation_SelectedValueChanged(object sender, EventArgs e)
        {
            var isTransfer = ctrlChangeRightholderOperation.SelectedValue == (int)LegalBasisType.Transfer;
            var isInheritance = ctrlChangeRightholderOperation.SelectedValue == (int)LegalBasisType.Inheritance;

            lblChangeCopyrightDateTill.Visible = isTransfer;
            dtChangeCopyrightDateTill.Visible = isTransfer;

            ctrlRightholdersObjectsForChange.AllowMarkingRows = isTransfer;

            UpdateTransferButtonsEnabling();
        }

        private void UpdateTransferButtonsEnabling()
        {
            var isTransfer = ctrlChangeRightholderOperation.SelectedValue == (int)LegalBasisType.Transfer;

            btnTransferAll.Enabled = isTransfer;
            btnTransferSelected.Enabled = isTransfer && ctrlRightholdersObjectsForChange.MarkedObjectsRights.Count != 0;
        }

        private void ctrlRightholdersObjectsForChange_RightholderChanged(object sender, RightholderMainView selectedRightholder)
        {
            bsObjectRightForTransfering.DataSource = _objects;
            bsObjectCopyright.DataSource = _copyrights;

            _objects.Clear();
            _copyrights.Clear();

            if (ctrlChangeRightholderOperation.SelectedValue == (int)LegalBasisType.Inheritance)
            {
                MoveAllObjectsToTransfer();
                //show count elements into grid
                lblCount.Text = _objects.Count().ToString();
            }
        }

        private void btnTransferAll_Click(object sender, EventArgs e)
        {
            MoveAllObjectsToTransfer();
        }

        private void MoveAllObjectsToTransfer()
        {
            MoveObjectsListToTransfer(ctrlRightholdersObjectsForChange.ObjectsRightsList);
        }

        private void btnTransferSelected_Click(object sender, EventArgs e)
        {
            MoveSelectedObjectsToTransfer();
        }

        private void MoveSelectedObjectsToTransfer()
        {
            MoveObjectsListToTransfer(ctrlRightholdersObjectsForChange.MarkedObjectsRights);
        }

        private void MoveObjectsListToTransfer(List<ObjectRightForRightholder> list)
        {
            foreach (var obj in list)
            {
                if (_objects.FirstOrDefault(o => o.ObjId == obj.ObjId) == null)
                {
                    var objForTransf = (ObjectRightForTransfering)obj;

                    if (ctrlChangeRightholderOperation.SelectedValue == (int)LegalBasisType.Transfer)
                    {
                        objForTransf.ManualDistribution = true;
                    }

                    _objects.Add(objForTransf);
                }
            }
        }

        private void gvObjectRightForTransfering_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "DeleteColumn")
            {
                var obj = (ObjectRightForTransfering)e.Row.DataBoundItem;

                var crToRemove = _copyrights.Where(cr => cr.ObjId == obj.ObjId).ToList();
                crToRemove.ForEach(cr => _copyrights.Remove(cr));

                _objects.Remove(obj);
            }
        }

        private void gvObjectRightForTransfering_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.ViewTemplate.Parent == null)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = Color.LightGray;
                e.RowElement.Font = new Font(e.RowElement.Font, FontStyle.Bold);
            }
        }

        private void gvObjectRightForTransfering_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.Name == "Rate")
            {
                var parentRow = (GridViewHierarchyRowInfo)e.Row.Parent;
                var objForTransfering = (ObjectRightForTransfering)parentRow.DataBoundItem;

                if (!objForTransfering.ManualDistribution)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gvObjectRightForTransfering_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Row.DataBoundItem is ObjectCopyright copyright)
            {
                e.Row.Cells["Rate"].ErrorText = copyright.Error;
            }

            IpsViewComponentLibrary.Utilities.GridViewHelper.DisplayErrors(sender, e);
        }

        private void ctrlRightholdersObjectsForChange_RightholderChanging(object sender, CancelEventArgs e)
        {
            if (!ConfirmClear())
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnClearNewCopyright_Click(object sender, EventArgs e)
        {
            if (!ConfirmClear())
                return;

            ctrlRightholdersObjectsForChange.SelectedRightholder = null;
            dtChangeCopyrightDateTill.Value = dtChangeCopyrightDateTill.NullDate;
        }

        private bool ConfirmClear()
        {
            if (_objects.Count != 0)
                if (RadMessageBox.Show(this, "Зміни для обраних об'єктів не буде збережено. Продовжити?", "Питання", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                    return false;

            return true;
        }

        private void btnSaveNewCopyrights_Click(object sender, EventArgs e)
        {
            if (_copyrights.Count == 0)
            {
                MessageBox.Show("Додайте нових правонаступників.");
                return;
            }



            if (ctrlChangeRightholderOperation.SelectedValue == (int)LegalBasisType.Transfer
                && dtChangeCopyrightDateTill.Value == dtChangeCopyrightDateTill.NullDate)
            {
                MessageBox.Show("Вкажіть дату по яку передаються права на обрані об'єкти.");
                return;
            }
            if (dtChangeCopyrightDateTill.Value == dtChangeCopyrightDateTill.NullDate)
                dtChangeCopyrightDateTill.Value = new DateTime(3000, 1, 1);

            if (ctrlChangeRightholderOperation.SelectedValue == (int)LegalBasisType.Inheritance && !ValidateTransferedParamsForInheritance())
            {
                gvObjectRightForTransfering.TableElement.Update(GridUINotifyAction.Reset);
                MessageBox.Show("Не корректно вказаний відсоток переданих прав. Відкорегуйте значення та повторіть збереження");
                return;
            }

            if (!ValidateTransferedParams())
            {
                gvObjectRightForTransfering.TableElement.Update(GridUINotifyAction.Reset);
                MessageBox.Show("Не корректно вказаний відсоток переданих прав. Відкорегуйте значення та повторіть збереження");
                return;
            }

            var transferParams = new TransferParameters();
            transferParams.DateFrom = dtChangeCopyrightDateFrom.Value;
            transferParams.DateTill = dtChangeCopyrightDateTill.Value;
            transferParams.OldRightholderId = ctrlRightholdersObjectsForChange.SelectedRightholder.CustId;
            transferParams.LegalBasis = ctrlChangeRightholderOperation.SelectedValue.Value;

            var groupedCopyright = _copyrights
                .Where(oc => oc.Rate != 0)
                .GroupBy(oc => oc.ObjId);

            foreach (var objectGroup in groupedCopyright)
            {
                var transferedObject = new TransferedObject { ObjId = objectGroup.Key };
                transferParams.ObjectsRightList.Add(transferedObject);

                foreach (var copyright in objectGroup)
                {
                    transferedObject.NewRightholderList.Add(new NewRightholder
                    {
                        CustId = copyright.CustId,
                        Rate = copyright.Rate,
                    });
                }
            }

            var result = _rightholderService.Transfer(transferParams);

            if (result)
            {
                MessageBox.Show("Передача об'єктів виконана успішно.");

                ApplicationController.Instance.EventAggregator.PublishEvent(new ObjectRightUpdatedEvent());
                ApplicationController.Instance.EventAggregator.PublishEvent(new RightholderUpdatedEvent());

                dtChangeCopyrightDateTill.Value = dtChangeCopyrightDateTill.NullDate;

                _copyrights.Clear();
                _objects.Clear();
            }
            else
                MessageBox.Show("Не вдалося виконати передачу об'єктів.");
        }

        private bool ValidateTransferedParams()
        {
            var result = true;

            foreach (var obj in _objects)
            {
                var copyrights = _copyrights.Where(c => c.ObjId == obj.ObjId).ToList();

                if (copyrights.Any())
                {
                    var totalRate = copyrights.Sum(c => c.Rate);

                    if (totalRate > obj.RateRh)
                    {
                        result = false;
                        copyrights.ForEach(c => c.Error = "Не корректно вказаний відсоток переданих прав. Відкорегуйте значення та повторіть збереження");
                    }
                }
            }

            return result;
        }

        private bool ValidateTransferedParamsForInheritance()
        {
            var result = true;

            foreach (var obj in _objects)
            {
                var copyrights = _copyrights.Where(c => c.ObjId == obj.ObjId).ToList();

                if (copyrights.Any())
                {
                    var totalRate = copyrights.Sum(c => c.Rate);

                    if (totalRate != obj.RateRh)
                    {
                        result = false;
                        copyrights.ForEach(c => c.Error = "Не корректно вказаний відсоток переданих прав. Відкорегуйте значення та повторіть збереження");
                    }
                }
            }

            return result;
        }
        #endregion
    }
}
