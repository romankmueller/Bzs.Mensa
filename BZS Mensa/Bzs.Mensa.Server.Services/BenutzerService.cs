using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a user service.
    /// </summary>
    public class BenutzerService : ServiceBase, IBenutzerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenutzerService" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public BenutzerService(IConfiguration configuration)
            : base(configuration)
        {
        }

        public ResultDto Anmelden(BenutzerAnmeldungDto daten)
        {
            ResultDto result = new ResultDto();
            using (BzsMensaContext ctx = this.CreateContext())
            {
                //Variante 1
                /*Benutzer entity = ctx.Benutzers.FirstOrDefault(f => f.Email == daten.Email && f.Passwort == daten.Passwort);
                if(entity != null)
                {
                    result.Succsessful = true;
                }*/

                //Variante 2
                /*Benutzer entity = ctx.Benutzers.FirstOrDefault(f => f.Email == daten.Email && f.Passwort == daten.Passwort);
                result.Succsessful = entity != null;*/

                //Variante 3
                result.Succsessful = ctx.Benutzers.Any(f => f.Email == daten.Email && f.Passwort == daten.Passwort);
                
            }

            return result;
        }

        public BenutzerDto GetBenutzer(Guid id)
        {
            BenutzerDto benutzerDto = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Benutzer benutzer = ctx.Benutzers.FirstOrDefault(f => f.Id == id && !f.Geloescht);
                if (benutzer != null)
                {
                    benutzerDto = new BenutzerDto();
                    benutzerDto.Id = benutzer.Id;
                    benutzerDto.Email = benutzer.Email;
                    benutzerDto.Benutzername = benutzer.BenutzerName;
                    benutzerDto.KlasseId = benutzer.KlasseId;
                    benutzerDto.Vegetarisch = benutzer.Veggetarisch;
                }
            }

            return benutzerDto;
        }

        /// <summary>
        /// Creates the administrator.
        /// </summary>
        public void CreateAdministrator()
        {
            // TODO: Administrator erzeugen, wenn dieser noch nicht existiert.
        }
    }
}
