
using MauiAppKerst.Interfaces;
using MauiAppKerst.ViewModels.Base;
using MauiKerst_BL.Interfaces;
using MauiKerst_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppKerst.ViewModels
{
    public class KerstLijstViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IKerstLijstService _kerstLijstService;

        private KerstLijst _kerstLijst;
        public KerstLijst KerstLijst
        {
            get => _kerstLijst;
            set
            {
                _kerstLijst = value;
                OnPropertyChanged();
            }
        }

        public ICommand NieuwKerstItemCommand { get; }

        public KerstLijstViewModel(
            INavigationService navigationService,
            IKerstLijstService kerstLijstService)
        {
            _navigationService = navigationService;
            _kerstLijstService = kerstLijstService;

            NieuwKerstItemCommand = new Command(OnNieuwKerstItem);
        }

        public void LoadKerstLijst()
        {
            KerstLijst = _kerstLijstService.GetKerstLijst();
        }

        private void OnNieuwKerstItem()
        {
            _navigationService.GoToNieuwKerstItemPage();
        }
    }
}
