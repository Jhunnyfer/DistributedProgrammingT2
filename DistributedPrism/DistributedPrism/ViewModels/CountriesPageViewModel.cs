using System;
using DistributedProgrammingT2.Common.Helpers;
using DistributedProgrammingT2.Common.Models;
using DistributedProgrammingT2.Common.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections;

namespace DistributedPrism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        private ObservableCollection<CountriesItemViewModel> _listCountries;
        private String filter;
        private DelegateCommand _navigateCommand;
        private bool _isRunning;
        private bool _isEnabled;
        public CountriesPageViewModel(IApiService apiService, 
            INavigationService navigationService) :base(navigationService)
        {
            Title = "APP COUNTRIES by:JHUMA";
            _navigationService = navigationService;
            _apiService = apiService;

            IsRunning = false;
            IsEnabled = false;

            LoadAllCountries();
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public String Filter
        {
            get => this.filter;
            set => SetProperty(ref this.filter, value);
        }

        public DelegateCommand NavigateCommandCountry => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommmand));

        async void ExecuteNavigateCommmand()
        {
            await _navigationService.NavigateAsync("Country");
        }

        private async void LoadAllCountries() {

            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnection(url);
            if (!connection)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }

            ///Get all Countries
            var response = await _apiService.GetCountries(url, "/rest/", "v2/all");

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "This user have a big problem, call support.", "Accept");
                return;
            }

            var _countries = response.Result;

            ListCountries = new ObservableCollection<CountriesItemViewModel> (_countries.Select(c => new CountriesItemViewModel(_navigationService)
            {
               Name=c.Name,
               Acronym=c.Acronym,
               Capital =c.Capital,
               Flag = c.Flag,
               NativeName = c.NativeName
            }).ToList());

            //var countries = response.Result;
            Settings.Countries = JsonConvert.SerializeObject(_countries);
        }

        public ObservableCollection<CountriesItemViewModel> ListCountries {
            get => _listCountries;
            set => SetProperty(ref _listCountries, value);
        }
    }
}
