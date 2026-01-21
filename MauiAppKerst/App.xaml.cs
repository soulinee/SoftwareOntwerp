namespace MauiAppKerst
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();


        }

                protected override Window CreateWindow(IActivationState activationState)
                {
                    var window = base.CreateWindow(activationState);

        #if WINDOWS
            window.Width = 390;   // iPhone 12 breedte
            window.Height = 744;  // iPhone 12 hoogte
        #endif

                    return window;
                }

    }
}
