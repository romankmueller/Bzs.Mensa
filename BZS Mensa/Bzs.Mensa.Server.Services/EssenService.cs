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
        public async Task<EssenUebersichtDto> GetEssenUebersichtAsync(Guid userId)
        {
            EssenUebersichtDto data = new EssenUebersichtDto();
            DateTime heute = DateTime.Today;
            DateTime bzsHeute = new DateTime(heute.Year, heute.Month, heute.Day, 10, 0, 0, DateTimeKind.Utc).AddHours(-1).ToLocalTime();

            using (BzsMensaContext ctx = this.CreateContext())
            {
                for (int i = 0; i < 14; i++)
                {
                    EssenWocheDto essenWocheDto = new EssenWocheDto();
                    essenWocheDto.Datum = heute.AddDays(i);
                    essenWocheDto.Angemeldet = await ctx.Essens.AnyAsync(f => f.BenutzerId == userId && f.Datum == essenWocheDto.Datum && !f.Geloescht).ConfigureAwait(true);
                    essenWocheDto.MenuBeschreibung = ctx.EssenMenus.FirstOrDefault(f => f.Datum == essenWocheDto.Datum && !f.Geloescht)?.MenuBeschreibung ?? String.Empty;
                    essenWocheDto.FeiertagBezeichnung = ctx.Feiertags.FirstOrDefault(f => f.Datum == essenWocheDto.Datum && !f.Geloescht)?.Bezeichnung ?? String.Empty;

                    data.EssenWoche.Add(essenWocheDto);
                }
            }

            return data;
        }

        /// <inheritdoc />
        public async Task<EssenEditDto> EssenAsync(Guid id)
        {
            EssenEditDto? essen = null;
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Essen? entity = await ctx.Essens.FirstOrDefaultAsync(f => f.Id == id && !f.Geloescht).ConfigureAwait(true);
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
        /// 

        public async Task<ResultDto> DeleteEssenAsync1(EssenEditDto item)
        {
            DateTime aktuelleZeit = item.Datum.Date;
            aktuelleZeit.AddHours(10);
            aktuelleZeit.ToLocalTime();

            if(aktuelleZeit == DateTime.UtcNow)
            {
                using (BzsMensaContext ctx = this.CreateContext())
                {
                    Essen? entity = await ctx.Essens.FirstOrDefaultAsync(f => f.Datum == item.Datum && f.BenutzerId == item.BenutzerId).ConfigureAwait(true);
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
            else
            {
                return new ResultDto(false);
            }
        }

        public async Task<ResultDto> DeleteEssenAsync(Guid id)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Essen? entity = await ctx.Essens.FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(true);
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
        public async Task<ResultDto> SaveEssenAsync(EssenEditDto item)
        {
            using (BzsMensaContext ctx = this.CreateContext())
            {
                Essen? entity = await ctx.Essens.FirstOrDefaultAsync(f => f.Datum == item.Datum && f.BenutzerId == item.BenutzerId).ConfigureAwait(true);
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
                entity.BenutzerId = item.BenutzerId;

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
        public async Task<UebersichtTagReportDto> GetUebersichtTagReport(DateTime DatumVon, DateTime DatumBis)
        {
            UebersichtTagReportDto data = new UebersichtTagReportDto();

            using (BzsMensaContext ctx = this.CreateContext())
            {
                List<Essen> entities = await ctx.Essens
                    .Include(f => f.Benutzer)
                    .ThenInclude(f => f.Klasse)
                    .Where(f => f.Datum >= DatumVon && f.Datum <= DatumBis && !f.Geloescht).ToListAsync().ConfigureAwait(true);

                for (DateTime datum = DatumVon; datum <= DatumBis; datum.AddDays(1))
                {
                    UebersichtTagReportItemDto itemNormal = new UebersichtTagReportItemDto();
                    itemNormal.Bezeichnung = "Normal";
                    itemNormal.Schicht1 = entities.Where(f => f.Datum == datum && !f.Benutzer.Vegetarisch && f.Benutzer.Klasse.Schicht1).Count();
                    itemNormal.Schicht2 = entities.Where(f => f.Datum == datum && !f.Benutzer.Vegetarisch && f.Benutzer.Klasse.Schicht2).Count();
                    itemNormal.SortierungsNummer = 1;
                    itemNormal.Datum = datum;
                    data.Items.Add(itemNormal);

                    UebersichtTagReportItemDto itemVegi = new UebersichtTagReportItemDto();
                    itemVegi.Bezeichnung = "Vegetarisch";
                    itemVegi.Schicht1 = entities.Where(f => f.Datum == datum && f.Benutzer.Vegetarisch && f.Benutzer.Klasse.Schicht1).Count();
                    itemVegi.Schicht1 = entities.Where(f => f.Datum == datum && f.Benutzer.Vegetarisch && f.Benutzer.Klasse.Schicht2).Count();
                    itemVegi.SortierungsNummer = 2;
                    itemVegi.Datum = datum;
                    data.Items.Add(itemVegi);

                    UebersichtTagReportItemDto itemTotal = new UebersichtTagReportItemDto();
                    itemTotal.Bezeichnung = "Total";
                    itemTotal.Schicht1 = entities.Where(f => f.Datum == datum && f.Benutzer.Klasse.Schicht1).Count();
                    itemTotal.Schicht1 = entities.Where(f => f.Datum == datum && f.Benutzer.Klasse.Schicht2).Count();
                    itemTotal.SortierungsNummer = 5;
                    itemTotal.Datum = datum;
                    data.Items.Add(itemTotal);
                }

            }

            return data;
        }
    }
}
