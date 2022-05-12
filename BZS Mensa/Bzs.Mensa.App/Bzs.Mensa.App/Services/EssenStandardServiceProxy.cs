using System;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a standard meal service proxy.
    /// </summary>
    public sealed class EssenStandardServiceProxy : ServiceProxyBase, IEssenStandardService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenStandardServiceProxy" /> class.
        /// </summary>
        public EssenStandardServiceProxy()
        {
        }

        /// <inheritdoc />
        public Task<EssenStandardEditDto> EssenStandardAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<EssenStandardEditDto> EssenStandardByBenutzerAsync(Guid benutzerId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ResultDto> SaveEssenStandardAsync(EssenStandardEditDto item)
        {
            throw new NotImplementedException();
        }
    }
}
