using DistributedProgrammingT2.Common.Helpers;
using DistributedProgrammingT2.Common.Models;
using Newtonsoft.Json;
using Plugin.Geolocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DistributedPrism.Views
{
    public partial class CountryPage : ContentPage
    {
        private CountryResponse _country = new CountryResponse();

        public CountryPage()
        {

            InitializeComponent();
        }


    }
}
