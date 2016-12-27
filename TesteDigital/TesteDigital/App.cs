using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TesteDigital
{
    public class App : Application
    {
        public static TesteDigitalItemManager TesteDigitalManager { get; private set; }
        static TesteDigitalDatabase database;

        public App()
        {
            TesteDigitalManager = new TesteDigitalItemManager(new RestService());
            MainPage = new NavigationPage(new Personagens());
        }

        public static TesteDigitalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TesteDigitalDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TesteDigitalSQLite.db3"));
                }
                return database;
            }
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
