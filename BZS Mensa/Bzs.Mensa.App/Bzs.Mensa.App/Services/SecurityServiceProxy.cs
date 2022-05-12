using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a security service proxy.
    /// </summary>
    public sealed class SecurityServiceProxy : ServiceProxyBase, ISecurityService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityServiceProxy" /> class.
        /// </summary>
        public SecurityServiceProxy()
        {
        }

        /// <inheritdoc />
        public Task<LoginResultDto> LoginAsync(string userName, string password)
        {
            return Task.Run(() =>
            {
                LoginResultDto data = new LoginResultDto(@"Token");
                return data;
            });
        }
    }
}
