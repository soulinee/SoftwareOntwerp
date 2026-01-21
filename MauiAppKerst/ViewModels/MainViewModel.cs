using MauiAppKerst.Interfaces;
using MauiAppKerst.ViewModels.Base;
using MauiKerst_BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppKerst.ViewModels
{
    public class MainViewModel : ViewModel
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
            ToonKerstLijstCommand = new Command(async() => await OnToonKerstLijst());

            ToonWensLijstCommand = new Command(() => OnToonWensLijst());

        }

        private async Task OnToonWensLijst()
        {
           var wensLijst = WensLijstService.GetWensLijst();
            await NavigationService.GoToWensLijstPageAsync(wensLijst);
        }

        private async Task OnToonKerstLijst()
        {
            
            var kerstLijst = KerstLijstService.GetKerstLijst();
            await NavigationService.GoToKerstLijstPageAsync(kerstLijst);

        }
    }
}
