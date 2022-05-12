using Bzs.Mensa.Shared.DataTransferObjects;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of a security service.
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <returns>The result.</returns>
        Task<LoginResultDto> LoginAsync(string userName, string password);
    }
}
