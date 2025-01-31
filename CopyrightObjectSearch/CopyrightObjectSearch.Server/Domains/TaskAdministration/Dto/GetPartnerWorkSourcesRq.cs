using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class GetPartnerWorkSourcesRq
    {
        public int PartnerId    { get; set; }
        public int SourceTypeId { get; set; }
        public int Year         { get; set; }
        public int Month        { get; set; }
        public int Quarter      { get; set; }
    }
}
