using MauiAppKerst.Interfaces;
using MauiAppKerst.Views;
using MauiKerst_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppKerst.Services
{
    public class NavigationService : INavigationService
    {
        public void GoBack()
        {
            // We 'poppen' de meest recente pagina
            Shell.Current.Navigation.PopAsync();
        }

        public async Task GoToKerstLijstPageAsync(KerstLijst kerstLijst)
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(KerstLijstPage), true, new Dictionary<string, object>
                {
                    ["KerstLijst"] = kerstLijst
                });
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NAV ERROR", ex.Message, "OK");
            }
        }


        private void GoTo(string routeName, ShellNavigationQueryParameters parameters)
        {
            Shell.Current.GoToAsync(routeName, parameters);
        }

        public async Task GoToWensLijstPageAsync(WensLijst wensLijst)
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(WensLijstPage), true, new Dictionary<string, object>
                {
                    ["WensLijst"] = wensLijst
                });
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NAV ERROR", ex.Message, "OK");
            }
        }

        public void ShowPopup(string title, string text)
        {
            App.Current.MainPage.DisplayAlert(title, text, "Sluiten");
        }
        public void GoToNieuwKerstItemPage()
        {
            Shell.Current.GoToAsync(nameof(NieuwKerstItemPage));
        }


    }
}
