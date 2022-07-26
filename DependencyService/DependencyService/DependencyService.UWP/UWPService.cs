using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(DependencyService.UWP.UWPService))]
namespace DependencyService.UWP {
	public class UWPService : DependencyService.IPlatformSpecificCode {
		string IPlatformSpecificCode.Platform() {
			return "UWP";
		}
	}
}
