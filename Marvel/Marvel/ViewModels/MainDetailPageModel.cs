using Marvel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Marvel.Services;
using Marvel.Views;
using Xamarin.Forms;
using Autofac;

namespace Marvel.ViewModels
{
    class MainDetailPageModel : ContentPage
    {
        public List<HeroListItem> Heroes { get; set; }
        public bool Loading { get; set; }
        public bool IsSearchingByName { get; set; }
        public int FirstItem { get; set; }
        public int LastItem { get; set; }
        public string SearchName { get; set; }

        private int _listStart;
        private int _listLimit;
        private INavigation _navigation;
        private readonly IRestService _restService;

        public MainDetailPageModel(INavigation navigation)
        {
            _restService = App.Container.Resolve<IRestService>();
            _navigation = navigation;
            ResetStartAndLimit();
            SearchName = null;
            Task.Run(async () => await LoadItems());
        }

        private void ResetStartAndLimit()
        {
            _listStart = 0;
            _listLimit = 25;
        }

        private void SetFirstAndLast()
        {
            if (Heroes != null && Heroes.Count > 0)
            {
                FirstItem = _listStart + 1;
                LastItem = _listStart + Heroes.Count;
            }
            else
            {
                FirstItem = 0;
                LastItem = 0;
            }
        }

        public async Task LoadItems()
        {
            Loading = true;
            Heroes = await _restService.LoadHeroesRange(_listStart, _listLimit, SearchName);
            Loading = false;
            SetFirstAndLast();
        }

        public ICommand NextPageCommand => new Command(async () =>
        {
            if (Heroes.Count == _listLimit)
                _listStart += _listLimit;
            else
                return;
            await Task.Run(async () => await LoadItems());
        });

        public ICommand PreviousPageCommand => new Command(async () =>
        {
            if (_listStart - _listLimit >= 0)
                _listStart -= _listLimit;
            else
                return;
            await Task.Run(async () => await LoadItems());
        });

        public ICommand PushHeroDetailsCommand => new Command<object>(async (item) =>
        {
            await _navigation.PushAsync(new HeroPage(((HeroListItem)item).Id));
        });

        public ICommand SearchByNameEnableCommand => new Command(async () =>
        {
            if (IsSearchingByName == false)
                IsSearchingByName = true;
            else
            {
                IsSearchingByName = false;
                SearchName = null;
                ResetStartAndLimit();
                await Task.Run(async () => await LoadItems());
            }
        });

        public ICommand SearchByNameCommand => new Command(async () =>
        {
            ResetStartAndLimit();
            await Task.Run(async () => await LoadItems());
        });
    }
}
