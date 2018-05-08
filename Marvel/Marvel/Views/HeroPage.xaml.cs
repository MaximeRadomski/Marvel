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
	public partial class HeroPage : ContentPage
	{
		public HeroPage (int heroId)
		{
		    BindingContext = new HeroPageModel(Navigation, heroId);
            InitializeComponent ();
		}
	}
}