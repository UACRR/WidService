using System;
using System.Drawing;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    public partial class PremisesAdditionalDetailForm : RadForm
    {
        private const string TitleAdd = "Додати приміщення бізнес-точки";
        private const string TitleEdit = "Редагування приміщення бізнес-точки";

        public PremisesAdditionalDetailForm(ClnPlaceHoll clnPlaceHoll, PremisesFormTypeInitialization action)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            // binding
            bsClnPlaceHoll.DataSource = clnPlaceHoll;
            ctrlParameter.DataSource = clnPlaceHoll;

            if (action == PremisesFormTypeInitialization.CreateNew)
                Text = TitleAdd;
            else if (action == PremisesFormTypeInitialization.Edit)
                Text = TitleEdit;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
    }
}
