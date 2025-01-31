using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class GetPartnerWorkSourcesRsp
    {
        public int              PartnerWorkSourceId          { get; set; }
        public required string  Title                        { get; set; }
        public int              PartnerId                    { get; set; }
        public required string  PartnerName                  { get; set; }
        public int              SourceId                     { get; set; }
        public int              SourceTypeId                 { get; set; }
        public required string  SourceTypeName               { get; set; }
        public int              Year                         { get; set; }
        public int              Month                        { get; set; }
        public int              Quarter                       { get; set; }
    }
}
