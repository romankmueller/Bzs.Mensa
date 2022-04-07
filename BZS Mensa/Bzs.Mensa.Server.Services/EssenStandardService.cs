using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a meal standard service.
    /// </summary>
    public sealed class EssenStandardService : ServiceBase, IEssenStandardService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenStandardService" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public EssenStandardService(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        public async Task<EssenStandardEditDto> EssenStandardByBenutzerAsync(Guid benutzerId)
        {
            EssenStandardEditDto item = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                EssenStandard entity = await ctx.EssenStandards.FirstOrDefaultAsync(f => f.BenutzerId == benutzerId && !f.Geloescht).ConfigureAwait(true);
                if (entity != null)
                {
                    item = new EssenStandardEditDto();
                    item.Id = entity.Id;
                    item.BenutzerId = entity.BenutzerId;
                    item.Montag = entity.Mo;
                    item.Dienstag = entity.Di;
                    item.Mittwoch = entity.Mi;
                    item.Donnerstag = entity.Do;
                    item.Freitag = entity.Fr;
                    item.Samstag = entity.Sa;
                    item.Sonntag = entity.So;
                }
            }

            return item;
        }

        /// <inheritdoc />
        public async Task<EssenStandardEditDto> EssenStandardAsync(Guid id)
        {
            EssenStandardEditDto item = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                EssenStandard entity = await ctx.EssenStandards.FirstOrDefaultAsync(f => f.Id == id && !f.Geloescht).ConfigureAwait(true);
                if (entity != null)
                {
                    item = new EssenStandardEditDto();
                    item.Id = entity.Id;
                    item.BenutzerId = entity.BenutzerId;
                    item.Montag = entity.Mo;
                    item.Dienstag = entity.Di;
                    item.Mittwoch = entity.Mi;
                    item.Donnerstag = entity.Do;
                    item.Freitag = entity.Fr;
                    item.Samstag = entity.Sa;
                    item.Sonntag = entity.So;
                }
            }

            return item;
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveEssenStandardAsync(EssenStandardEditDto item)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                EssenStandard entity = await ctx.EssenStandards.FirstOrDefaultAsync(f => f.Id == item.Id).ConfigureAwait(true);
                if (entity == null)
                {
                    entity = new EssenStandard();
                    entity.Id = item.Id;
                    entity.BenutzerId = item.BenutzerId;
                    entity.Geloescht = false;
                    ctx.EssenStandards.Add(entity);
                }

                if (entity.Geloescht)
                {
                    return new ResultDto(false);
                }

                entity.Mo = item.Montag;
                entity.Di = item.Dienstag;
                entity.Mi = item.Mittwoch;
                entity.Do = item.Donnerstag;
                entity.Fr = item.Freitag;
                entity.Sa = item.Samstag;
                entity.So = item.Sonntag;

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
