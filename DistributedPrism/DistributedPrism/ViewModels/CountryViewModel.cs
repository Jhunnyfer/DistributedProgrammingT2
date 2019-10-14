using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace DistributedPrism.ViewModels
{
    public class CountryViewModel : ViewModelBase
    {
        public CountryViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Country";
        }
    }
}
