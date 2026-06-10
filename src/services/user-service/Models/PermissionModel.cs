using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Models
{
    [Table("permission")]
    public class PermissionModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}