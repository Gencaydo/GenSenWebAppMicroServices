using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venhancer.Crowd.Configuration
{
    public class APIOptions
    {
        public string? CrowdIdentityAPIBaseUrl { get; set; }
        public string? CrowdIdentityCreateTokenUrl { get; set; }
        public string? CrowdIdentityCreateTokenClientId { get; set; }
        public string? CrowdIdentityCreateTokenClientSecret { get; set; }
        public string? CrowdIdentityCreateTokenClientGrantType { get; set; }
    }
}
