
using System;
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
	public class ListVwAdapter: BaseAdapter<FragmentModel>
	{
		Activity _Context;
		List<FragmentModel> _lstFragments;

		public ListVwAdapter (Activity c, List<FragmentModel> lstFragments)
		{
			_Context = c;
			_lstFragments = lstFragments;

		}
		#region implemented abstract members of BaseAdapter
		public override long GetItemId (int position)
		{
			return position;
		}
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var item = this [position];

			if (convertView == null)
				convertView = _Context.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem2, parent, false);

			convertView.FindViewById<TextView> (Android.Resource.Id.Text1).Text = item.Name;
			convertView.FindViewById<TextView> (Android.Resource.Id.Text2).Text = item.Designation;

			return convertView;


		}
		public override int Count {
			get {
				return _lstFragments != null ? _lstFragments.Count : -1;
			}
		}
		#endregion
		#region implemented abstract members of BaseAdapter
		public override FragmentModel this [int index] {
			get {
				return _lstFragments != null ? _lstFragments[index] : null;
			}
		}
		#endregion
	}
}

