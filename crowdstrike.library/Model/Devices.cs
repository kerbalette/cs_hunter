using System;

namespace crowdstrike.library.Model
{
    public class Devices
    {
        public string hostname { get; set; }
        public string aid { get; set; }
        public DateTime agent_local_time { get; set; }
        public string agent_version { get; set; }
        public string bios_manufacturer { get; set; }
        public string bios_version { get; set; }
        public string build_number { get; set; }
        public string external_ip { get; set; }
        public string mac_address { get; set; }
        public DateTime first_seen { get; set; } 
        public DateTime last_seen { get; set; }
        public string local_ip { get; set; }
        public string machine_domain { get; set; }
        public string os_version { get; set; } 
        public string os_build { get; set; }
        public string platform_name { get; set; }
        public string product_type_desc { get; set; }
        public string serial_number { get; set; }
        public string system_manufacturer { get; set; }
        public string system_product_name { get; set; }
        
    }
}