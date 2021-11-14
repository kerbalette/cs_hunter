using crowdstrike.library.Model;
using crowdstrike.library.Processor;
using cs_hunter.configuration;
using Xunit;

namespace cs_hunter.tests
{
    public class tests_crowdstrikeprocessor
    {
        [Fact]
        public void ValidAuthenticate_ReturnsValidToken()
        {
            Configuration config = new Configuration();
            oAuth2 oAuth = config.Credentials;
            CrowdstrikeProcessor crowdstrikeProcessor = new CrowdstrikeProcessor(config.BaseUrl, config.Proxy);
            Token token = crowdstrikeProcessor.Authenticate(oAuth.client_id, oAuth.client_secret).GetAwaiter().GetResult();
            Assert.True(token.access_token.Length > 0, "token is not valid");
        }
    }
}