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
      
        public DetalhesPersonagem()
        {
            InitializeComponent();
        }

       void OnVoltar(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}
