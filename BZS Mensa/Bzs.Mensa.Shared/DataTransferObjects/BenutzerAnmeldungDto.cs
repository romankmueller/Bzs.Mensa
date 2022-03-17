using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a user login data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class BenutzerAnmeldungDto : DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerAnmeldungDto" /> class.
        /// </summary>
        public BenutzerAnmeldungDto()
        {
            this.Email = string.Empty;
            this.Passwort = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerAnmeldungDto" /> class.
        /// </summary>
        /// <param name="email">The email address.</param>
        /// <param name="passwort">The password.</param>
        public BenutzerAnmeldungDto(string email, string passwort)
        {
            this.Email = email;
            this.Passwort = passwort;
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [JsonProperty(@"email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [JsonProperty(@"passwort")]
        public string Passwort { get; set; }
    }
}
