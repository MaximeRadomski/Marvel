using System;
using Autofac;
using Marvel.Services;
using Marvel.ViewModels;
using Marvel.Views;
using Xamarin.Forms;

namespace Marvel
{
	public partial class App : Application
	{
        public static MainPage MainMasterPage;

        public static IContainer Container { get; set; }

        public App ()
		{
            InitializeContainer();
            InitializeComponent();
            MainMasterPage = new MainPage();
            MainPage = MainMasterPage;
        }

	    private void InitializeContainer()
	    {
	        ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<LocalDatabaseService>().As<ILocalDatabaseService>();
            builder.RegisterType<RestService>().As<IRestService>();
	        Container = builder.Build();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
