using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.EntityFrameworkCore;
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

        /// <inheritdoc />
        public async Task<ResultDto> AnmeldenAsync(BenutzerAnmeldungDto daten)
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
                result.Succsessful = await ctx.Benutzers.AnyAsync(f => f.Email == daten.Email && f.Passwort == daten.Passwort).ConfigureAwait(true);
            }

            return result;
        }

        /// <inheritdoc />
        public async Task<BenutzerEditDto> GetBenutzerAsync(Guid id)
        {
            BenutzerEditDto data = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Benutzer benutzer = await ctx.Benutzers
                    .Include(f => f.BenutzerAllergies)
                    .ThenInclude(f => f.Allergie)
                    .FirstOrDefaultAsync(f => f.Id == id && !f.Geloescht)
                    .ConfigureAwait(true);
                if (benutzer != null)
                {
                    data = new BenutzerEditDto();
                    data.Id = benutzer.Id;
                    data.Email = benutzer.Email;
                    data.Benutzername = benutzer.BenutzerName;
                    data.KlasseId = benutzer.KlasseId;
                    data.Vegetarisch = benutzer.Veggetarisch;
                    data.AllergieItems = benutzer.BenutzerAllergies.Select(f => new BenutzerAllergieEditDto(f.Id, f.AllergieId, f.Allergie.Bezeichnung)).ToList();
                }
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveBenutzerAsync(BenutzerEditDto item)
        {
            if (item != null)
            {
                using (BzsMensaContext ctx = this.CreateContext())
                {
                    Benutzer entity = await ctx.Benutzers.FirstOrDefaultAsync(f => f.Id == item.Id).ConfigureAwait(true);
                    if (entity == null)
                    {
                        entity = new Benutzer();
                        entity.Id = item.Id;
                        entity.BenutzerName = string.Empty;
                        entity.Email = string.Empty;
                        entity.KlasseId = Guid.Empty;
                        entity.Veggetarisch = false;
                        entity.Geloescht = false;
                        ctx.Benutzers.Add(entity);
                    }

                    if (entity.Geloescht)
                    {
                        return new ResultDto(@"Benutzer ist bereits gelöscht.");
                    }

                    entity.BenutzerName = item.Benutzername;
                    entity.Email = item.Email;
                    entity.KlasseId = item.KlasseId;
                    entity.Veggetarisch = item.Vegetarisch;

                    // TODO: Allergien aktualisieren.

                    try
                    {
                        await ctx.SaveChangesAsync().ConfigureAwait(true);
                        return new ResultDto(true);
                    }
                    catch (DbUpdateException e)
                    {
                        return new ResultDto(e);
                    }
                }
            }

            return new ResultDto(false);
        }

        /// <inheritdoc />
        public async Task<ResultDto> DeleteBenutzerAsync(Guid id)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Benutzer entity = await ctx.Benutzers.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity == null)
                {
                    return new ResultDto("Benutzer konnte nicht gefunden werden.");
                }

                if (entity.Geloescht)
                {
                    return new ResultDto(true);
                }

                entity.Geloescht = true;

                try
                {
                    await ctx.SaveChangesAsync().ConfigureAwait(true);
                    return new ResultDto(true);
                }
                catch (DbUpdateException e)
                {
                    return new ResultDto(e);
                }
            }
        }

        /// <inheritdoc />
        public void CreateAdministrator()
        {
            // TODO: Administrator erzeugen, wenn dieser noch nicht existiert.
        }
    }
}
