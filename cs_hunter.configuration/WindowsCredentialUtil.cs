using CredentialManagement;

namespace cs_hunter.configuration
{
    internal class WindowsCredentialUtil
    {
        private Credential _credential;

        public string ClientId
        {
            get
            {
                if (_credential.Load())
                    return _credential.Username;
                else
                    return "";
            } 
        }

        public string ClientSecret
        {
            get
            {
                if (_credential.Load())
                    return _credential.Password;
                else
                    return "";
            }
        }
        
        public WindowsCredentialUtil(string wcmName)
        {
            _credential = new Credential { Target = wcmName };
        }
    }
}