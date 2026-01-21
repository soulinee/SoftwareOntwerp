using MauiAppKerst.ViewModels;
using MauiKerst_BL.Model;

namespace MauiAppKerst.Views;
 
public partial class NieuwKerstItemPage : ContentPage
{
    
    public NieuwKerstItemPage(NieuwKerstItemViewModel vm)
	{
		InitializeComponent();
         
        
         
        BindingContext = vm;
    }
}