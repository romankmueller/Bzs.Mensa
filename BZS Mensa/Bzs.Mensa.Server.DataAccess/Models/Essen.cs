using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class Essen
    {
        public Guid Id { get; set; }
        public DateTime Datum { get; set; }
        public Guid BenutzerId { get; set; }
        public bool Geloescht { get; set; }

        public virtual Benutzer Benutzer { get; set; } = null!;
    }
}
