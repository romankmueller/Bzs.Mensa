using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class BenutzerAllergie
    {
        public Guid Id { get; set; }
        public Guid BenutzerId { get; set; }
        public Guid AllergieId { get; set; }

        public virtual Allergie Allergie { get; set; } = null!;
        public virtual Benutzer Benutzer { get; set; } = null!;
    }
}
