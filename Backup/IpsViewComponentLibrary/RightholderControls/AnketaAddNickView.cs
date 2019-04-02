using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class AnketaAddNickView : Telerik.WinControls.UI.RadForm
    {
        private ICollection<AnketaAddNick> _anketaAddNicks;

        public EventHandler<ICollection<AnketaAddNick>> AddNicksUpdated;

        public AnketaAddNickView(ICollection<AnketaAddNick> anketaAddNicks)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;

            _anketaAddNicks = anketaAddNicks.ToList();

            InitializeBindings();
        }

        private void InitializeBindings()
        {
            anketaAddNickBindingSource.DataSource = _anketaAddNicks;
            gvNicks.DataSource = anketaAddNickBindingSource;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            OnAddNicksUpdated();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gvNicks.Rows.AddNew();
            gvNicks.CurrentRow.Cells[0].BeginEdit();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            gvNicks.Rows.Remove(gvNicks.CurrentRow);
        }

        private void OnAddNicksUpdated()
        {
            AddNicksUpdated?.Invoke(this, _anketaAddNicks);
        }
    }
}
