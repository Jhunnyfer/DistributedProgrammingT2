using Prism;
using Prism.Ioc;
using DistributedPrism.ViewModels;
using DistributedPrism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DistributedProgrammingT2.Common.Services;
using DistributedProgrammingT2.Common.Helpers;
using DistributedProgrammingT2.Common.Models;
using Newtonsoft.Json;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DistributedPrism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTM3Njg0QDMxMzcyZTMyMmUzMGUvQlg3Tnk5ODRGQ01pbzNnWmEyWHdWcExaaUVOQ0FKODZGNDFpekRtd2M9");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/CountriesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CountryPage, CountryPageViewModel>();
            containerRegistry.RegisterForNavigation<CountriesPage, CountriesPageViewModel>();
            containerRegistry.RegisterForNavigation<MapCountriesPage, MapCountriesPageViewModel>();
            containerRegistry.RegisterForNavigation<MapCountryPage, MapCountryPageViewModel>();
        }
    }
}
