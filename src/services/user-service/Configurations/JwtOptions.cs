using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Configurations
{
    public class JwtOptions
    {
        public const string SectionName = "Jwt";

        public string Key { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public int ExpireMinutes { get; set; }
    }
}