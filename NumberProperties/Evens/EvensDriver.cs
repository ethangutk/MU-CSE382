using System;

using NumberProperties;

namespace Evens {
	public class EvensDriver {
		public static void Main(String[] args) {
			Console.WriteLine("Enter positive integers");
			String[] toks = Console.ReadLine().Split(' ');
			foreach (String tok in toks) {
				int v = Int32.Parse(tok);
				Console.WriteLine("{0} is even {1}", v, IntegerProperties.IsEven(v));
			}
		}
	}
}