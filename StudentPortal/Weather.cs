using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPortal
{

    public static class PublicStaticClass
    {
        public static Form1 f1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();

        public static async void WeatherFunction()
        {

            //Load the form into an object
            var baseURL = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/bangladesh?unitGroup=metric&include=days&key=HH2MN3AM4S8Y2UR34YG46B3AY&contentType=json";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, baseURL);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            dynamic weather = JsonConvert.DeserializeObject(body);

            foreach (var day in weather.days)
            {
                string weather_date = day.datetime;
                string weather_tmax = day.tempmax;
                string weather_tmin = day.tempmin;
                string weather_desc = day.description;

                Console.WriteLine(weather_date + weather_tmax + weather_tmin + weather_desc);
                f1.WeatherDateValue.Text = weather_date;
                f1.TemperatureMinValue.Text  = weather_tmin;
                f1.TemperatureMaxValue.Text = weather_tmax;
                f1.DescriptionValue.Text = weather_desc;
            }
        }
    }
}
