using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a meal service.
    /// </summary>
    public sealed class EssenService : ServiceBase, IEssenService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenService" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public EssenService(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteEssenAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<EssenEditDto> EssenAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ResultDto> SaveEssenAsync(EssenEditDto item)
        {
            throw new NotImplementedException();
        }
    }
}
