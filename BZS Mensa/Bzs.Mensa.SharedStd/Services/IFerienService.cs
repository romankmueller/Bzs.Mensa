using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents an interface of a vacation service.
    /// </summary>
    public interface IFerienService
    {
        /// <summary>
        /// Returns all vacations.
        /// </summary>
        /// <returns>The data.</returns>
        Task<List<FerienEditDto>> GetFerienAsync();

        /// <summary>
        /// Returns a vacation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        Task<FerienEditDto> GetFerienAsync(Guid id);

        /// <summary>
        /// Saves a vacation.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SaveFerienAsync(FerienEditDto item);

        /// <summary>
        /// Deletes a vacation.
        /// </summary>
        /// <param name="id">The class identifier.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> DeleteFerienAsync(Guid id);
    }
}
