using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using lastfm.Android;
using lastfm.Android.Activities;
using lastfm.Android.Fragments;
using lastfm.DL;
using Newtonsoft.Json;
using Xamarin.ActionbarSherlockBinding.App;
using Xamarin.ActionbarSherlockBinding.Views;
using ActionBar = Xamarin.ActionbarSherlockBinding.App.ActionBar;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

namespace lastfmAndroidActivities
{
    [Activity(Label = "last.fm", Icon = "@drawable/lastfm", ParentActivity = typeof(StartFragmentActivity))]
    public class ArtistActivity : SherlockFragmentActivity, ViewPager.IOnPageChangeListener, ActionBar.ITabListener
    {
        private ViewPager _viewPager;
        private ArtistPagerAdapter _pageAdapter;
        private BitmapExtension _bitmapExtension;
        Bitmap imageBitmap = null;
        private Artist artist;

        protected override void OnCreate(Bundle bundle)
        {
            SetTheme(Resource.Style.Theme_Sherlock_Light);
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.IndeterminateProgress);
            SetSupportProgressBarIndeterminateVisibility(false);
            Sherlock.ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.Main);
            // Show tabs
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            
            // attach adapter to the viewpager
            _pageAdapter = new ArtistPagerAdapter(SupportFragmentManager);
            _viewPager = FindViewById<ViewPager>(Resource.Id.myViewPager);
            _viewPager.Adapter = _pageAdapter;
            _viewPager.SetOnPageChangeListener(this);
            // startindex
            _viewPager.SetCurrentItem(0, true);

            var json = Intent.GetStringExtra("Artist");
            artist = JsonConvert.DeserializeObject<Artist>(json);

            _bitmapExtension = new BitmapExtension();
            try
            {
                imageBitmap = _bitmapExtension.GetImageBitmapFromUrl(artist.GetImageUrlOfSize("large"));
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Error: " + ex.Message, ToastLength.Short).Show();
            }

            //TABS
            var tab1 = Sherlock.ActionBar.NewTab();
            tab1.SetText("Artist");
            tab1.SetTabListener(this);
            var tab2 = Sherlock.ActionBar.NewTab();
            tab2.SetText("Similar Artists");
            tab2.SetTabListener(this);

            Sherlock.ActionBar.AddTab(tab1);
            Sherlock.ActionBar.AddTab(tab2);
        }

        public Artist GetArtist()
        {
            return artist;
        }

        public Bitmap GetArtistBitmap()
        {
            return imageBitmap;
        }

        public List<Artist> GetSimiliarArtists()
        {
            return artist.Similar;
        }

        public override bool OnOptionsItemSelected(Xamarin.ActionbarSherlockBinding.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    NavUtils.NavigateUpFromSameTask(this);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public void OnPageScrollStateChanged(int state)
        {
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }

        public void OnPageSelected(int position)
        {
            Sherlock.ActionBar.SetSelectedNavigationItem(position);
        }

        public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }

        public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }

        public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }
    }
}