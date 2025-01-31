using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class GetPlannedTaskNameRsp
    {
        public required string TaskTitle { get; set; }
    }
}
