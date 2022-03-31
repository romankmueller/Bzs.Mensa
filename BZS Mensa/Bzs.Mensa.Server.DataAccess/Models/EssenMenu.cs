using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class EssenMenu
    {
        public Guid Id { get; set; }
        public DateTime Datum { get; set; }
        public string MenuBeschreibung { get; set; } = null!;
        public bool Geloescht { get; set; }
    }
}
