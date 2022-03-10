using Newtonsoft.Json;

namespace Bzs.Mensa.Shared.DataTransferObjects
{
    /// <summary>
    /// Represents a result data transfer object.
    /// </summary>
    [JsonObject]
    public class ResultDto : DtoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultDto" /> class.
        /// </summary>
        public ResultDto()
        {
            this.Succsessful = false;
            this.ErrorMessage = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultDto" /> class.
        /// </summary>
        /// <param name="successful">The success flag.</param>
        public ResultDto(bool successful)
        {
            this.Succsessful = successful;
            this.ErrorMessage = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultDto" /> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public ResultDto(string errorMessage)
        {
            this.Succsessful = false;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the result is successful.
        /// </summary>
        [JsonProperty("@successful")]
        public bool Succsessful { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty(@"errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
