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
using Marvel.Views;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    class MainDetailPageModel : ContentPage
    {
        public List<Hero> Heroes { get; set; }
        public bool Loading { get; set; }
        public int FirstItem { get; set; }
        public int LastItem { get; set; }

        private int _listStart;
        private int _listLimit;
        private INavigation _navigation;
        private readonly IRestService _restService;

        public MainDetailPageModel(INavigation navigation)
        {
            _restService = new RestService();
            _navigation = navigation;
            _listStart = 0;
            _listLimit = 25;
            SetFirstAndLast();
            Task.Run(async () => await LoadItems());
        }

        private void SetFirstAndLast()
        {
            FirstItem = _listStart + 1;
            LastItem = _listStart + _listLimit;
        }

        public async Task LoadItems()
        {
            Loading = true;
            Heroes = await _restService.LoadHeroesRange(_listStart, _listLimit);
            Loading = false;
        }

        public ICommand NextPageCommand => new Command(async () =>
        {
            _listStart += _listLimit;
            FirstItem = _listStart + 1;
            LastItem = _listStart + _listLimit;
            await Task.Run(async () => await LoadItems());
        });

        public ICommand PreviousPageCommand => new Command(async () =>
        {
            if (_listStart - _listLimit >= 0)
                _listStart -= _listLimit;
            SetFirstAndLast();
            await Task.Run(async () => await LoadItems());
        });

        public ICommand PushHeroDetailsCommand => new Command<object>(async (item) =>
            {
                await _navigation.PushAsync(new HeroPage(((Hero)item).Id));
            });
    }
}
