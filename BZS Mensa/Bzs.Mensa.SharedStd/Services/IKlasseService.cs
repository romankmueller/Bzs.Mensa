using Bzs.Mensa.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of a class service.
    /// </summary>
    public interface IKlasseService
    {
        /// <summary>
        /// Returns all classes.
        /// </summary>
        /// <returns>The data.</returns>
        Task<List<KlasseEditDto>> GetKlassenAsync();

        /// <summary>
        /// Returns a class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        Task<KlasseEditDto> GetKlasseAsync(Guid id);

        /// <summary>
        /// Saves a class.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SaveKlasseAsync(KlasseEditDto item);

        /// <summary>
        /// Deletes a class.
        /// </summary>
        /// <param name="id">The class identifier.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> DeleteKlasseAsync(Guid id);
    }
}
