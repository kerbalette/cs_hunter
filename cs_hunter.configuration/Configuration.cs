using System;
using System.Configuration;
using System.Reflection;
using crowdstrike.library.Model;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace cs_hunter.configuration
{
    public class Configuration
    {
        private KeyValueConfigurationCollection _settings;
        private oAuth2 _oAuth2;

        public oAuth2 Credentials
        {
            get { return _oAuth2; }
        }

        public string Proxy
        {
            get
            {
                if (_settings["Proxy"] != null)
                    return _settings["Proxy"].Value;
                else
                    return "";
            }
        }
        
        public string BaseUrl {
            get
            {
                if (_settings["base_url"] != null)
                    return _settings["base_url"].Value;
                else
                    return "";
            }
        }
        public Configuration()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _oAuth2 = new oAuth2();
            _settings = configFile.AppSettings.Settings;

            if (_settings["CredentialProvider"] != null)
            {
                if (_settings["CredentialProvider"].Value == "WindowsCredentialManager")
                {
                    WindowsCredentialUtil windowsCredentialUtil =
                        new WindowsCredentialUtil("CrowdstrikeLab/AccessToken");

                    _oAuth2.client_id = windowsCredentialUtil.ClientId;
                    _oAuth2.client_secret = windowsCredentialUtil.ClientSecret;
                }
            }
            else
            {
                if (_settings["client_id"] != null)
                    _oAuth2.client_id = _settings["client_id"].Value;
            
                if (_settings["secret_id"] != null)
                    _oAuth2.client_secret = _settings["secret_id"].Value;
            }
        }
    }
}