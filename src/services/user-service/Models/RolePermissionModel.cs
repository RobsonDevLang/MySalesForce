using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    [Table("role_permission")]
    public class RolePermissionModel
    {
    public int RoleId { get; set; }
    public RoleModel Role { get; set; } = null!;

    public int PermissionId { get; set; }
    public PermissionModel Permission { get; set; } = null!;
    }
}