using Bzs.Mensa.Shared.DataTransferObjects;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of an meal menu.
    /// </summary>
    public interface IEssenMenuService
    {
        /// <summary>
        /// Returns the meal.
        /// </summary>
        /// <param name="requestItem">The request item.</param>
        /// <returns>The data.</returns>
        Task<EssenMenuEditDto> EssenMenuAsync(EssenMenuRequestDto requestItem);

        /// <summary>
        /// Returns the meal.
        /// </summary>
        /// <param name="id">The identifier of the item.</param>
        /// <returns>The data.</returns>
        Task<EssenMenuEditDto> EssenMenuAsync(Guid id);

        /// <summary>
        /// Saves a meal menu.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> SaveEssenMenuAsync(EssenMenuEditDto item);

        /// <summary>
        /// Deletes a meal menu.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        /// <returns>The result.</returns>
        Task<ResultDto> DeleteEssenMenuAsync(Guid id);
    }
}
