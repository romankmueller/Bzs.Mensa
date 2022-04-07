using Bzs.Mensa.Shared.DataTransferObjects;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of a meal standard service.
    /// </summary>
    public interface IEssenStandardService
    {
        /// <summary>
        /// Returns the meal default.
        /// </summary>
        /// <param name="benutzerId">The user identifier.</param>
        /// <returns>The data.</returns>
        Task<EssenStandardEditDto> EssenStandardByBenutzerAsync(Guid benutzerId);

        /// <summary>
        /// Returns the meal default.
        /// </summary>
        /// <param name="id">The identifier of the item.</param>
        /// <returns>The data.</returns>
        Task<EssenStandardEditDto> EssenStandardAsync(Guid id);

        /// <summary>
        /// Saves a meal default.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SaveEssenStandardAsync(EssenStandardEditDto item);
    }
}
