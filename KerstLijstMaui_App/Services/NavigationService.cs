using KerstLijstMaui_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstLijstMaui_App.Services
{
    public class NavigationService : INavigationService
    {
        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void GoToKerstLijstPage(KerstLijst kerstLijst)
        {
            GoTo(nameof(KerstLijstPage), new ShellNavigationQueryParameters
            {
                { "KerstLijst", kerstLijst }
            });

        }

        private void GoTo(string routeName, ShellNavigationQueryParameters parameters)
        {
            Shell.Current.GoToAsync(routeName, parameters);
        }

        public void GoToWensLijstPage(string wensLijst)
        {
            GoTo(nameof(WensLijstPage), new ShellNavigationQueryParameters
            {
                { "WensLijst", wensLijst }
            });
        }

        public void ShowPopup(string message)
        {
            throw new NotImplementedException();
        }
    }
}
