using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace NoBadClothes
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string city)
        {
            //Todo: lägg till kod för att söka på andra städer än Göteborg.
            string url = "https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/11.968802/lat/57.706775/data.json";
            dynamic result = await DataService.getForecast(url).ConfigureAwait(false);
            Forecast forecast = (Forecast) result;
            return MapWeather(forecast, city);
        }

        private static Weather MapWeather(Forecast forecast, string city)
        {
            var weather = new Weather();
            var time = NextFullHour();
            var weatherParameters = forecast.timeSeries.First(t => t.validTime == time).parameters;

            weather.Temperature = weatherParameters.First(p => p.name == "t").values[0].ToString() + " °C";
            weather.WindSpeed = weatherParameters.First(p => p.name == "ws").values[0].ToString() + " m/s";
            weather.Precipation = weatherParameters.First(p => p.name == "pmean").values[0].ToString() + " mm/h";
            weather.Title = city;

            return weather;
        }

        private static string NextFullHour()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var hour = DateTime.Now.Hour + 1;
            if (hour > 23)
            {
                hour -= 24;
                day++;
                //todo: Lägg till kod om månaden slår över.
            }
            return $"{year}-{month:00}-{day:00}T{hour:00}:00:00Z";
        }

    }
}