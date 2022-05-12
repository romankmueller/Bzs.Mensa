using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a login result data transfer object.
    /// </summary>
    [JsonObject]
    public sealed class LoginResultDto : ResultDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResultDto" /> class.
        /// </summary>
        public LoginResultDto()
        {
            this.Token = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResultDto" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        public LoginResultDto(string token)
        {
            this.Succsessful = true;
            this.Token = token;
        }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        [JsonProperty(@"token")]
        public string Token { get; set; }
    }
}
