using Marvel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    class MainMasterPageModel : MasterDetailPage
    {
        public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

        public MainMasterPageModel()
        {
            MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
                {
                    new MainPageMenuItem { Id = 0, Title = "Heroes", ImagePath = "MenuIcon01.png", TargetType = typeof(ContentPage)},
                    new MainPageMenuItem { Id = 1, Title = "Favorites", ImagePath = "MenuIcon02.png", TargetType = typeof(ContentPage)},
                });
        }

        public new INavigation Navigation { get; set; }

        public ICommand ItemClickCommand => new Command<object>(async (item) =>
        {
            var id = ((MainPageMenuItem)item).Id;
            if ( id == 0)
                await App.MainMasterPage.Detail.Navigation.PopToRootAsync();
            else
                await App.MainMasterPage.Detail.Navigation.PushAsync(new FavPage());
            App.MainMasterPage.IsPresented = false;
        });

        public ICommand ReturnToMainmenuCommand => new Command(async () =>
        {
            await App.MainMasterPage.Detail.Navigation.PopToRootAsync();
            App.MainMasterPage.IsPresented = false;
        });
    }
}
