using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class GetPartnerWorkFilterInfoRsp
    {
        public class SourceTypeDto
        {
            public          int    SourceTypeId    { get; set; }
            public required string SourceTypeName  { get; set; }
        }
        public class PartnerDto
        {
            public          int                 PartnerId   { get; set; }
            public required string              PartnerName { get; set; }
            public required List<SourceTypeDto> SourceTypes { get; set; }
        }
        
        public required List<PartnerDto> Partners { get; set; }
        public          int              MinYear  { get; set; }
        public          int              MaxYear  { get; set; }
    }
}
