using MauiAppKerst.ViewModels;
using MauiKerst_BL.Model;

namespace MauiAppKerst.Views;
[QueryProperty(nameof(WensLijst), "WensLijst")]
public partial class WensLijstPage : ContentPage
{
	private readonly WensLijstViewModel _vm;

    public WensLijstPage(WensLijstViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }

    public WensLijst WensLijst
    {
        get => _vm.WensLijst;
        set => _vm.WensLijst = value;
    }
    
}