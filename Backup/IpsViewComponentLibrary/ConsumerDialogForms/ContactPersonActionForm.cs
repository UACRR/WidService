using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class ContactPersonActionForm : Telerik.WinControls.UI.RadForm
    {
        private const string TitleCreate = "Додати контактну особу";
        private const string TitleEdit = "Редагування контактної особи";
        private const string PerformentComment = "Виконавець";
        private string _cacheComment;

        private readonly List<InternalPositionType> _positionTypes = new List<InternalPositionType>
        {
            new InternalPositionType
            {
                CodeI = 3,
                Name = "Виконавець"
            },
            new InternalPositionType
            {
                CodeI = 4,
                Name = "Додаткова контактна особа"
            },
        };

        public ContactPersonActionForm(RelEmployee relEmployee, FLoadType type)
        {
            InitializeComponent();
            switch (type)
            {
                case FLoadType.Create:
                    Text = TitleCreate;
                    break;
                case FLoadType.Edit:
                    Text = TitleEdit;
                    if (relEmployee.PositionCode == 4)
                        _cacheComment = relEmployee.Empl.Comment;
                    break;
            }

            ddlPosition.DataSource = _positionTypes;
            ddlPosition.ValueMember = "CodeI";
            ddlPosition.DisplayMember = "Name";

            bsRelEmpl.DataSource = relEmployee;
            bsEmpl.DataSource = relEmployee.Empl;
            ctrlContactPerson.DataSource = relEmployee.Empl;

            if (relEmployee.PositionCode == 4)
                ddlPosition.Enabled = false;

            ddlPosition.SelectedValueChanged += ddlPosition_SelectedValueChanged;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public class InternalPositionType
        {
            public int CodeI { get; set; }
            public string Name { get; set; }
        }

        private void ddlPosition_SelectedValueChanged(object sender, EventArgs e)
        {
            // Виконавець
            if (ddlPosition.SelectedItem.DataBoundItem is InternalPositionType item && item.CodeI == 3)
            {
                (bsEmpl.DataSource as Employee).Comment = PerformentComment;
                txtComment.Enabled = false;
            }
            else
            {
                txtComment.Enabled = true;
                (bsEmpl.DataSource as Employee).Comment = _cacheComment;
            }

            bsEmpl.ResetBindings(true);
        }
    }
}
