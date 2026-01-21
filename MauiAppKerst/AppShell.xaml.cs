using MauiAppKerst.Views;

namespace MauiAppKerst
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(KerstLijstPage), typeof(KerstLijstPage));
            Routing.RegisterRoute(nameof(WensLijstPage), typeof(WensLijstPage));
            Routing.RegisterRoute(nameof(NieuwKerstItemPage), typeof(NieuwKerstItemPage));

        }
    }
}
