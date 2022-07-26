using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyService {
	public interface IPlatformSpecificCode {
		string Platform();
	}
}
