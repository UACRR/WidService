namespace IpsCommonTypes.DataModels
{
    public class ChangePrepaySumParams
    {
        public int LicId { get; set; }
        public int LicVersion { get; set; }
        public int CustIdRH { get; set; }
        public decimal NewAmount { get; set; }
    }
}
