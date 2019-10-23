using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Prism.Navigation;
using DistributedProgrammingT2.Common.Models;
using DistributedProgrammingT2.Common.Helpers;

namespace DistributedPrism.ViewModels
{
    public class CountryTabbedPageViewModel : ViewModelBase
    {
        public CountryTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            var country = JsonConvert.DeserializeObject<CountryResponse>(Settings.Country);
            Title = country.Name;
        }
    }
}
