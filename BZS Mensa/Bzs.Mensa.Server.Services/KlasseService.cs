using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a class service.
    /// </summary>
    public sealed class KlasseService : ServiceBase, IKlasseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KlasseService" /> class.
        /// </summary>
        /// <param name="configuration"></param>
        public KlasseService(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        public async Task<List<KlasseEditDto>> GetKlassenAsync()
        {
            List<KlasseEditDto> data = new List<KlasseEditDto>();
            using (var ctx = this.CreateContext())
            {
                data = await ctx.Klasses.Where(f => !f.Geloescht).Select(f => new KlasseEditDto(f.Id, f.Bezeichnung, f.Schicht1, f.Schicht2)).ToListAsync().ConfigureAwait(true);
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<KlasseEditDto> GetKlasseAsync(Guid id)
        {
            KlasseEditDto data = null;
            using (var ctx = this.CreateContext())
            {
                Klasse entity = await ctx.Klasses.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity != null)
                {
                    if (!entity.Geloescht)
                    {
                        data = new KlasseEditDto(entity.Id, entity.Bezeichnung, entity.Schicht1, entity.Schicht2);
                    }
                }
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveKlasseAsync(KlasseEditDto item)
        {
            if (item != null)
            {
                using (BzsMensaContext ctx = this.CreateContext())
                {
                    Klasse entity = await ctx.Klasses.FirstOrDefaultAsync(f => f.Id == item.Id).ConfigureAwait(true);
                    if (entity == null)
                    {
                        entity = new Klasse();
                        entity.Id = item.Id;
                        entity.Bezeichnung = string.Empty;
                        entity.Schicht1 = false;
                        entity.Schicht2 = false;
                        entity.Geloescht = false;
                        ctx.Klasses.Add(entity);
                    }

                    if (entity.Geloescht)
                    {
                        return new ResultDto(@"Klasse ist bereits gelöscht.");
                    }

                    entity.Bezeichnung = item.Bezeichnung;
                    entity.Schicht1 = item.Schicht1;
                    entity.Schicht2 = item.Schicht2;

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
        public async Task<ResultDto> DeleteKlasseAsync(Guid id)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Klasse entity = await ctx.Klasses.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity == null)
                {
                    return new ResultDto("Klasse konnte nicht gefunden werden.");
                }

                if (entity.Geloescht)
                {
                    return new ResultDto(true);
                }

                // TODO: Prüfen: Wenn die Klasse verwendet wird, darf sie nicht gelöscht werden.

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
    }
}
