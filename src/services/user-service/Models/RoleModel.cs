using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Models
{
    [Table("role")]
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}