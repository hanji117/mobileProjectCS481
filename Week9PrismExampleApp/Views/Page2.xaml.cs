using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week9PrismExampleApp.Views
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        async void Play_Clicked(object sender, EventArgs e)
        {

            while (true)
            {
                rain.Source = "rain2";
                await Task.Delay(400);
                rain.Source = "rain3";
                await Task.Delay(400);
                rain.Source = "rain4";
                await Task.Delay(400);
                rain.Source = "rain5";
                await Task.Delay(400);
                rain.Source = "rain6";
                await Task.Delay(400);
                rain.Source = "rain1";
                await Task.Delay(400);
            }
        }
    }
}
