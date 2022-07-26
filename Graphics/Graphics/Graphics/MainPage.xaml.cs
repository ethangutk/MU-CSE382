using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Diagnostics;

namespace Graphics {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		Stopwatch stopwatch = new Stopwatch();
		bool pageIsActive;
		SKCanvas canvas;
		SKImageInfo info;
		SKSurface surface;

		Color color = Color.Red;

		public MainPage() {
			InitializeComponent();
		}
		protected async override void OnAppearing() {
			base.OnAppearing();
			pageIsActive = true;
		}
		protected override void OnDisappearing() {
			base.OnDisappearing();
			pageIsActive = false;
		}
        private void view0_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
			SKImageInfo info = args.Info;
			SKSurface surface = args.Surface;
			canvas = surface.Canvas;
			canvas.Clear();
			SKPaint paint = new SKPaint
			{
				Style = SKPaintStyle.Fill,
				Color = color.ToSKColor(),
				StrokeWidth = 3,
			};

			canvas.DrawRect(info.Width / 4, 0, 50, 300, paint);
			canvas.DrawRect(info.Width / 4 * 3, 0, 50, 300, paint);
		}

        private void entry1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
			Entry b = (Entry)sender;
			SKPaint paint = new SKPaint
			{
				Style = SKPaintStyle.Fill,
				Color = color.ToSKColor(),
				StrokeWidth = 3,
			};

			canvas.DrawRect(info.Width / 4, 0, 50, Int32.Parse(b.Text), paint);
		}

        private void entry2_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
			Button b = (Button)sender;
			SKPaint paint = new SKPaint
			{
				Style = SKPaintStyle.Fill,
				Color = color.ToSKColor(),
				StrokeWidth = 3,
			};
			canvas.DrawRect(info.Width / 4 * 3, 0, 50, Int32.Parse(b.Text), paint);
		}
    }
}
