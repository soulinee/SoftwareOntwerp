using KerstLijstMaui_App.ViewModels;
using Microsoft.Extensions.Logging;

namespace KerstLijstMaui_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<MainViewModel>();

            // mijn services and repositories
            builder.Services.AddTransient<IKerstLijstService, KerstLijstService>();
            builder.Services.AddTransient<IWensLijstService, WenstLijstService>();
            builder.Services.AddTransient<INavigationService, NavigationService>();

            builder.Services.AddSingleton<IKerstLijstRepo, KerstLijstRepo>();
            builder.Services.AddSingleton<IWenstLijstRepo, WenstLijstRepo>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
