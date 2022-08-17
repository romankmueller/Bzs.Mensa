using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Server.Services.Security;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a security service.
    /// </summary>
    public sealed class SecurityService : ServiceBase, ISecurityService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityService" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SecurityService(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        public async Task<LoginResultDto> LoginAsync(string userName, string password)
        {
            LoginResultDto result = new LoginResultDto();
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Benutzer? entity = await ctx.Benutzers.FirstOrDefaultAsync(f => f.BenutzerName == userName && !f.Geloescht).ConfigureAwait(true);
                if (entity != null)
                {
                    if (entity.Passwort == password)
                    {
                        result.Succsessful = true;
                    }
                    ////if (PasswordHelper.AreEqual(password, entity.Passwort, entity.Salt))
                    ////{
                    ////    result = new LoginResultDto();
                    ////}
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the authenticated user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <returns>The authentication user.</returns>
        public AuthenticationUser GetLoginUser(string userName, string password)
        {
            AuthenticationUser? user = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Benutzer? entity = ctx.Benutzers.FirstOrDefault(f => f.BenutzerName == userName && !f.Geloescht);
                if (entity != null)
                {
                    ////if (PasswordHelper.AreEqual(password, entity.Passwort, entity.Salt))
                    ////{
                    ////    user = new AuthenticationUser(entity.Id, entity.BenutzerName);
                    ////}
                    if (entity.Passwort == password)
                    {
                        user = new AuthenticationUser(entity.Id, entity.BenutzerName);
                    }
                }
            }

            return user;
        }
    }
}
