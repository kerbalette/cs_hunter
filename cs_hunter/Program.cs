using System;
using System.Net.Http;
using System.Reflection;
using System.Security.Principal;
using crowdstrike.library.Helpers;
using crowdstrike.library.Model;
using crowdstrike.library.Processor;
using cs_hunter.configuration;

namespace cs_hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            
            CrowdstrikeProcessor processor = new CrowdstrikeProcessor(config.BaseUrl, config.Proxy);
            Token token = processor.Authenticate(config.Credentials.client_id, config.Credentials.client_secret).GetAwaiter().GetResult();
            Console.Write(token.access_token);

            /*Token token = new Token();
            token.access_token = "asdasdasd";
            token.ExpiryDate = DateTime.Now + TimeSpan.FromMinutes(60);

            foreach (PropertyInfo propertyInfo in token.GetType().GetProperties())
            {
                string propertyName = propertyInfo.Name;
                Console.WriteLine(propertyName);
                object[] attribute = propertyInfo.GetCustomAttributes(typeof(CrowdstrikeAttribute), true);
                if (attribute.Length > 0)
                {
                    CrowdstrikeAttribute crowdstrikeAttribute = (CrowdstrikeAttribute)attribute[0];
                    bool propertyValue = crowdstrikeAttribute.SupportField;
                }
            }*/

        }
    }
}