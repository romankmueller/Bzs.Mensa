using Bzs.Mensa.Shared.DataTransferObjects;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of a meal service.
    /// </summary>
    public interface IEssenService
    {
        /// <summary>
        /// Returns the meal.
        /// </summary>
        /// <param name="id">The identifier of the item.</param>
        /// <returns>The data.</returns>
        Task<EssenEditDto> EssenAsync(Guid id);

        /// <summary>
        /// Saves a meal.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SaveEssenAsync(EssenEditDto item);

        /// <summary>
        /// Deletes a meal.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> DeleteEssenAsync(Guid id);
    }
}
