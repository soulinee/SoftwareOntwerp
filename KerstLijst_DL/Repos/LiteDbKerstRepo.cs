using KerstLijst_BL.Interfaces;
using KerstLijst_BL.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstLijst_DL.Repos
{
    public class LiteDbKerstRepo : IKerstLijstRepo
    {
        private Lazy<ILiteDatabase> _database = new Lazy<ILiteDatabase>(() => new LiteDatabase("kerstlijst.litedb"));
        private ILiteCollection<KerstLijst> _kerstLijsten;
        private ILiteCollection<KerstLijst> KerstLijsten
            => _kerstLijsten ??= _database.Value.GetCollection<KerstLijst>("kerstlijsten");

        public KerstLijst GetKerstLijst()
        {
            var lijst = KerstLijsten
               .Query()
               .OrderBy(x => x.Titel)
               .FirstOrDefault();

            if (lijst == null)
            {
                lijst = CreateDefaultKerstLijst();
                KerstLijsten.Insert(lijst);
            }

            return lijst;
        }

        private KerstLijst CreateDefaultKerstLijst()
        {
            return new KerstLijst
            {
                Titel = "Mijn Kerstlijst",
                KerstCadeau = new List<KerstCadeau>
                {
                    new KerstCadeau
                    {
                        Id = Guid.NewGuid(),
                        Titel = "Boek",
                        Prijs = 25,
                        Beschrijving = "Een goed boek"
                    }
                }
            };
        }

    }
}
