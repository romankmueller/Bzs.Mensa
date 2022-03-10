namespace Bzs.Mensa.Server.Services.Security
{
    /// <summary>
    /// Represents an authentication user.
    /// </summary>
    public sealed class AuthenticationUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationUser" /> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userName">The user name.</param>
        public AuthenticationUser(Guid userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName ?? string.Empty;
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Gets the user name.
        /// </summary>
        public string UserName { get; }
    }
}
