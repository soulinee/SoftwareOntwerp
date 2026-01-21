using MauiAppKerst.Interfaces;
using MauiAppKerst.ViewModels.Base;
using MauiKerst_BL.Interfaces;
using MauiKerst_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppKerst.ViewModels
{
    public class WensLijstViewModel : ViewModel
    {

        private readonly INavigationService _navigationService;
        private readonly IWensLijstService _wensLijstService;
        private WensLijst _wenslijst;
        public WensLijst WensLijst
        {
            get => _wenslijst;
            set { _wenslijst = value; OnPropertyChanged(); }
        }
        public WensLijstViewModel(INavigationService navigationService, IWensLijstService wensLijstService)
        {
            _navigationService = navigationService;
            _wensLijstService = wensLijstService;
        }

        

    }
}
