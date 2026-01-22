using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstLijst_BL.Model
{
    public class KerstLijst
    {
        public string Titel { get; set; }
        public List<KerstCadeau> KerstCadeau { get; set; }
    }
}
