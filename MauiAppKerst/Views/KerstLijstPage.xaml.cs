using MauiAppKerst.ViewModels;
using MauiKerst_BL.Model;

namespace MauiAppKerst.Views;
[QueryProperty(nameof(KerstLijst), "KerstLijst")]
public partial class KerstLijstPage : ContentPage
{
    private readonly KerstLijstViewModel _vm;

    

     
    public KerstLijstPage(KerstLijstViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = _vm;

    }
    public KerstLijst KerstLijst
    {
        get => _vm.KerstLijst;
        set => _vm.KerstLijst = value;
    }
    

}