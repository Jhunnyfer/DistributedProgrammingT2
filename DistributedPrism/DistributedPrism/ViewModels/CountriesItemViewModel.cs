﻿using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using DistributedProgrammingT2.Common.Models;

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

            await _navigationService.NavigateAsync("CountryPage", parameters);
        }


        /*public DelegateCommand NavigateCommandCountry => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommmand));

        async void ExecuteNavigateCommmand()
        {
            await _navigationService.NavigateAsync("Country");
        }*/
    }
}
