using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of an allergy service.
    /// </summary>
    public interface IAllergienService
    {
        /// <summary>
        /// Returns all allergies.
        /// </summary>
        /// <returns>The data.</returns>
        Task<List<AllergieEditDto>> GetAllergienAsync();

        /// <summary>
        /// Returns an allergy.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The data.</returns>
        Task<AllergieEditDto> GetAllergieAsync(Guid id);

        /// <summary>
        /// Saves an allergy.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SaveAllergieAsync(AllergieEditDto item);

        /// <summary>
        /// Deletes an allergy.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> DeleteAllergieAsync(Guid id);
    }
}
