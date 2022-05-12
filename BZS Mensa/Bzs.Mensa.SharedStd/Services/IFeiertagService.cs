using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of a holiday service.
    /// </summary>
    public interface IFeiertagService
    {
        /// <summary>
        /// Returns all holidays.
        /// </summary>
        /// <returns>The data.</returns>
        Task<List<FeiertagEditDto>> GetFeiertageAsync();

        /// <summary>
        /// Returns a holiday.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        Task<FeiertagEditDto> GetFeiertagAsync(Guid id);

        /// <summary>
        /// Saves a holiday.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SaveFeiertagAsync(FeiertagEditDto item);

        /// <summary>
        /// Deletes a holiday.
        /// </summary>
        /// <param name="id">The class identifier.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> DeleteFeiertagAsync(Guid id);
    }
}
