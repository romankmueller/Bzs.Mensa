using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents an allergy service.
    /// </summary>
    public class AllergienService : ServiceBase, IAllergienService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllergienService" /> class.
        /// </summary>
        /// <param name="configuration"></param>
        public AllergienService(IConfiguration configuration)
        : base(configuration)
        {
        }

        [Obsolete]
        public List<AllergieEditDto> AllergienListe()
        {
            List<AllergieEditDto> list = new List<AllergieEditDto>();
            using (BzsMensaContext ctx = this.CreateContext())
            {
                foreach (Allergie entity in ctx.Allergies.Where(f => !f.Geloescht))
                {
                    AllergieEditDto item = new AllergieEditDto();
                    item.Id = entity.Id;
                    item.Bezeichnung = entity.Bezeichnung;
                    list.Add(item);
                }

            }
            return list;
        }

        /// <inheritdoc />
        public async Task<List<AllergieEditDto>> GetAllergienAsync()
        {
            List<AllergieEditDto> list = new List<AllergieEditDto>();
            using (BzsMensaContext ctx = this.CreateContext())
            {
                list = await ctx.Allergies.Where(f => !f.Geloescht).Select(f => new AllergieEditDto(f.Id, f.Bezeichnung)).ToListAsync().ConfigureAwait(true);
            }

            return list;
        }

        /// <inheritdoc />
        public async Task<AllergieEditDto> GetAllergieAsync(Guid id)
        {
            AllergieEditDto? data = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Allergie? entity = await ctx.Allergies.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity != null)
                {
                    if (!entity.Geloescht)
                    {
                        data = new AllergieEditDto(entity.Id, entity.Bezeichnung);
                    }
                }
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveAllergieAsync(AllergieEditDto item)
        {
            if (item != null)
            {
                using (BzsMensaContext ctx = this.CreateContext())
                {
                    Allergie? entity = await ctx.Allergies.FirstOrDefaultAsync(f => f.Id == item.Id).ConfigureAwait(true);
                    if (entity == null)
                    {
                        entity = new Allergie();
                        entity.Id = item.Id;
                        entity.Bezeichnung = string.Empty;
                        entity.Geloescht = false;
                        ctx.Allergies.Add(entity);
                    }

                    if (entity.Geloescht)
                    {
                        return new ResultDto(@"Allergie ist bereits gelöscht.");
                    }

                    entity.Bezeichnung = item.Bezeichnung;

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
        public async Task<ResultDto> DeleteAllergieAsync(Guid id)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Allergie? entity = await ctx.Allergies.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity == null)
                {
                    return new ResultDto("Allergie konnte nicht gefunden werden.");
                }

                if (entity.Geloescht)
                {
                    return new ResultDto(true);
                }

                bool allergieVorhanden = ctx.BenutzerAllergies.Any(f => f.AllergieId == id);
                if (!allergieVorhanden)
                {
                    entity.Geloescht = true;
                }

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
    }
}
