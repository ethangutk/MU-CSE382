using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestConsole.Helpers;

namespace RestConsole
{
    public class RestExample
    {
        /*
         * Documentation on weather API: https://openweathermap.org/current
         * You will need to get your own keys:
         * https://home.openweathermap.org/users/sign_up
         * https://timezonedb.com/register
         */

        public static string TimeZoneEndPoint = "http://api.timezonedb.com/v2.1/list-time-zone";
        // https://api.timezonedb.com/v2.1/list-time-zone?key=API_KEY_GOES_HERE&zone=America/Denver&format=json
        public static string TimeZoneAPIKey = Secrets.APIKEY;
        public HttpClient client = new HttpClient();
        public string CreateWeatherQuery(string zone)
        {
            string requestUri = TimeZoneEndPoint;
            requestUri += $"?zone=America/{zone}";
            requestUri += $"&key={TimeZoneAPIKey}";
            requestUri += $"&format=json";
            return requestUri;
        }
        public async Task<string> GetTimeZoneQuery()
        {
            Console.Write("Please enter a big US city: ");
            string city = Console.ReadLine().Trim();
            string query = CreateWeatherQuery(city);
            string result = null;

            try
            {
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
                Environment.Exit(0);
            }

            return result;
        }

        public void ProcessTimeQuery()
        {
            string response = GetTimeZoneQuery().Result;
            TimeData timeZoneData = JsonConvert.DeserializeObject<TimeData>(response);
            Console.WriteLine("Using TimeData class.");
            Console.WriteLine("Status: " + timeZoneData.Status + "\tMessage" + timeZoneData.Message);
            Console.WriteLine("Country code: " + timeZoneData.Zone[0].countryCode);
            Console.WriteLine("Country name: " + timeZoneData.Zone[0].countryName);
            Console.WriteLine("GMT Offset: " + timeZoneData.Zone[0].gmtOffset);
            Console.WriteLine("Zone Name: " + timeZoneData.Zone[0].zoneName);

            // Console.WriteLine("\n\n\nResponse:  \n" + response + "\n\n\n");

        }
        public static void Main(string[] args)
        {
            RestExample rest = new RestExample();
            rest.ProcessTimeQuery();
        }
    }
}
