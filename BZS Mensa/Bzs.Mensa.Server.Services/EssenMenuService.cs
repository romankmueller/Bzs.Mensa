using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a meal menu service.
    /// </summary>
    public sealed class EssenMenuService : ServiceBase, IEssenMenuService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EssenService" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public EssenMenuService(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        public async Task<EssenMenuEditDto> EssenMenuAsync(EssenMenuRequestDto requestItem)
        {
            EssenMenuEditDto item = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                EssenMenu entity = await ctx.EssenMenus.FirstOrDefaultAsync(f => f.Datum == requestItem.Datum && !f.Geloescht).ConfigureAwait(true);
                if (entity != null)
                {
                    item = new EssenMenuEditDto();
                    item.Id = entity.Id;
                    item.Datum = entity.Datum;
                    item.MenuBeschreibung = entity.MenuBeschreibung;
                }
            }

            return item;
        }

        /// <inheritdoc />
        public async Task<EssenMenuEditDto> EssenMenuAsync(Guid id)
        {
            EssenMenuEditDto item = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                EssenMenu entity = await ctx.EssenMenus.FirstOrDefaultAsync(f => f.Id == id && !f.Geloescht).ConfigureAwait(true);
                if (entity != null)
                {
                    item = new EssenMenuEditDto();
                    item.Id = entity.Id;
                    item.Datum = entity.Datum;
                    item.MenuBeschreibung = entity.MenuBeschreibung;
                }
            }

            return item;
        }

        /// <inheritdoc />
        public async Task<ResultDto> SaveEssenMenuAsync(EssenMenuEditDto item)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                EssenMenu entity = await ctx.EssenMenus.FirstOrDefaultAsync(f => f.Id == item.Id).ConfigureAwait(true);
                if (entity == null)
                {
                    entity = new EssenMenu();
                    entity.Id = item.Id;
                    entity.Geloescht = false;
                    ctx.EssenMenus.Add(entity);
                }

                if (entity.Geloescht)
                {
                    return new ResultDto(false);
                }

                entity.Datum = item.Datum;
                entity.MenuBeschreibung = item.MenuBeschreibung;

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
        public async Task<ResultDto> DeleteEssenMenuAsync(Guid id)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                EssenMenu entity = await ctx.EssenMenus.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
                if (entity == null)
                {
                    return new ResultDto("EssenMenu konnte nicht gefunden werden.");
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
