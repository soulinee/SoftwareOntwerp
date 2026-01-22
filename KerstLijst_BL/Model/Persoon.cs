using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstLijst_BL.Model
{
    public class Persoon
    {
        public Guid Id { get; set; }
        public string Voornaam { get; set; } = "";
        public string? Achternaam { get; set; }
    }
}
