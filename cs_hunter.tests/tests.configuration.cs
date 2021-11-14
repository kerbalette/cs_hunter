using System;
using crowdstrike.library.Model;
using cs_hunter.configuration;
using Xunit;

namespace cs_hunter.tests
{
    
    public class tests_configuration
    {
        [Fact]
        public void LoadConfiguration_ReturnsClientID()
        {
            var config = new cs_hunter.configuration.Configuration();
            var auth = config.Credentials;
            Assert.True(auth.client_id.Length > 1, "client_id has a value");
        }
        [Fact]
        public void LoadConfiguration_ReturnsSecretID()
        {
            var config = new cs_hunter.configuration.Configuration();
            var auth = config.Credentials;
            Assert.True(auth.client_secret.Length > 1, "client_secret has a value");
        }
        
    }
}