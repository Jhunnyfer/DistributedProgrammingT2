using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Newtonsoft.Json;
using DistributedProgrammingT2.Common.Models;
using DistributedProgrammingT2.Common.Helpers;

namespace DistributedPrism.ViewModels
{
    public class CountryViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private CountryResponse _country;

        public CountryViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Country";
        }


        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            _country = JsonConvert.DeserializeObject<CountryResponse>(Settings.Countries);
        }
    }
}
