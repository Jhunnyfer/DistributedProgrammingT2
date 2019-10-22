using DistributedProgrammingT2.Common.Helpers;
using DistributedProgrammingT2.Common.Models;
using DistributedProgrammingT2.Common.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DistributedPrism.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        private ObservableCollection<CountriesItemViewModel> _listCountries;
        private List<CountryResponse> _countries;
        private String filter;
        private DelegateCommand _navigateCommand;
        private bool _isRunning;
        private bool _isEnabled;
        private string _url;
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

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
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

        private async void LoadAllCountries() {

            var isConnection = true;

            Url = Prism.PrismApplicationBase.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnection(Url);
            if (!connection)
            {
                IsEnabled = true;
                IsRunning = false;
                isConnection = false;
                //await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                //return;
            }

            if(isConnection==true)
            {
                    IsRunning = true;
                    IsEnabled = false;

                    var response = await _apiService.GetCountries(Url, "/rest/", "v2/all");

                    if (!response.IsSuccess)
                    {
                        IsRunning = false;
                        IsEnabled = true;
                        await App.Current.MainPage.DisplayAlert("Error", "This user have a big problem, call support.", "Accept");
                        return;
                    }

                Countries = response.Result;

                Settings.Countries = JsonConvert.SerializeObject(_countries);

            }
            else{
                Countries = JsonConvert.DeserializeObject<List<CountryResponse>>(Settings.Countries);
            }

            ListCountries = new ObservableCollection<CountriesItemViewModel>(Countries.Select(c => new CountriesItemViewModel(_navigationService)
            {
                Name = c.Name,
                Acronym = c.Acronym,
                Capital = c.Capital,
                Flag = c.Flag,
                NativeName = c.NativeName,
                Region = c.Region,
                Latlng = c.Latlng,
                Area = c.Area
            }).ToList());

            IsRunning = false;
            IsEnabled = true;
        }

        public ObservableCollection<CountriesItemViewModel> ListCountries {
            get => _listCountries;
            set => SetProperty(ref _listCountries, value);
        }

        public List<CountryResponse> Countries {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }


        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                ListCountries = new ObservableCollection<CountriesItemViewModel>(Countries.Select(c => new CountriesItemViewModel(_navigationService)
                {
                    Name = c.Name,
                    Acronym = c.Acronym,
                    Capital = c.Capital,
                    Flag = c.Flag,
                    NativeName = c.NativeName,
                    Region = c.Region,
                    Latlng = c.Latlng,
                    Area = c.Area
                }).ToList());
            }
            else
            {
                ListCountries = new ObservableCollection<CountriesItemViewModel>(
                    Countries.Select(c => new CountriesItemViewModel(_navigationService)
                    {
                        Name = c.Name,
                        Acronym = c.Acronym,
                        Capital = c.Capital,
                        Flag = c.Flag,
                        NativeName = c.NativeName,
                        Region = c.Region,
                        Latlng = c.Latlng,
                        Area = c.Area
                    }).ToList().Where(
                        l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }

    }
}
