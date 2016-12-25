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

        void OnAddItemClicked(object sender, EventArgs e)
        {
            var todoItem = new Personagem()
            {
                ID = Guid.NewGuid().ToString()
            };
            var todoPage = new DetalhesPersonagem(true);
            todoPage.BindingContext = todoItem;
            Navigation.PushAsync(todoPage);
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = e.SelectedItem as Personagem;
            var todoPage = new DetalhesPersonagem();
            todoPage.BindingContext = todoItem;
            Navigation.PushAsync(todoPage);
        }

    }
}
