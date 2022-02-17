using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class Klasse
    {
        public Klasse()
        {
            Benutzers = new HashSet<Benutzer>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; } = null!;
        public bool Schicht1 { get; set; }
        public bool Schicht2 { get; set; }
        public bool Geloescht { get; set; }

        public virtual ICollection<Benutzer> Benutzers { get; set; }
    }
}
