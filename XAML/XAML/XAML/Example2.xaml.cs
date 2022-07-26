using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAML {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum |
					AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property |
					AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
	public sealed class PreserveAttribute : Attribute {
		public bool AllMembers;
		public bool Conditional;
	}

	[Preserve(AllMembers = true)]
	public class School {
		public string Name { get; set; }
		public string WebsiteURL { get; set; }
		public Color SchoolColor { get; set; }
		public Color School2ndColor { get; set; }
	}

	public partial class Example2 : ContentPage {
		public IList<School> Schools { get; private set; }

		public List<School> schoolList = new List<School> {
				new School { Name="Miami", WebsiteURL="www.miamioh.edu", SchoolColor=Color.Red, School2ndColor= Color.Black},
				new School { Name="Ohio State", WebsiteURL="www.osu.edu", SchoolColor=Color.Red, School2ndColor=Color.Gray},
				new School { Name="U. Cincinnati", WebsiteURL="www.uc.edu", SchoolColor=Color.Red, School2ndColor=Color.Black },
				new School { Name="Ohio", WebsiteURL="www.ohio.edu", SchoolColor=Color.Green, School2ndColor=Color.Gold },
			};

		public Example2() {
			InitializeComponent();
			theList.ItemsSource = schoolList;
		}
	}
}