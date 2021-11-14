using System;

namespace crowdstrike.library.Helpers
{
    public class CrowdstrikeAttribute : Attribute
    {
        public bool ForceLowerCase { get; set; }
        public bool SupportField { get; set; }
    }
}