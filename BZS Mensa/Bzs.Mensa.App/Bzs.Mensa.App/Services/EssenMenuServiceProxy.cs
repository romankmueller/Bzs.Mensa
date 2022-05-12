using System;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a meal menu service proxy.
    /// </summary>
    public sealed class EssenMenuServiceProxy : ServiceProxyBase, IEssenMenuService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenMenuServiceProxy" /> class.
        /// </summary>
        public EssenMenuServiceProxy()
        {
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteEssenMenuAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<EssenMenuEditDto> EssenMenuAsync(EssenMenuRequestDto requestItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<EssenMenuEditDto> EssenMenuAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ResultDto> SaveEssenMenuAsync(EssenMenuEditDto item)
        {
            throw new NotImplementedException();
        }
    }
}
