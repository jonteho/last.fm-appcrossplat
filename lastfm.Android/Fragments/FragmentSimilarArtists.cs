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
using lastfm.DL;
using lastfmAndroidActivities;
using Newtonsoft.Json;
using Xamarin.ActionbarSherlockBinding.App;

namespace lastfmAndroidFragments
{
    public class FragmentSimilarArtists : ListFragment
    {
        private List<Artist> _similarArtists;
        private View _view;
        private ArtistRepository _repository;
        private ArtistActivity _artistActivity;

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            _repository = new ArtistRepository();
            _artistActivity = (ArtistActivity)this.Activity;
            _similarArtists = _artistActivity.GetSimiliarArtists();

            string[] similarArtists = _similarArtists.Select(x => x.Name).ToArray();
            
            this.ListAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, similarArtists);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            ListView.SetItemChecked(position, true);

            l.ItemClick += async (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                string selectedFromList = l.GetItemAtPosition(e.Position).ToString();
                try
                {
                    _artistActivity.SetSupportProgressBarIndeterminateVisibility(true);
                    var artistName = await _repository.FindArtistAsync(selectedFromList);
                    var artist = await _repository.SearchArtistAsync(artistName);
                    // Serialisera objektet och skicka det till artistactivity...
                    var json = JsonConvert.SerializeObject(artist);
                    var artistActivity = new Intent(this.Activity, typeof(ArtistActivity));
                    artistActivity.PutExtra("Artist", json);
                    StartActivity(artistActivity);
                    _artistActivity.SetSupportProgressBarIndeterminateVisibility(false);
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this.Activity, "Error: " + ex.Message, ToastLength.Short).Show();
                }
            };
        }

    }
}