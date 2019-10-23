using DistributedProgrammingT2.Common.Helpers;
using DistributedProgrammingT2.Common.Models;
using Newtonsoft.Json;
using Plugin.Geolocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace DistributedPrism.Views
{
    public partial class MapCountryPage : ContentPage
    {
        private CountryResponse _country = new CountryResponse();
        public MapCountryPage()
        {
            InitializeComponent();

            _country = JsonConvert.DeserializeObject<CountryResponse>(Settings.Country);

            Pin CountryPin = new Pin
            {
                Type = PinType.SavedPin,
                Position = new Position(_country.Latlng[0], _country.Latlng[1]),
                Label = _country.Name,
                Address = ""
            };

            MapView.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(_country.Latlng[0], _country.Latlng[1]), Distance.FromMiles(10)));

            MapView.Pins.Add(CountryPin);
        }

        public CountryResponse Country
        {
            get => _country;
            set => _country = value;
        }
    }
}
