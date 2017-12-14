using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Week9PrismExampleApp.Views
{
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();
        }

        void Rotat_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var dregee = double.Parse(button.CommandParameter.ToString());
            cloud.RotateTo(dregee);
        }

        void ReRotae_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var dregee = double.Parse(button.CommandParameter.ToString());
            cloud.RelRotateTo(dregee);
        }
        async void Play_Clicked(object sender, EventArgs e)
        {
            while (true)
            {
                cloud.Source = "cloud2";
                await Task.Delay(400);
                cloud.Source = "cloud3";
                await Task.Delay(400);
                cloud.Source = "cloud4";
                await Task.Delay(400);
                cloud.Source = "cloud5";
                await Task.Delay(400);
                cloud.Source = "cloud6";
                await Task.Delay(400);
                cloud.Source = "cloud1";
                await Task.Delay(400);

            }
        }

    }
}
