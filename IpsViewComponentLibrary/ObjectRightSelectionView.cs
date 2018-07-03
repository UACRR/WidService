using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ObjectRightSelectionView : Telerik.WinControls.UI.RadForm
    {
        public event EventHandler<ObjectRightMainView> ObjectSelected = delegate { };

        public ObjectRightSelectionView()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void ctrlObjectRightList_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            SelectAndClose();
        }

        private void SelectAndClose()
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

        private void OnObjectSelected(ObjectRightMainView item)
        {
            ObjectSelected(this, item);
        }
    }
}
