using System;
using System.Collections.Generic;
using System.Text;
using Marvel.Models;
using Marvel.Services;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    class HeroPageModel : ContentPage
    {
        public Hero Hero { get; set; }

        private int _heroId;
        private INavigation _navigation;
        private readonly IRestService _restService;

        public HeroPageModel(INavigation navigation, int heroId)
        {
            _restService = new RestService();
            _navigation = navigation;
            _heroId = heroId;
        }
    }
}
