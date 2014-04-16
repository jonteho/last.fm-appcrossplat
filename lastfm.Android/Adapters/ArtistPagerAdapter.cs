using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using lastfm.Android.Fragments;
using lastfmAndroidFragments;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace lastfm.Android
{
    public class ArtistPagerAdapter : FragmentPagerAdapter
    {
        private List<Fragment> fragments;
        int fragmentCount;

        public ArtistPagerAdapter(FragmentManager fm)
            : base(fm)
        {
            this.fragments = new List<Fragment>();
            fragments.Add(new FragmentArtist());
            fragments.Add(new FragmentSimilarArtists());
            fragmentCount = fragments.Count;
        }

        public override int Count
        {
            get { return fragmentCount; }
        }

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }
    }
}