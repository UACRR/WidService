
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CopyrightObjectSearch.Server
{
    public class UserRole
    {
        [Key]                                       public int Id { get; set; }
        [Column(Order = 1, TypeName = "int")]       public int UserId { get; set; }
        [Column(Order = 1, TypeName = "int")]       public User? User { get; set; }
        [Column(Order = 2, TypeName = "int")]       public int RoleId { get; set; }
        [Column(Order = 2, TypeName = "int")]       public Role? Role { get; set; }
        [Column(Order = 4, TypeName = "datetime2")] public DateTime CreatedAt { get; set; }
        [Column(Order = 5, TypeName = "datetime2")] public DateTime UpdatedAt { get; set; }
    }
}
