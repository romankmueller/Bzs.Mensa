using Bzs.Mensa.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bzs.Mensa.Shared.Services
{
    public interface IAllergienService
    {
        List<AllergieEditDto> AllergienListe();
    }
}
