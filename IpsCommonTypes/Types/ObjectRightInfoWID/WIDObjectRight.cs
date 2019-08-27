using System;

namespace IpsCommonTypes.Types.ObjectRightInfoWID
{
    public class WIDObjectRight
    {
        public int WIC { get; set; }
        public string ISWC { get; set; }
        public string Name { get; set; }
        public string SpecName { get; set; }
        public string GenreName { get; set; }
        public TimeSpan? Duration { get; set; }
        public decimal? RateTotalMEC { get; set; }
        public decimal? RateTotalPER { get; set; }
    }
}
