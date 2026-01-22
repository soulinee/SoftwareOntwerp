using KerstLijst_BL.Interfaces;
using KerstLijst_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstLijst_BL.Services
{
    public class KerstLijstService(IKerstLijstRepo kerstLijstRepo): IKerstLijstService
    {
        private IKerstLijstRepo KerstLijstRepo { get; } = kerstLijstRepo;

        public KerstLijst GetKerstLijst()
        {
            return KerstLijstRepo.GetKerstLijst();
        }
    }
}
