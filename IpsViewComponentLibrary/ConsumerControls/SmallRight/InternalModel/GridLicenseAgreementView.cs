using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight.InternalModel
{
    /// <summary>
    /// Intermediate class for grid DataSource
    /// </summary>
    public class GridLicenseAgreementView
    {
        public int Id { get; set; }
        public string LicenseCode { get; set; }
        public int? LicVersion { get; set; }
        public string License { get; set; }
        public string Series { get; set; }
        public string AgrNumber { get; set; }
        public string AgrMasterNumber { get; set; }
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MinRate { get; set; }
        public string State { get; set; }
        public int? Status { get; set; }
        public string PeriodPayment { get; set; }
        public string DateLastPayment { get; set; }
        public int LicId { get; set; }
        public bool IsAutoprolog { get; set; }
        public LicenseAgreement LicenseAgreement;
    }
}
