using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents an allergy service proxy.
    /// </summary>
    public sealed class AllergieServiceProxy : ServiceProxyBase, IAllergienService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllergieServiceProxy" /> class.
        /// </summary>
        public AllergieServiceProxy()
        {
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteAllergieAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<AllergieEditDto> GetAllergieAsync(Guid id)
        {
            return Task.Run(() =>
            {
                AllergieEditDto data = new AllergieEditDto();
                data.Id = id;
                data.Bezeichnung = @"Allergie";
                return data;
            });
        }

        /// <inheritdoc />
        public Task<List<AllergieEditDto>> GetAllergienAsync()
        {
            return Task.Run(() =>
            {
                List<AllergieEditDto> data = new List<AllergieEditDto>();
                data.Add(new AllergieEditDto(Guid.NewGuid(), "Gluten"));
                data.Add(new AllergieEditDto(Guid.NewGuid(), "Laktose"));
                return data;
            });
        }

        /// <inheritdoc />
        public Task<ResultDto> SaveAllergieAsync(AllergieEditDto item)
        {
            return Task.Run(() =>
            {
                return new ResultDto(true);
            });
        }
    }
}
