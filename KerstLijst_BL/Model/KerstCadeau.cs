using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstLijst_BL.Model
{
    public class KerstCadeau
    {
        public Guid Id { get; set; }
        public string Titel { get; set; }
        public decimal? Prijs { get; set; }
        public string? Beschrijving { get; set; }
        public string? ImageUrl { get; set; }
        public Persoon GeschenkVoor { get; set; }

    }
}
