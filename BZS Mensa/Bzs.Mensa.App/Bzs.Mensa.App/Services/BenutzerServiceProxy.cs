using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a user service proxy.
    /// </summary>
    public sealed class BenutzerServiceProxy : ServiceProxyBase, IBenutzerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerServiceProxy" /> class.
        /// </summary>
        public BenutzerServiceProxy()
        {
        }

        /// <inheritdoc />
        public Task<ResultDto> AnmeldenAsync(BenutzerAnmeldungDto daten)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task CreateAdministratorAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteBenutzerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<List<BenutzerEditDto>> GetBenutzerAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<BenutzerEditDto> GetBenutzerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ResultDto> SaveBenutzerAsync(BenutzerEditDto item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ResultDto> SetBenutzerPasswortAsync(BenutzerPasswortDto item)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDto> SetChangeBenutzerPasswort(BenutzerNeuesPasswortDto item)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDto> SendTokenEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
