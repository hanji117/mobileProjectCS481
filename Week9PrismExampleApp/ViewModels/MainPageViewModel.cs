﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using static Week9PrismExampleApp.Models.WeatherItemModel;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;

[assembly: InternalsVisibleTo("Week9PrismExampleUnitTests")]
namespace Week9PrismExampleApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand NavToNewPageCommand { get; set; }
        public DelegateCommand GetWeatherForLocationCommand { get; set; }
        public DelegateCommand<WeatherItem> NavToMoreInfoPageCommand { get; set; }
        public DelegateCommand<WeatherItem> DeleteItemCommand { get; set; }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _locationEnteredByUser;
        public string LocationEnteredByUser
        {
            get { return _locationEnteredByUser; }
            set { SetProperty(ref _locationEnteredByUser, value); }
        }

        private ObservableCollection<WeatherItem> _weatherCollection = new ObservableCollection<WeatherItem>();
        public ObservableCollection<WeatherItem> WeatherCollection
        {
            get { return _weatherCollection; }
            set { SetProperty(ref _weatherCollection, value); }
        }

        private ObservableCollection<List> _listWeatherData = new ObservableCollection<List>();
        public ObservableCollection<List> ListWeatherData
        {
            get { return _listWeatherData; }
            set { SetProperty(ref _listWeatherData, value); }
        }

        INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavToNewPageCommand = new DelegateCommand(NavToNewPage);
            GetWeatherForLocationCommand = new DelegateCommand(GetWeatherForLocation);
            NavToMoreInfoPageCommand = new DelegateCommand<WeatherItem>(NavToMoreInfoPage);
            DeleteItemCommand = new DelegateCommand<WeatherItem>(DeleteItem);

            Title = "Xamarin Forms Application + Prism";
            ButtonText = "Add Name";
        }

        private async void NavToMoreInfoPage(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);
            await _navigationService.NavigateAsync("MoreInfoPage", navParams);
        }

        internal async void GetWeatherForLocation()
        {
            Analytics.TrackEvent("GetWeatherButtonTapped", new Dictionary<string, string> {
                { "WeatherLocation", LocationEnteredByUser},
            });

            HttpClient client = new HttpClient();
            var uri = new Uri(
                string.Format(
                    $"http://api.openweathermap.org/data/2.5/forecast?q={LocationEnteredByUser}&units=imperial&APPID=" +
                    $"{ApiKeys.WeatherKey}"));
            var response = await client.GetAsync(uri);
            WeatherItem weatherData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherData = WeatherItem.FromJson(content);
            }
            PopulateListData(weatherData);
            WeatherCollection.Add(weatherData);
        }

        public void PopulateListData(WeatherItem singleWeatherItem)
        {
            ListWeatherData.Add(singleWeatherItem.List[0]);
        }

        private async void NavToNewPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("SamplePageForNavigation", navParams);
        }

        private void DeleteItem(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);

            WeatherCollection.Remove(weatherItem);

        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}

