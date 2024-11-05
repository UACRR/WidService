using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class UserTask
    {
        [Key]                                 public          int                Id                  { get; set; }
        [Column(TypeName = "nvarchar(266)")]  public required string             Title               { get; set; }
        [Column(TypeName = "int")]            public required int                UserTaskTypeId      { get; set; }
        [Column(TypeName = "int")]            public required UserTaskType       UserTaskType        { get; set; }
        [Column(TypeName = "int")]            public required int                PartnerWorkSourceId { get; set; }
        [Column(TypeName = "int")]            public required PartnerWorkSource  PartnerWorkSource   { get; set; }
        [Column(TypeName = "int")]            public required int                AssignedUserId      { get; set; }
        [Column(TypeName = "int")]            public required User               AssignedUser        { get; set; }
        [Column(TypeName = "int")]            public required int                PartnerWorksRange   { get; set; }
        [Column(TypeName = "datetime2")]      public required DateTime           CreatedAt           { get; set; }
        [Column(TypeName = "datetime2")]      public required DateTime           UpdatedAt           { get; set; }

        public required ICollection<UserTaskItem> UserTaskItems { get; set; }
    }
}
