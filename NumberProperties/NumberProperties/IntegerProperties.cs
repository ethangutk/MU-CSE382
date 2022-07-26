using System;

namespace NumberProperties {
	public class IntegerProperties {
		public static bool IsEven(int N) {
			return N % 2 == 0;
		}
		public static bool IsOdd(int N) {
			return !IsEven(N);
		}
		public static bool IsPrime(int N) {
			if (N <= 1)
				return false;
			if (N == 2)
				return true;
			if (N % 2 == 0)
				return false;
			int lastDiv = (int)Math.Sqrt(N);
			for (int div = 3; div <= lastDiv; div += 2) {
				if (N % div == 0) {
					return false;
				}
			}
			return true;
		}
	}
}