using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class Benutzer
    {
        public Benutzer()
        {
            BenutzerAllergies = new HashSet<BenutzerAllergie>();
            EssenStandards = new HashSet<EssenStandard>();
            Essens = new HashSet<Essen>();
        }

        public Guid Id { get; set; }
        public string BenutzerName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Passwort { get; set; } = null!;
        public Guid KlasseId { get; set; }
        public bool Veggetarisch { get; set; }
        public bool Geloescht { get; set; }

        public virtual Klasse Klasse { get; set; } = null!;
        public virtual ICollection<BenutzerAllergie> BenutzerAllergies { get; set; }
        public virtual ICollection<EssenStandard> EssenStandards { get; set; }
        public virtual ICollection<Essen> Essens { get; set; }
    }
}
