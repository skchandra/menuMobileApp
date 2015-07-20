using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TestMenu
{
	[Activity (Label = "TestMenu", Icon = "@drawable/icon", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RequestWindowFeature (WindowFeatures.ActionBar);

			SetContentView (Resource.Layout.Main);
			ActionBar.NavigationMode = ActionBarNavigationMode.Standard;
			ActionBar.SetTitle(Resource.String.app_name);

			Button foodTruck = FindViewById<Button> (Resource.Id.foodTrucks);
			foodTruck.Click += (sender, e) => {
				var intentFood = new Intent (this, typeof(FoodTrucksActivity));
				StartActivity (intentFood);
			};

			Button restaurant = FindViewById<Button> (Resource.Id.restaurants);
			restaurant.Click += (sender, e) => {
				var intentRest = new Intent (this, typeof(RestaurantActivity));
				StartActivity (intentRest);
			};

			Button other = FindViewById<Button> (Resource.Id.other);
			other.Click += (sender, e) => {
				var intentOth = new Intent (this, typeof(OtherActivity));
				StartActivity (intentOth);
			};
		}
	}
}


