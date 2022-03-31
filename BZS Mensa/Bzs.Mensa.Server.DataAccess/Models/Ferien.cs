using System;
using System.Collections.Generic;

namespace Bzs.Mensa.Server.DataAccess.Models
{
    public partial class Ferien
    {
        public Guid Id { get; set; }
        public string Bezeichnung { get; set; } = null!;
        public DateTime VonDatum { get; set; }
        public DateTime BisDatum { get; set; }
        public bool Geloescht { get; set; }
    }
}
