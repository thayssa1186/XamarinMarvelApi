using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TesteDigital
{
    public partial class Personagens : ContentPage
    {
        bool alertShown = false;

        public Personagens()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Constants.RestUrl.Contains("developer.xamarin.com"))
            {
                if (!alertShown)
                {
                    await DisplayAlert(
                        "Hosted Back-End",
                        "This app is running against Xamarin's read-only REST service. To create, edit, and delete data you must update the service endpoint to point to your own hosted REST service.",
                        "OK");
                    alertShown = true;
                }
            }

            listView.ItemsSource = await App.TesteDigitalManager.GetTasksAsync();
        }

      

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var personagemItem = e.SelectedItem as Personagem;
            var detalhePersonagemItem = new DetalhesPersonagem();
            detalhePersonagemItem.BindingContext = personagemItem;
            Navigation.PushAsync(detalhePersonagemItem);
        }

    }
}
