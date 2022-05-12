using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a class service proxy.
    /// </summary>
    public sealed class KlasseServiceProxy : ServiceProxyBase, IKlasseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KlasseServiceProxy" /> class.
        /// </summary>
        public KlasseServiceProxy()
        {
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteKlasseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<KlasseEditDto> GetKlasseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<List<KlasseEditDto>> GetKlassenAsync()
        {
            return Task.Run(() =>
            {
                List<KlasseEditDto> data = new List<KlasseEditDto>();
                data.Add(new KlasseEditDto(Guid.NewGuid(), @"F21"));
                data.Add(new KlasseEditDto(Guid.NewGuid(), @"H21"));
                return data;
            });
        }

        /// <inheritdoc />
        public Task<ResultDto> SaveKlasseAsync(KlasseEditDto item)
        {
            throw new NotImplementedException();
        }
    }
}
