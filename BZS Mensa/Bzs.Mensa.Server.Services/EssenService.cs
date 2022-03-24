using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a meal service.
    /// </summary>
    public sealed class EssenService : ServiceBase, IEssenService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenService" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public EssenService(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        public async Task<ResultDto> DeleteEssenAsync(Guid id)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Essen entity = ctx.Essens.FirstOrDefault(f => f.Id == id);
                if (entity == null)
                {
                    return new ResultDto("Essen konnte nicht gefunden werden.");
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
            public EssenEditDto GetEssenAsync(Guid id)
        {
            EssenEditDto essen = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Essen entity = ctx.Essens.FirstOrDefault(f => f.Id == id && !f.Geloescht);
                if (entity != null)
                {
                    essen = new EssenEditDto();
                    essen.Id = entity.Id;
                    essen.BenutzerId = entity.BenutzerId;
                    essen.Datum = entity.Datum;
                    essen.Essen = true;
                }
            }

            return essen;
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveEssenAsync(EssenEditDto item)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Essen entity = ctx.Essens.FirstOrDefault(f => f.Id == item.Id);
                {
                    if (entity == null)
                    {
                        entity = new Essen();
                        entity.Id = item.Id;
                        entity.Geloescht = false;
                        ctx.Essens.Add(entity);
                    }


                    if (entity.Geloescht)
                    {
                        return new ResultDto(false);
                    }

                    entity.Datum = item.Datum;
                    //essen.Essen = item.Essen;
                    entity.BenutzerId = item.BenutzerId;
                    ctx.SaveChanges();
                    return new ResultDto(true);
                }


            }
        }
    }
}
