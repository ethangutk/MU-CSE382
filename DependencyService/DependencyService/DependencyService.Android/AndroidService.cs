using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(DependencyService.Droid.AndroidService))]
namespace DependencyService.Droid {
	public class AndroidService : DependencyService.IPlatformSpecificCode {
		string IPlatformSpecificCode.Platform() {
			return "Android";
		}
	}
}