using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a user password data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class BenutzerPasswortDto : ItemDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerPasswortDto" /> class.
        /// </summary>
        public BenutzerPasswortDto()
        {
            this.Passwort = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerPasswortDto" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="passwort">The password.</param>
        public BenutzerPasswortDto(Guid id, string passwort)
            : base(id)
        {
            this.Passwort = passwort;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [JsonProperty(@"passwort")]
        public string Passwort { get; set; }
    }
}
