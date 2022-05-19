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
        public Task<KlasseEditDto> GetKlasseAsync(Guid id)
        {
            return Task.Run(() =>
            {
                KlasseEditDto data = new KlasseEditDto();
                data.Id = id;
                data.Bezeichnung = @"Klasse";
                data.Schicht1 = false;
                data.Schicht2 = true;
                return data;
            });
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
            return Task.Run(() =>
            {
                return new ResultDto(true);
            });
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteKlasseAsync(Guid id)
        {
            return Task.Run(() =>
            {
                return new ResultDto(true);
            });
        }
    }
}
