using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.Utilities
{
    public class CurrentAgreementController : Component
    {
        public event EventHandler<LicenseAgreement> CurrentLicenseAgreementChanged;
        private LicenseAgreement _current;
        public int LicId { get => _current?.LicId ?? 0; }
        public void ChangeCurrentLicenseAgreement(object sender, LicenseAgreement current)
        {
            _current = current;
            CurrentLicenseAgreementChanged?.Invoke(sender, _current);
        }
    }
}
