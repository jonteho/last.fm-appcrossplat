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
using lastfm.DL;

namespace lastfm.Android.Adapters
{
    public class CustomListAdapter : BaseAdapter<Track>
    {
        List<Track> items;
        Activity context;

        public CustomListAdapter(Activity context, List<Track> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.customListView, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = "Played " + item.SubHeading + " times";
            return view;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override Track this[int position]
        {
            get { return items[position]; }
        }
    }
}