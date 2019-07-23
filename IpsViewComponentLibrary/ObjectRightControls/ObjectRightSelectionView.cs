using ipsFormsDesign.Dictionary;
using System;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightSelectionView : Telerik.WinControls.UI.RadForm
    {
        public event EventHandler<ObjectRightMainView> ObjectSelected = delegate { };

        public ObjectRightSelectionView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var item = ctrlObjectRightList.SelectedObject;

            if (item != null)
            {
                OnObjectSelected(item);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
                DialogResult = DialogResult.None;
        }

        private void ctrlObjectRightList_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            EditObjectRight(selectedObject);
        }

        private void ctrlObjectRightList_EditCommandExecuted(object sender, ObjectRightMainView selectedObject)
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

        private void OnObjectSelected(ObjectRightMainView item)
        {
            ObjectSelected(this, item);
        }
    }
}
