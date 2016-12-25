using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoREST;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TesteDigital
{
    public class App : Application
    {
        public static TesteDigitalItemManager TesteDigitalManager { get; private set; }


        public App()
        {
            TesteDigitalManager = new TesteDigitalItemManager(new RestService());
            MainPage = new NavigationPage(new Personagens());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
