using KerstLijstMaui_App.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KerstLijstMaui_App.ViewModels
{
    public class MainViewModel: ViewModel
    {
        public INavigationService NavigationService { get; init; }
        private IKerstLijstService KerstLijstService { get; init; }
        private IWensLijstService WensLijstService { get; init; }

        public ICommand ToonKerstLijstCommand { get; init; }
        public ICommand ToonWensLijstCommand { get; init; }


        public MainViewModel(INavigationService navigationService, IWensLijstService wensLijstService, IKerstLijstService kerstLijstService)
        {
            NavigationService = navigationService;
            KerstLijstService = kerstLijstService;
            WensLijstService = wensLijstService;
            ToonKerstLijstCommand = new Command(() => OnToonKerstLijst());

            ToonWensLijstCommand = new Command(() => OnToonWensLijst());

        }

        private void OnToonWensLijst()
        {
            // dan ga je naar de pagina met de wenstlijst
        }

        private void OnToonKerstLijst()
        {
            var kerstLijst = KerstLijstService.GetKerstLijst();
            NavigationService.GoToKerstLijstPage(kerstLijst);

        }
    }
}
