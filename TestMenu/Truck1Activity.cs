
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
	public class Truck1Activity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RequestWindowFeature (WindowFeatures.ActionBar);
			SetContentView (Resource.Layout.truck1);
			ActionBar.SetTitle(Resource.String.app_name);
			ActionBar.SetSubtitle(Resource.String.truck1);
			ActionBar.SetHomeButtonEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
					
			//enable navigation mode to support tab layout
			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab ("What's Popular", Resource.Drawable.Icon,  new PopFragment());
			AddTab ("Order", Resource.Drawable.Icon,  new MenuFragment());
		}

		public List<FragmentModel> GetList()
		{
			List<FragmentModel> _lstFragmentDemo = new List<FragmentModel> ();

			_lstFragmentDemo.Add (new FragmentModel () {
				Name = "Food1", Designation = "Yum"
			});

			_lstFragmentDemo.Add (new FragmentModel () {
				Name = "Food2", Designation = "Eh"
			});

			_lstFragmentDemo.Add (new FragmentModel () {
				Name = "Food3", Designation = "No"
			});

			_lstFragmentDemo.Add (new FragmentModel () {
				Name = "Food4", Designation = "Bomb.com"
			});
			return _lstFragmentDemo;
		}

		void AddTab (string tabText, int iconResourceId, Fragment fragment)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);

			// must set event handler for replacing tabs tab
			tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e) {
				e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
			};

			this.ActionBar.AddTab (tab);
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

	class MenuFragment: ListFragment
	{           
		Truck1Activity act = new Truck1Activity();

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			List<FragmentModel> calledList = act.GetList();

			var view = inflater.Inflate(Resource.Layout.truck1, container, false);
			this.ListAdapter = new ListVwAdapter (this.Activity, calledList);
			return view;
		}


		public override void OnListItemClick(ListView l, View v, int index, long id)
		{
			// We can display everything in place with fragments.
			// Have the list highlight this item and show the data.
			ListView.SetItemChecked(index, true);
		}
	}

	class PopFragment: Fragment
	{            
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.truck1, container, false);
			var sampleTextView = view.FindViewById<TextView> (Resource.Id.textView);             
			sampleTextView.Text = "These are the most popular items";

			return view;
		}
	}
}

