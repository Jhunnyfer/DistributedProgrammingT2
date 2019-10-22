using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using DistributedProgrammingT2.Common.Models;
using DistributedProgrammingT2.Common.Helpers;
using Newtonsoft.Json;

namespace DistributedPrism.ViewModels
{
    public class CountriesItemViewModel : CountryResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCountriesCommand;

        public CountriesItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectCountryCommand => _selectCountriesCommand ?? (_selectCountriesCommand = new DelegateCommand(SelectCountry));

        private async void SelectCountry()
        {
            var parameters = new NavigationParameters
            {
                { "country", this }
            };

            Settings.Country = JsonConvert.SerializeObject(this);

            await _navigationService.NavigateAsync("CountryPage", parameters);
        }
    }
}
