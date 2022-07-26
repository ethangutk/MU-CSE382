using System;
using System.Collections.Generic;
using System.Text;
using APIKeys.Helpers;

namespace APIKeys {
	class Program {
		public static string MYAPIKEY = Secrets.APIKEY;

		static void Main(string[] args) {
			Console.WriteLine(MYAPIKEY);
		}
	}
}
