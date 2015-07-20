
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestMenu
{
	[Activity (Label = "Food Trucks", Icon = "@drawable/icon")]			
	public class FoodTrucksActivity : ListActivity
	{
		string[] items;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RequestWindowFeature (WindowFeatures.ActionBar);
			SetContentView (Resource.Layout.foodTrucksLayout);
			ActionBar.SetTitle(Resource.String.app_name);
			ActionBar.SetSubtitle(Resource.String.foodTrucks);
			ActionBar.SetHomeButtonEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetDisplayHomeAsUpEnabled (true);

			items = new string[] { "Truck1", "Truck2", "Truck3", "Truck4", "Truck5", "Truck6", "Truck7", "Truck8", "Truck9", "Truck10", "Truck11", "Truck12", "Truck13", "Truck14", "Truck15" };
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
		}
			
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			string str = "TestMenu." + items[position] + "Activity";  
			var actType = Type.GetType (str);
			var intentPlace = new Intent(this, actType);
			StartActivity(intentPlace);
		}
	
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					Finish();
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}
	}
}

