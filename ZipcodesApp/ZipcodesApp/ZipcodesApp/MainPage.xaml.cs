using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;

/*
 * 
 *  {
 *      "country abbreviation": "US",
 *      "places": [
*           {
*               "place name": "Belmont",
*               "longitude": "-71.4594",
*               "post code": "02178",
*               "latitude": "42.4464"
*           },
*           {
*              "place name": "Belmont",
*              "longitude": "-71.2044",
*              "post code": "02478",
*              "latitude": "42.4128"
*         }],
 *      "country": "United States",
 *      "place name": "Belmont",
 *      "state": "Massachusetts",
 *      "state abbreviation": "MA"
 *  }
 */
namespace ZipcodesApp
{
    public partial class MainPage : ContentPage
    {
        //Variables
        public HttpClient client = new HttpClient();



        public MainPage()
        {
            InitializeComponent();
        }




        public string CreateZipQuery()
        {
            if (cityEntry.Text != null && stateEntry.Text != null)
            {
                string city = cityEntry.Text.ToLower().Trim();
                string state = stateEntry.Text.ToLower().Trim();
                return ("https://api.zippopotam.us/us/" + state + "/" + city);
            }
            else
            {
                return ("creating query failed");
            }
        }




        public async Task<string> GetResults()
        {
            try
            {
                string query = CreateZipQuery();
                var response = await client.GetAsync(query);


                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                } else
                {
                    return "failure";
                }

            }
            catch (Exception) { return "failure"; }
        }




        private void lookupButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Performing lookup");
            Task<string> results = GetResults();
            Console.WriteLine("Waiting...");
            results.Wait();
            Console.WriteLine("Task finished, posting list...");
            CityData timeZoneData = JsonConvert.DeserializeObject<CityData>(results.Result);
            Console.WriteLine("Posting list");
            resultsList.ItemsSource = timeZoneData.Places.ToList<Place>();
        }
    }
}
