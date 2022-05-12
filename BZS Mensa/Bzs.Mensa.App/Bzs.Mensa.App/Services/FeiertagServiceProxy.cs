using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a holiday service proxy.
    /// </summary>
    public sealed class FeiertagServiceProxy : ServiceProxyBase, IFeiertagService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeiertagServiceProxy" /> class.
        /// </summary>
        public FeiertagServiceProxy()
        {
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteFeiertagAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<FeiertagEditDto> GetFeiertagAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<List<FeiertagEditDto>> GetFeiertageAsync()
        {
            return Task.Run(() =>
            {
                List<FeiertagEditDto> data = new List<FeiertagEditDto>();
                data.Add(new FeiertagEditDto(Guid.NewGuid(), "Neujahr", new DateTime(2022, 1, 1)));
                data.Add(new FeiertagEditDto(Guid.NewGuid(), "Heilig Abend", new DateTime(2022, 12, 24)));
                data.Add(new FeiertagEditDto(Guid.NewGuid(), "Weihnachten", new DateTime(2022, 12, 25)));
                data.Add(new FeiertagEditDto(Guid.NewGuid(), "Stefanstag", new DateTime(2022, 12, 26)));
                return data;
            });
        }

        /// <inheritdoc />
        public Task<ResultDto> SaveFeiertagAsync(FeiertagEditDto item)
        {
            throw new NotImplementedException();
        }
    }
}
