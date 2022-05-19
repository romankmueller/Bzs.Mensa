using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a user password forgotten data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class BenutzerPasswortVergessenDto : DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerPasswortVergessenDto" /> class.
        /// </summary>
        public BenutzerPasswortVergessenDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerPasswortVergessenDto" /> class.
        /// </summary>
        /// <param name="email">The email address.</param>
        public BenutzerPasswortVergessenDto(string email)
        {
            this.Email = email;
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [JsonProperty(@"email")]
        public string Email { get; set; }
    }
}
