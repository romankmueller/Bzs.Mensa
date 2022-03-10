using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Shared.DataTransferObjects;
using Bzs.Mensa.Shared.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Server.Services
{
    public class AllergienService : ServiceBase, IAllergienService
    {
        public AllergienService(IConfiguration configuration)
        : base(configuration)
        {
        }

        public List<AllergieEditDto> AllergienListe()
        {

            List<AllergieEditDto> list = new List<AllergieEditDto>();
            using (BzsMensaContext ctx = this.CreateContext())
            {
                foreach (var entity in ctx.Allergies.Where(f=> !f.Geloescht))
                {
                    AllergieEditDto item = new AllergieEditDto();
                    item.Id = entity.Id;
                    item.Bezeichnung = entity.Bezeichnung;
                    list.Add(item);
                }

            }
            return list;
        }

    }
}
