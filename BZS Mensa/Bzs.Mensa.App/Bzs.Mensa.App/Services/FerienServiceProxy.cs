using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bzs.Mensa.Server.Services;
using Bzs.Mensa.Shared.DataTransferObjects;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a vacation service proxy.
    /// </summary>
    public sealed class FerienServiceProxy : ServiceProxyBase, IFerienService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FerienServiceProxy" /> class.
        /// </summary>
        public FerienServiceProxy()
        {
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteFerienAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<List<FerienEditDto>> GetFerienAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<FerienEditDto> GetFerienAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ResultDto> SaveFerienAsync(FerienEditDto item)
        {
            throw new NotImplementedException();
        }
    }
}
