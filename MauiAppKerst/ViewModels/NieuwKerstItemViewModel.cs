using MauiAppKerst.Interfaces;
using MauiAppKerst.ViewModels.Base;
using MauiKerst_BL.Interfaces;
using MauiKerst_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppKerst.ViewModels
{
    public class NieuwKerstItemViewModel : ViewModel
    {
        private readonly IKerstLijstService _kerstLijstService;
        private readonly INavigationService _navigation;

        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string ImageUrl { get; set; }
        public decimal Prijs { get; set; }
        public string GeschenkVoorNaam { get; set; }

        public ICommand BewaarCommand { get; }
        public ICommand AnnuleerCommand { get; }

        public NieuwKerstItemViewModel(
           IKerstLijstService kerstLijstService,
            INavigationService navigation)
        {
            _kerstLijstService = kerstLijstService;
            _navigation = navigation;

            BewaarCommand = new Command(OnBewaar);
            AnnuleerCommand = new Command(() => _navigation.GoBack());
        }

        private void OnBewaar()
        {
            try
            {
                var cadeau = new KerstCadeau(
                    Guid.NewGuid(),
                    Titel,
                    Prijs,
                    new Persoon(Guid.NewGuid(), GeschenkVoorNaam, null),
                    Beschrijving,
                    ImageUrl
                );

                _kerstLijstService.AddKerstCadeau(cadeau);

                _navigation.ShowPopup(
                    "Opgeslagen",
                    "Het cadeau is succesvol toegevoegd"
                );

                _navigation.GoBack();
            }
            catch (Exception ex)
            {
                _navigation.ShowPopup(
                    "Fout",
                    ex.Message
                );
            }
        }
    }
}
