using MauiAppKerst.Interfaces;
using MauiAppKerst.Services;
using MauiAppKerst.ViewModels;
using MauiAppKerst.Views;
using MauiKerst_BL.Interfaces;
using MauiKerst_BL.Services;
using MauiKerst_DL.Repos;
using Microsoft.Extensions.Logging;

namespace MauiAppKerst
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

            builder.Services.AddTransient<IKerstLijstService, KerstLijstService>();
            builder.Services.AddTransient<IWensLijstService, WenstLijstService>();
            builder.Services.AddTransient<INavigationService, NavigationService>();
            builder.Services.AddTransient<WensLijstViewModel>();
            builder.Services.AddSingleton<IKerstLijstRepo, LiteDbKerstRepo>();
            builder.Services.AddSingleton<IWenstLijstRepo, LiteDbWensRepo>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<KerstLijstViewModel>();
            builder.Services.AddTransient<KerstLijstPage>();
            builder.Services.AddTransient<WensLijstPage>();
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<App>();
            builder.Services.AddTransient<NieuwKerstItemViewModel>();
            builder.Services.AddTransient<NieuwKerstItemPage>();

            var dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "kerstlijst.litedb"
            );

                        builder.Services.AddSingleton<IKerstLijstRepo>(
                            _ => new LiteDbKerstRepo(dbPath)
                        );



#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app =  builder.Build();
            // 🔥 HIER doe je de reset
            //using (var scope = app.Services.CreateScope())
            //{
            //    var repo = scope.ServiceProvider.GetRequiredService<IKerstLijstRepo>();
            //    repo.DeleteAllKerstLijsten();
            //}
            return app;
        }
    }
}
