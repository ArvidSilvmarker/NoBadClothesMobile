using System;
using Xamarin.Forms;

namespace NoBadClothes
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            BindingContext = new Weather();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cityNameEntry.Text))
            {
                Weather weather = await Core.GetWeather(cityNameEntry.Text);
                BindingContext = weather;
                getWeatherBtn.Text = "Igen?";
            }
        }
    }
}