using Bzs.Mensa.Shared.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.Services
{
    /// <summary>
    /// Represents an interface of a meal service.
    /// </summary>
    public interface IEssenService
    {
        /// <summary>
        /// Returns the meal overview.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>The data.</returns>
        Task<EssenUebersichtDto> GetEssenUebersichtAsync(Guid id);

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


        Task<ResultDto> DeleteEssenAsync1(EssenEditDto item);

        /// <summary>
        /// Returns the day overview report.
        /// </summary>
        /// <param name="DatumVon">The date from.</param>
        /// <param name="DatumBis">The date to.</param>
        /// <returns>The data.</returns>
        Task<UebersichtTagReportDto> GetUebersichtTagReport(DateTime DatumVon, DateTime DatumBis);
    }
}
