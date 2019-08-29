using System;

namespace ipsFormsDesign.Dictionary
{
    /// <summary>
    /// Опис знайденого об'єкту права
    /// </summary>
    public class RegisterSearchObject
    {
        public int? ObjId { get; set; }
        public int? Wic { get; set; }
        public string InnerCode { get; set; }
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public TimeSpan? Duration { get; set; }
        public decimal? SumAllTogether { get; set; }
    }
}
