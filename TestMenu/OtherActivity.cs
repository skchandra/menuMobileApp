
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

namespace TestMenu
{
	[Activity (Label = "TestMenu", Icon = "@drawable/icon")]	
	public class OtherActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			RequestWindowFeature (WindowFeatures.ActionBar);
			SetContentView (Resource.Layout.otherLayout);
			ActionBar.SetTitle(Resource.String.app_name);
			ActionBar.SetSubtitle(Resource.String.other);
			ActionBar.SetHomeButtonEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
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
