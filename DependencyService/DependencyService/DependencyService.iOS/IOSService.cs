using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DependencyService.iOS.IOSService))]
namespace DependencyService.iOS {
	public class IOSService : DependencyService.IPlatformSpecificCode {
		string IPlatformSpecificCode.Platform() {
			return "iOS";
		}
	}
}