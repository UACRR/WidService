using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class CreatePartnerForm : Telerik.WinControls.UI.RadForm
    {
        private const string TitleJur = "Додавання нового представника (юридична особа)";
        private const string TitlePhis = "Додавання нового представника (фізична особа)";

        private readonly IAnketaControls _anketaControl;

        private PartnerAnketaPhisControl _phisControl = null;
        private PartnerAnketaJurControl _jurControl = null;
        private Customer _customer;

        public CreatePartnerForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            DialogResult = DialogResult.None;

            // представник фізична особа
            if (customer.CustType == 1)
            {
                Text = TitlePhis;
                _anketaControl = Architector.IncludeInstanceWhithReturn(this, _phisControl);
            }
            // представник юридична особа
            else if (customer.CustType == 3)
            {
                Text = TitleJur;
                _anketaControl = Architector.IncludeInstanceWhithReturn(this, _jurControl);
            }

            _anketaControl.BeginBindings(_customer);
            _anketaControl.SaveClick += SaveClick;
        }

        private void SaveClick(object sender, bool accept)
        {
            if (accept && _customer != null)
            {
                // підтверджений представник
                _customer.Status = 2;
                _customer.AgreementMaster.SingleOrDefault().AgrStatus = 2;
                _customer.AgreementMaster.SingleOrDefault().AgreementAddPartner.SingleOrDefault().AgrStatus = 2;
                if(_customer.CustType == 1) //  фізична особа
                    _customer.Person.AnketaPerson.SingleOrDefault().Status = 2;
                else if (_customer.CustType == 3) // юридична особа
                    _customer.Company.AnketaCompany.SingleOrDefault().Status = 2;
            }
            DialogResult = DialogResult.OK;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
        
    }
}
