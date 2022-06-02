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
        public async Task<KlasseEditDto> GetKlasseAsync(Guid id)
        {

            return await this.GetAsync<KlasseEditDto>("klasse/item/" + id).ConfigureAwait(true);
            /*return Task.Run(() =>
            {
                KlasseEditDto data = new KlasseEditDto();
                data.Id = id;
                data.Bezeichnung = @"Klasse";
                data.Schicht1 = false;
                data.Schicht2 = true;
                return data;
            });*/
        }

        /// <inheritdoc />
        public async Task<List<KlasseEditDto>> GetKlassenAsync()
        {
            /*return Task.Run(() =>
            {
                List<KlasseEditDto> data = new List<KlasseEditDto>();
                data.Add(new KlasseEditDto(Guid.NewGuid(), @"F21"));
                data.Add(new KlasseEditDto(Guid.NewGuid(), @"H21"));
                return data;
            });*/
            return await this.GetListAsync<KlasseEditDto>("klasse").ConfigureAwait(true);
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveKlasseAsync(KlasseEditDto item)
        {
            /*return Task.Run(() =>
            {
                return new ResultDto(true);
            });*/
            return await this.PostAsync<KlasseEditDto, ResultDto>("klasse/item",item).ConfigureAwait(true);
        }

        /// <inheritdoc />
        public async Task<ResultDto> DeleteKlasseAsync(Guid id)
        {
            /*return Task.Run(() =>
            {
                return new ResultDto(true);
            });*/
            return await this.DeleteAsync<ResultDto>("klasse/item/" + id).ConfigureAwait(true);
        }
    }
}
