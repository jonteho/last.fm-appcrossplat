using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using lastfm.Android;
using lastfm.Android.Activities;
using lastfm.Android.Adapters;
using lastfm.DL;
using lastfmAndroidActivities;
using Newtonsoft.Json;
using Xamarin.ActionbarSherlockBinding.App;
using lastfm.DL;
using lastfmAndroidActivities;

namespace lastfmAndroidFragments
{
    public class FragmentTopAlbums : ListFragment
    {
        private ArtistActivity _artistActivity;
        private List<Album> _topAlbums; 

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            _artistActivity = (ArtistActivity)this.Activity;
            _topAlbums = _artistActivity.GetTop5Albums();
            this.ListAdapter = new CustomListAdapter2(this.Activity, _topAlbums);
        }
    }
}