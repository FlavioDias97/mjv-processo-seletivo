using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace MarketplaceAPI.Security.Configuration
{
    public class SigningConfigurations
    {
        public SecurityKey key{ get;}
        public SigningCredentials SigningCredentials { get; }
        public SecurityKey Key { get; internal set; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature);
        }

    }
}
