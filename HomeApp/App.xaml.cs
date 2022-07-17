using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomeApp.Pages;

namespace HomeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new LoadingPage();
            //MainPage = new SpanPage();
            //MainPage = new LoginPage();
            //MainPage = new RegisterPage();
            //MainPage = new RoomsPage();
            //MainPage = new DevicesPage();
            //MainPage = new ClimatePage();
            //MainPage = new AboutPage();
            //MainPage = new GridPage();
            //MainPage = new MergeGridPage2();
            //MainPage = new PaddingPageFlyout();
            //MainPage = new PaddingPage();
            //MainPage = new CsharpPaddingPage();
            //MainPage = new NewDevicePage();
            //MainPage = new DeviceContolPage();
            //MainPage = new ProfilePage();
            //MainPage = new WebPage();
            //MainPage = new BindingPage();
            //MainPage = new BindingModePage();
            //MainPage = new DeviceListPage();

            // Инициализация главного экрана и стека навигации
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
