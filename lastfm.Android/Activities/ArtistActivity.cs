using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Nfc;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using lastfm.Android;
using lastfm.Android.Activities;
using lastfm.Android.Fragments;
using lastfm.DL;
using lastfmAndroidFragments;
using Newtonsoft.Json;
using RestSharp.Deserializers;
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
        private Bitmap _imageBitmap = null;
        private Bitmap _albumBitmap = null;
        private Artist _artist;
        private List<Track> _topTracks;
        private List<Album> _topAlbums; 

        protected override void OnCreate(Bundle bundle)
        {
            //SetTheme(Resource.Style.Theme_Sherlock_Light);
            SetTheme(Resource.Style.Theme_Example);
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

            var jsonArtist = Intent.GetStringExtra("Artist");
            _artist = JsonConvert.DeserializeObject<Artist>(jsonArtist);
            var jsonTopTracks = Intent.GetStringExtra("TopTracks");
            _topTracks = JsonConvert.DeserializeObject<TopTracks>(jsonTopTracks);
            var jsonTopAlbums = Intent.GetStringExtra("TopAlbums");
            _topAlbums = JsonConvert.DeserializeObject<TopAlbums>(jsonTopAlbums);

            _bitmapExtension = new BitmapExtension();
            try
            {
                _imageBitmap = _bitmapExtension.GetImageBitmapFromUrl(_artist.GetImageUrlOfSize("large"));
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

            var tab3 = Sherlock.ActionBar.NewTab();
            tab3.SetText("Top 15 Tracks");
            tab3.SetTabListener(this);

            var tab4 = Sherlock.ActionBar.NewTab();
            tab4.SetText("Top 5 Albums");
            tab4.SetTabListener(this);

            Sherlock.ActionBar.AddTab(tab1);
            Sherlock.ActionBar.AddTab(tab2);
            Sherlock.ActionBar.AddTab(tab3);
            Sherlock.ActionBar.AddTab(tab4);
        }


        public Artist GetArtist()
        {
            return _artist;
        }

        public Bitmap GetArtistBitmap()
        {
            return _imageBitmap;
        }

        public List<Track> GetTop15Tracks()
        {
            return _topTracks.Select(x => new Track()
            {
                Name = x.Name,
                PlayCount = x.PlayCount
            }).ToList();
        }

        public List<Album> GetTop5Albums()
        {
            return _topAlbums.Select(x => new Album()
            {
                Name = x.Name,
                PlayCount = x.PlayCount,
                Image = x.Image,
                ImageUrl = x.ImageUrl
            }).ToList();
        }

        public List<Artist> GetSimiliarArtists()
        {
            return _artist.Similar;
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