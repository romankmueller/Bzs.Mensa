using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a vacation service.
    /// </summary>
    public sealed class FeiertagService : ServiceBase, IFeiertagService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeiertagService" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public FeiertagService(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        public async Task<List<FeiertagEditDto>> GetFeiertageAsync()
        {
            List<FeiertagEditDto> data = new List<FeiertagEditDto>();
            using (BzsMensaContext ctx = this.CreateContext())
            {
                data = await ctx.Feiertags.Where(f => !f.Geloescht).Select(f => new FeiertagEditDto(f.Id, f.Bezeichnung, f.Datum)).ToListAsync().ConfigureAwait(true);
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<FeiertagEditDto?> GetFeiertagAsync(Guid id)
        {
            FeiertagEditDto? data = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Feiertag? entity = await ctx.Feiertags.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity != null)
                {
                    if (!entity.Geloescht)
                    {
                        data = new FeiertagEditDto(entity.Id, entity.Bezeichnung, entity.Datum);
                    }
                }
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveFeiertagAsync(FeiertagEditDto item)
        {
            if (item != null)
            {
                using (BzsMensaContext ctx = this.CreateContext())
                {
                    Feiertag? entity = await ctx.Feiertags.FirstOrDefaultAsync(f => f.Id == item.Id).ConfigureAwait(true);
                    if (entity == null)
                    {
                        entity = new Feiertag();
                        entity.Id = item.Id;
                        entity.Bezeichnung = string.Empty;
                        entity.Datum = DateTime.Today;
                        entity.Geloescht = false;
                        ctx.Feiertags.Add(entity);
                    }

                    if (entity.Geloescht)
                    {
                        return new ResultDto(@"Feiertag ist bereits gelöscht.");
                    }

                    entity.Bezeichnung = item.Bezeichnung;
                    entity.Datum = item.Datum;

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
        public async Task<ResultDto> DeleteFeiertagAsync(Guid id)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Feiertag? entity = await ctx.Feiertags.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity == null)
                {
                    return new ResultDto("Feiertag konnte nicht gefunden werden.");
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
    }
}
