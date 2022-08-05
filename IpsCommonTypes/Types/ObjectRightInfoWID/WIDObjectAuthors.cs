using System;

namespace IpsCommonTypes.Types.ObjectRightInfoWID
{
    public class WIDObjectAuthors
    {
        public int WIC { get; set; }
        public short SeqNr { get; set; }
        public string IPINr { get; set; }
        public string IP_BASE_NR { get; set; }
        public string IntrPtyRol { get; set; }
        public string AuthName { get; set; }
        public decimal? RatePER { get; set; }
        public decimal? RateMEC { get; set; }
    }
}
