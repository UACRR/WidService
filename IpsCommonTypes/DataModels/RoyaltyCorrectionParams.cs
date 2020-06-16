namespace IpsCommonTypes.DataModels
{
    /// <summary>
    /// Клас параметрів для процедури виправлення помилково нарахованих роялті
    /// </summary>
    public class RoyaltyCorrectionParams
    {
        // счет, на который надо перебросить
        public int CustIdD { get; set; }
        // счет, с которщго надо списать
        public int CustIdK { get; set; }
        // код вида права 
        public int KindCode { get; set; }
        // код объекта
        public int Objid { get; set; }
        // сумма
        public decimal Amount { get; set; }
    }
}
