using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class EssenStandard
    {
        public Guid Id { get; set; }
        public Guid BenutzerId { get; set; }
        public bool Mo { get; set; }
        public bool Di { get; set; }
        public bool Mi { get; set; }
        public bool Do { get; set; }
        public bool Fr { get; set; }
        public bool Sa { get; set; }
        public bool So { get; set; }
        public bool Geloescht { get; set; }

        public virtual Benutzer Benutzer { get; set; } = null!;
    }
}
