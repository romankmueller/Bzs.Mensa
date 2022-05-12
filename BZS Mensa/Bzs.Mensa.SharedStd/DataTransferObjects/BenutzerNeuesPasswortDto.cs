using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a user new passwort data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class BenutzerNeuesPasswortDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerNeuesPasswortDto" /> class.
        /// </summary>
        public BenutzerNeuesPasswortDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerNeuesPasswortDto" /> class.
        /// </summary>
        /// <param name="email">The email address.</param>
        /// <param name="token">The token.</param>
        /// <param name="passwortNeu">The new password.</param>
        public BenutzerNeuesPasswortDto(string email, string token, string passwortNeu)
        {
            this.Email = email;
            this.Token = token;
            this.PasswortNeu = passwortNeu;
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [JsonProperty(@"email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        [JsonProperty(@"token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        [JsonProperty(@"passwortNeu")]
        public string PasswortNeu { get; set; }
    }
}
