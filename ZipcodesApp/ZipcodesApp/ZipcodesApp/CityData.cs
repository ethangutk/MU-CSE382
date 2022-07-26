using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZipcodesApp
{

	public class CityData
	{
		[JsonProperty("country abbreviation")]
		public string CountryAbv { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("place name")]
		public string PlaceName { get; set; }

		[JsonProperty("state")]
		public string State { get; set; }

		[JsonProperty("state abbreviation")]
		public string StateAbv { get; set; }


		[JsonProperty("places")]
		public Place[] Places { get; set; }
	}




	public class Place
	{
		[JsonProperty("place name")]
		public string placeName { get; set; }


		[JsonProperty("longitude")]
		public string longitude { get; set; }


		[JsonProperty("latitude")]
		public string latitude { get; set; }


		[JsonProperty("post code")]
		public string postCode { get; set; }

        public override string ToString()
        {
			return (placeName + ", " + postCode + " (" + longitude + ", " + latitude + ")");
        }
    }
}
