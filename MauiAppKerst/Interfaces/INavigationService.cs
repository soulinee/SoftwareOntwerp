using MauiKerst_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppKerst.Interfaces
{
    public interface INavigationService
    {
        void GoBack();
        Task GoToKerstLijstPageAsync(KerstLijst kerstLijst);

        Task GoToWensLijstPageAsync(WensLijst wensLijst);
        void ShowPopup(string title, string text);
        void GoToNieuwKerstItemPage();

    }
}
