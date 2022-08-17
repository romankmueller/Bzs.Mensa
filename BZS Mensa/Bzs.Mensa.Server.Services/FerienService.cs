using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a vacation service.
    /// </summary>
    public sealed class FerienService : ServiceBase, IFerienService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FerienService" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public FerienService(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        public async Task<List<FerienEditDto>> GetFerienAsync()
        {
            List<FerienEditDto> data = new List<FerienEditDto>();
            using (var ctx = this.CreateContext())
            {
                data = await ctx.Feriens.Where(f => !f.Geloescht).Select(f => new FerienEditDto(f.Id, f.Bezeichnung, f.VonDatum, f.BisDatum)).ToListAsync().ConfigureAwait(true);
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<FerienEditDto> GetFerienAsync(Guid id)
        {
            FerienEditDto? data = null;
            using (var ctx = this.CreateContext())
            {
                Ferien? entity = await ctx.Feriens.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity != null)
                {
                    if (!entity.Geloescht)
                    {
                        data = new FerienEditDto(entity.Id, entity.Bezeichnung, entity.VonDatum, entity.BisDatum);
                    }
                }
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveFerienAsync(FerienEditDto item)
        {
            if (item != null)
            {
                using (BzsMensaContext ctx = this.CreateContext())
                {
                    Ferien? entity = await ctx.Feriens.FirstOrDefaultAsync(f => f.Id == item.Id).ConfigureAwait(true);
                    if (entity == null)
                    {
                        entity = new Ferien();
                        entity.Id = item.Id;
                        entity.Bezeichnung = string.Empty;
                        entity.VonDatum = DateTime.Today;
                        entity.BisDatum = DateTime.Today;
                        entity.Geloescht = false;
                        ctx.Feriens.Add(entity);
                    }

                    if (entity.Geloescht)
                    {
                        return new ResultDto(@"Ferien ist bereits gelöscht.");
                    }

                    entity.Bezeichnung = item.Bezeichnung;
                    entity.VonDatum = item.VonDatum;
                    entity.BisDatum = item.BisDatum;

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
        public async Task<ResultDto> DeleteFerienAsync(Guid id)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Ferien? entity = await ctx.Feriens.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity == null)
                {
                    return new ResultDto("Ferien konnte nicht gefunden werden.");
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
