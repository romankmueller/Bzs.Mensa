using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // TODO: Ersetzen mit Webservice-Aufruf.
            return Task.Run(() =>
            {
                return new ResultDto(true);
            });
        }

        /// <inheritdoc />
        public Task CreateAdministratorAsync()
        {
            // TODO: Ersetzen mit Webservice-Aufruf.
            return Task.Run(() =>
            {
                Debug.WriteLine(@"CreateAdministratorAsync");
            });
        }

        /// <inheritdoc />
        public Task<ResultDto> DeleteBenutzerAsync(Guid id)
        {
            // TODO: Ersetzen mit Webservice-Aufruf.
            return Task.Run(() =>
            {
                return new ResultDto(true);
            });
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
            // TODO: Ersetzen mit Webservice-Aufruf.
            return Task.Run(() =>
            {
                return new ResultDto(true);
            });
        }

        /// <inheritdoc />
        public Task<ResultDto> SetBenutzerPasswortAsync(BenutzerPasswortDto item)
        {
            // TODO: Ersetzen mit Webservice-Aufruf.
            return Task.Run(() =>
            {
                return new ResultDto(true);
            });
        }

        /// <inheritdoc />
        public Task<ResultDto> SetChangeBenutzerPasswort(BenutzerNeuesPasswortDto item)
        {
            // TODO: Ersetzen mit Webservice-Aufruf.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ResultDto> SendTokenEmail(BenutzerPasswortVergessenDto item)
        {
            // TODO: Ersetzen mit Webservice-Aufruf.
            return Task.Run(() =>
            {
                return new ResultDto(true);
            });
        }
    }
}
