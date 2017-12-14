using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XLabs.Forms.Controls;
using XFGloss;
using Xamarin.Forms;

namespace Week9PrismExampleApp.Views
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        async void Play_Clicked(object sender, EventArgs e)
        {
            
            while (true)
            {
                sun.Source = "sunsprite2";
                await Task.Delay(400);
                sun.Source = "sunsprite3";
                await Task.Delay(400);
                sun.Source = "sunsprite4";
                await Task.Delay(400);
                sun.Source = "sunsprite5";
                await Task.Delay(400);
                sun.Source = "sunsprite6";
                await Task.Delay(400);
                sun.Source = "sunsprite1";
                await Task.Delay(400);
            }
        }
    }

}
