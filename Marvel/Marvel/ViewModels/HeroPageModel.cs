using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Marvel.Models;
using Marvel.Services;
using Marvel.Views;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    class HeroPageModel : ContentPage
    {
        public List<Comic> CustomComicsList { get; set; }
        public HeroDetails Hero { get; set; }
        public bool Loading { get; set; }
        public bool IsFavorite { get; set; }

        private int _heroId;
        private INavigation _navigation;
        private readonly IRestService _restService;
        private readonly ILocalDatabaseService _localDatabaseService;

        public HeroPageModel(INavigation navigation, int heroId)
        {
            _restService = new RestService();
            _localDatabaseService = new LocalDatabaseService();
            _navigation = navigation;
            _heroId = heroId;
            Task.Run(async () => await LoadItems());
        }

        public async Task LoadItems()
        {
            Loading = true;
            Hero = await _restService.LoadHeroDetails(_heroId);
            CustomComicsList = Hero.Comics.Items.GetRange(0, Hero.Comics.Items.Count >= 3 ? 3 : Hero.Comics.Items.Count);
            HandleErrorsOrMissingParameters();
            IsHeroFavorite();
            Loading = false;
        }

        private void HandleErrorsOrMissingParameters()
        {
            if (string.IsNullOrEmpty(Hero.Description))
                Hero.Description = Hero.Name + " has no description.";
            if (CustomComicsList.Count == 0)
                CustomComicsList.Add(new Comic
                {
                    Name = Hero.Name + " makes no appearance in any comics",
                    ResourceUri = null
                });
        }

        private async void IsHeroFavorite()
        {
            HeroFavorite tmp = await _localDatabaseService.GetFavoriteHeroFromId(Hero.Id);
            if (tmp != null)
            {
                IsFavorite = true;
            }
        }

        public ICommand OpenComicsUrlCommand => new Command<object>((item) =>
        {
            if (((Comic)item).ResourceUri == null)
                return;
            Device.OpenUri(new Uri("https://www.google.com/search?q=Marvel " + ((Comic) item).Name));
            return;
        });

        public ICommand AddRemoveFavoriteCommand => new Command(async () =>
        {
            if (IsFavorite == false)
            {
                IsFavorite = true;
                await _localDatabaseService.AddFavoriteHero(Hero);
            }
            else
            {
                IsFavorite = false;
                await _localDatabaseService.RemoveFavoriteHero(Hero);
            }
        });
    }
}
