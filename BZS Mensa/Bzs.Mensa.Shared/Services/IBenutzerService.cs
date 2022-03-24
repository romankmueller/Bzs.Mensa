using Bzs.Mensa.Shared.DataTransferObjects;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of a user service.
    /// </summary>
    public interface IBenutzerService
    {
        /// <summary>
        /// Returns the login result.
        /// </summary>
        /// <param name="daten">The login data.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> AnmeldenAsync(BenutzerAnmeldungDto daten);

        /// <summary>
        /// Returns the user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>The data.</returns>
        Task<List<BenutzerEditDto>> GetBenutzerAsync();

        /// <summary>
        /// Returns the user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>The data.</returns>
        Task<BenutzerEditDto> GetBenutzerAsync(Guid id);

        /// <summary>
        /// Saves a user.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SaveBenutzerAsync(BenutzerEditDto item);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> DeleteBenutzerAsync(Guid id);

        /// <summary>
        /// Sets the user password.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SetBenutzerPasswortAsync(BenutzerPasswortDto item);

        /// <summary>
        /// Creates the administrator.
        /// </summary>
        void CreateAdministrator();
    }
}
