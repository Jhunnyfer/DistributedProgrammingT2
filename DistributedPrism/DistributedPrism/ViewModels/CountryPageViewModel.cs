using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Newtonsoft.Json;
using DistributedProgrammingT2.Common.Models;
using DistributedProgrammingT2.Common.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DistributedPrism.ViewModels
{
    public class CountryPageViewModel : ViewModelBase
    {
        private CountryResponse _country;

        public CountryPageViewModel(INavigationService navigationService):base(navigationService)
        {
           // Title = "";
        }


        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("country"))
            {
                base.OnNavigatedTo(parameters);
                //_country = JsonConvert.DeserializeObject<CountryResponse>(Settings.Countries);
                Country = parameters.GetValue<CountryResponse>("country");
                Title = _country.Name;

               
            }
        }
    }
}
