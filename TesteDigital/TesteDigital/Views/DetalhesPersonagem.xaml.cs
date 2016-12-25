using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TesteDigital
{
    public partial class DetalhesPersonagem : ContentPage
    {
        bool isNewItem;

        public DetalhesPersonagem(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }

        async void OnSaveActivated(object sender, EventArgs e)
        {
            var todoItem = (Personagem)BindingContext;
            await App.TesteDigitalManager.SaveTaskAsync(todoItem, isNewItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteActivated(object sender, EventArgs e)
        {
            var todoItem = (Personagem)BindingContext;
            await App.TesteDigitalManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }

        void OnCancelActivated(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}
