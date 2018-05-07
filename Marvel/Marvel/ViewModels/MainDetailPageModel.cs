using Marvel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Marvel.Services;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    class MainDetailPageModel : ContentPage
    {
        public List<Hero> Heroes { get; set; }
        public Hero SampleHero { get; set; }

        private int _listStart;
        private INavigation _navigation;
        private readonly IRestService _restService;

        public MainDetailPageModel(INavigation navigation)
        {
            _restService = new RestService();
            _navigation = navigation;
            _listStart = 0;
            Task.Run(async () => await LoadItems());
        }

        public async Task LoadItems()
        {
            Heroes = await _restService.LoadHeroesRange(_listStart);
            SampleHero = Heroes[0];
        }

        public ICommand TestCallCommand => new Command(async () =>
        {
            _listStart += 19;
            await Task.Run(async () => await LoadItems());
        });
    }
}
