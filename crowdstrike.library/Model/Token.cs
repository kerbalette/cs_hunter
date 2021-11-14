using System;
using crowdstrike.library.Helpers;

namespace crowdstrike.library.Model
{
    public class Token
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        
        [CrowdstrikeAttribute(SupportField = true)]
        public DateTime ExpiryDate { get; set; }
    }
}