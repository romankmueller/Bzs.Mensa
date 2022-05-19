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
        public async Task<List<BenutzerEditDto>> GetBenutzerAsync()
        {
            List<BenutzerEditDto> data = new List<BenutzerEditDto>();
            using (BzsMensaContext ctx = this.CreateContext())
            {
                List<Benutzer> benutzer = await ctx.Benutzers
                    .Include(f => f.BenutzerAllergies)
                    .ThenInclude(f => f.Allergie)
                    .Where(f => !f.Geloescht)
                    .ToListAsync()
                    .ConfigureAwait(true);
                foreach (Benutzer benutzerEntity in benutzer)
                {
                    BenutzerEditDto dataItem = new BenutzerEditDto();
                    dataItem.Id = benutzerEntity.Id;
                    dataItem.Email = benutzerEntity.Email;
                    dataItem.Benutzername = benutzerEntity.BenutzerName;
                    dataItem.Nachname = benutzerEntity.Nachname;
                    dataItem.Vorname = benutzerEntity.Vorname;
                    dataItem.KlasseId = benutzerEntity.KlasseId;
                    dataItem.Vegetarisch = benutzerEntity.Vegetarisch;
                    dataItem.AllergieItems = benutzerEntity.BenutzerAllergies.Select(f => new BenutzerAllergieEditDto(f.Id, f.AllergieId, f.Allergie.Bezeichnung)).ToList();
                    data.Add(dataItem);
                }
            }

            return data;
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
                    data.Nachname = benutzer.Nachname;
                    data.Vorname = benutzer.Vorname;
                    data.KlasseId = benutzer.KlasseId;
                    data.Vegetarisch = benutzer.Vegetarisch;
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
                        entity.Nachname = string.Empty;
                        entity.Vorname = string.Empty;
                        entity.KlasseId = Guid.Empty;
                        entity.Vegetarisch = false;
                        entity.Geloescht = false;
                        ctx.Benutzers.Add(entity);
                    }

                    if (entity.Geloescht)
                    {
                        return new ResultDto(@"Benutzer ist bereits gelöscht.");
                    }

                    entity.BenutzerName = item.Benutzername;
                    entity.Email = item.Email;
                    entity.Nachname = item.Nachname;
                    entity.Vorname = item.Vorname;
                    entity.KlasseId = item.KlasseId;
                    entity.Vegetarisch = item.Vegetarisch;


                    foreach (BenutzerAllergieEditDto Ba in item.AllergieItems)
                    {
                        BenutzerAllergie entityAllergie = ctx.BenutzerAllergies.FirstOrDefault(f => f.BenutzerId == item.Id && f.AllergieId == Ba.AllergieId);
                        if (entityAllergie == null)
                        {
                            BenutzerAllergie benutzerAllergie = new BenutzerAllergie();
                            benutzerAllergie.Id = new Guid();
                            benutzerAllergie.BenutzerId = item.Id;
                            benutzerAllergie.AllergieId = Ba.AllergieId;
                            ctx.BenutzerAllergies.Add(benutzerAllergie);
                        }
                    }

                    try
                    {
                        await ctx.SaveChangesAsync().ConfigureAwait(true);
                        return new ResultDto(true);
                    }
                    catch (DbUpdateException e)
                    {
                        Log.Debug(e);
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
                    Log.Debug(e);
                    return new ResultDto(e);
                }
            }
        }

        /// <inheritdoc />
        public async Task<ResultDto> SetBenutzerPasswortAsync(BenutzerPasswortDto item)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Benutzer entity = await ctx.Benutzers.FirstOrDefaultAsync(f => f.Id == item.Id).ConfigureAwait(true);
                if (entity == null)
                {
                    return new ResultDto("Benutzer konnte nicht gefunden werden.");
                }

                if (entity.Geloescht)
                {
                    return new ResultDto("Benutzer wurde bereits gelöscht.");
                }

                entity.Passwort = item.Passwort;

                try
                {
                    await ctx.SaveChangesAsync().ConfigureAwait(true);
                    return new ResultDto(true);
                }
                catch (DbUpdateException e)
                {
                    Log.Debug(e);
                    return new ResultDto(e);
                }
            }
        }

        /// <inheritdoc />
        public async Task CreateAdministratorAsync()
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Klasse KlasseEntity = ctx.Klasses.FirstOrDefault(f => f.Id == Guid.Empty);
                if (KlasseEntity == null)
                {
                    KlasseEntity = new Klasse();
                    KlasseEntity.Id = Guid.Empty;
                    KlasseEntity.Schicht1 = false;
                    KlasseEntity.Schicht2 = false;
                    KlasseEntity.Bezeichnung = "Admins";
                    KlasseEntity.Geloescht = false;
                    ctx.Klasses.Add(KlasseEntity);
                }
                else
                {
                    KlasseEntity.Geloescht = false;
                }

                Benutzer entity = ctx.Benutzers.FirstOrDefault(f => f.BenutzerName == "admin");
                if (entity == null)
                {
                    entity = new Benutzer();
                    entity.Id = new Guid();
                    entity.BenutzerName = "admin";
                    entity.Email = "admin@admin.ch";
                    entity.Passwort = "admin123";
                    entity.Nachname = string.Empty;
                    entity.Vorname = @"Administrator";
                    entity.KlasseId = Guid.Empty;
                    entity.Vegetarisch = false;
                    entity.Geloescht = false;
                    ctx.Benutzers.Add(entity);
                }
                else
                {
                    if (entity.Geloescht)
                    {
                        entity.Geloescht = false;
                    }
                }

                try
                {
                    await ctx.SaveChangesAsync().ConfigureAwait(true);
                }
                catch (DbUpdateException e)
                {
                    Log.Debug(e);
                }
            }
        }

        /// <inheritdoc />
        public Task<ResultDto> SendTokenEmail(BenutzerPasswortVergessenDto item)
        {
            return Task.Run(() =>
            {
                return new ResultDto(false);
            });
        }
    }
}
