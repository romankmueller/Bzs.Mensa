using System;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a meal service proxy.
    /// </summary>
    public sealed class EssenServiceProxy : ServiceProxyBase, IEssenService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenServiceProxy" /> class.
        /// </summary>
        public EssenServiceProxy()
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
