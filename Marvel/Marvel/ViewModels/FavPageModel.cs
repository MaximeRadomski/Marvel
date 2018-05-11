using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Marvel.Models;
using Marvel.Services;
using Marvel.Views;
using Xamarin.Forms;
using Autofac;

namespace Marvel.ViewModels
{
    class FavPageModel : ContentPage
    {
        public List<HeroFavorite> Heroes { get; set; }
        public bool Loading { get; set; }

        private INavigation _navigation;
        private readonly ILocalDatabaseService _localDatabaseService;

        public FavPageModel(INavigation navigation)
        {
            _localDatabaseService = App.Container.Resolve<ILocalDatabaseService>();
            _navigation = navigation;
            //Task.Run(async () => await LoadItems());
        }

        public async Task LoadItems()
        {
            Loading = true;
            Heroes = await _localDatabaseService.LoadHeroes();
            Loading = false;
        }

        public ICommand PushHeroDetailsCommand => new Command<object>(async (item) =>
        {
            await _navigation.PushAsync(new HeroPage(((HeroFavorite)item).Id));
        });
    }
}
