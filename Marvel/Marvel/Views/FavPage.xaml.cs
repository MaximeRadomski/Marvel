using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marvel.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvel.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavPage : ContentPage
	{
		public FavPage ()
		{
		    BindingContext = new FavPageModel(Navigation);
            InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            Task.Run(async () => await ((FavPageModel)BindingContext).LoadItems());
            base.OnAppearing();
        }
    }
}