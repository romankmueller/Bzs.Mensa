using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class Feiertag
    {
        public Guid Id { get; set; }
        public string Bezeichnung { get; set; } = null!;
        public DateTime Datum { get; set; }
        public bool Geloescht { get; set; }
    }
}
