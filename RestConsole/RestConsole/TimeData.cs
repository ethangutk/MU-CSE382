using Newtonsoft.Json;

namespace RestConsole
{
	/*		Example of a response:
	 * {
	 *		"status":"OK",
	 *		"message":"",
	 *		"zones":
	 *		[{
	 *			"countryCode":"US",
	 *			"countryName":"United States",
	 *			"zoneName":"America\/Denver",
	 *			"gmt":-21600,
	 *			"timestamp":1623432713
	 *		}]
	 *	}
	 */


	public class TimeData {
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("zones")]
		public Zone[] Zone { get; set; }
	}




	public class Zone
	{
		[JsonProperty("countryCode")]
		public string countryCode { get; set; }


		[JsonProperty("countryName")]
		public string countryName { get; set; }


		[JsonProperty("zoneName")]
		public string zoneName { get; set; }


		[JsonProperty("gmtOffset")]
		public string gmtOffset { get; set; }


		[JsonProperty("timeStamp")]
		public string timeStamp { get; set; }

	}
}
