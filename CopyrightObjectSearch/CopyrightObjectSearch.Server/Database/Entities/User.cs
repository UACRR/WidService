
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CopyrightObjectSearch.Server
{
    public class User
    {
        [Key]                                public          int      Id           { get; set; }
        [Column(TypeName = "nvarchar(256)")] public required string   Name         { get; set; }
        [Column(TypeName = "nvarchar(256)")] public required string   Login        { get; set; }
        [Column(TypeName = "char(256)")]     public required byte[]   PasswordHash { get; set; }
        [Column(TypeName = "bit")]           public          bool     IsPwdDefault { get; set; }
        [Column(TypeName = "bit")]           public          bool     IsBlocked    { get; set; }
        [Column(TypeName = "bit")]           public          bool     IsSuperUser  { get; set; }
        [Column(TypeName = "datetime2")]     public          DateTime CreatedAt    { get; set; }
        [Column(TypeName = "datetime2")]     public          DateTime UpdatedAt    { get; set; }

        public  required ICollection<UserRole> UserRoles { get; set; }
    }
}
