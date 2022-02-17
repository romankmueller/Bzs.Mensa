using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class Allergie
    {
        public Allergie()
        {
            BenutzerAllergies = new HashSet<BenutzerAllergie>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; } = null!;
        public bool Geloescht { get; set; }

        public virtual ICollection<BenutzerAllergie> BenutzerAllergies { get; set; }
    }
}
