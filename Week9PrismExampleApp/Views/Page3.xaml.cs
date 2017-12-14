using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week9PrismExampleApp.Views
{
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }
        async void Play_Clicked(object sender, EventArgs e)
        {
            while (true)
            {
                tornado.Source = "tornado2";
                await Task.Delay(400);
                tornado.Source = "tornado3_";
                await Task.Delay(400);
                tornado.Source = "tornado4";
                await Task.Delay(400);
                tornado.Source = "tornado5";
                await Task.Delay(400);
            }
        }

    }
}
