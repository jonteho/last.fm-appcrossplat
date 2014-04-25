using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using lastfm.Android.Fragments;
using lastfmAndroidActivities;
using Newtonsoft.Json;
using Xamarin.ActionbarSherlockBinding.App;
using Xamarin.ActionbarSherlockBinding.Views;
using IMenuItem = Xamarin.ActionbarSherlockBinding.Views.IMenuItem;
using SearchView = Xamarin.ActionbarSherlockBinding.Widget.SearchView;
using SherlockActionBar = Xamarin.ActionbarSherlockBinding.App.ActionBar;

namespace lastfm.Android.Activities
{
    [Activity(Label = "last.fm", Icon = "@drawable/lastfm")]
    public class StartFragmentActivity : SherlockFragmentActivity, SearchView.IOnQueryTextListener
    {
        private ArtistRepository _repository;
        
        protected override void OnCreate(Bundle bundle)
        {
            //SetTheme(Resource.Style.Theme_Sherlock_Light);
            SetTheme(Resource.Style.Theme_Example);
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.IndeterminateProgress);
            SetContentView(Resource.Layout.Start);
            SetSupportProgressBarIndeterminateVisibility(false);
        }

        protected override void OnResume()
        {
            base.OnResume();
            // Referenser i OnResume()
            _repository = new ArtistRepository();
        }

        public override bool OnCreateOptionsMenu(Xamarin.ActionbarSherlockBinding.Views.IMenu menu)
        {
            // Skapar en sökvy
            var searchView = new SearchView(SupportActionBar.ThemedContext)
            {
                QueryHint = "Search artist..."
            };
            searchView.SetOnQueryTextListener(this);

            menu.Add(1, 1, 1, "Search")
                .SetActionView(searchView)
                .SetIcon(Android.Resource.Drawable.abs__ic_search)
                .SetShowAsAction(MenuItem.ShowAsActionAlways | MenuItem.ShowAsActionCollapseActionView);
            var searchItemActionBar = menu.FindItem(1);

            searchView.QueryTextSubmit += async (sender, e) =>
            {
                searchItemActionBar.CollapseActionView();
                SetSupportProgressBarIndeterminateVisibility(true);
                searchView.ClearFocus();
                try
                {
                    var artistName = await _repository.FindArtistAsync(e.Query);
                    var artist = await _repository.SearchArtistAsync(artistName);
                    var topTracks = await _repository.GetTopTracksAsync(artist.Name);
                    var topAlbums = await _repository.GetTopAlbumsAsync(artist.Name);

                    // Serialisera objektet och skicka det till artistactivity...
                    var jsonArtist = JsonConvert.SerializeObject(artist);
                    var jsonTopTracks = JsonConvert.SerializeObject(topTracks.Take(15));
                    var jsonTopAlbums = JsonConvert.SerializeObject(topAlbums.Take(5));

                    var artistActivity = new Intent(this, typeof(ArtistActivity));

                    artistActivity.PutExtra("Artist", jsonArtist);
                    artistActivity.PutExtra("TopTracks", jsonTopTracks);
                    artistActivity.PutExtra("TopAlbums", jsonTopAlbums);

                    SetSupportProgressBarIndeterminateVisibility(false);
                    StartActivity(artistActivity);
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "Error: " + ex.Message, ToastLength.Short).Show();
                    SetSupportProgressBarIndeterminateVisibility(false);
                }
            };
            return true;
        }

        public bool OnQueryTextChange(string newText)
        {
            return false;
        }

        public bool OnQueryTextSubmit(string query)
        {
            return false;
        }
    }
}