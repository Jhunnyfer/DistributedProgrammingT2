using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace DistributedPrism.ViewModels
{
    public class MapCountriesPageViewModel : ViewModelBase
    {
        public MapCountriesPageViewModel(INavigationService navigationService):base(navigationService)
        {

        }
    }
}
