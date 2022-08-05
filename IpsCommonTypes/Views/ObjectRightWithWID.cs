namespace IpsCommonTypes.Views
{
    /// <summary>
    /// Універсальна view для об'єктів права з локальної або WID бази
    /// </summary>
    public class ObjectRightWithWID
    {
        public int? ObjId { get; set; }
        public string InnerCode { get; set; }
        public string Iswc { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }
        public double? RateTotal { get; set; }
        public double? RateTotalMEC { get; set; }
        public double? RateTotalPER { get; set; }
        public string Author { get; set; }
        public string Performer { get; set; }
        public int? Wic { get; set; }
    }
}
