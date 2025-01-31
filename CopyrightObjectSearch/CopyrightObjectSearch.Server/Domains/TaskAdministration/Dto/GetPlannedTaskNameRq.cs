using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class GetPlannedTaskNameRq
    {
        public int  PartnerWorkSourceId { get; set; }
    }
}
