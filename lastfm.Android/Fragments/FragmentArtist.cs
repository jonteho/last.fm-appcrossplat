using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using lastfm.Android.Activities;
using lastfm.DL;
using lastfmAndroidActivities;
using Newtonsoft.Json;
using Xamarin.ActionbarSherlockBinding.App;

namespace lastfm.Android.Fragments
{
    public class FragmentArtist : Fragment
    {
        private View _view;
        private Artist _artist;
        private Bitmap _imageBitmap = null;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.fragment_artist, container, false);
            return _view;
        }

        private void SetTextLabels()
        {
            _view.FindViewById<TextView>(Resource.Id.labelSummary).Text = "Summary";
            _view.FindViewById<TextView>(Resource.Id.labelYearFormed).Text = "Year formed";
            _view.FindViewById<TextView>(Resource.Id.labelUrl).Text = "Url";
            _view.FindViewById<TextView>(Resource.Id.labelPublished).Text = "Published";
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            var artistActivity = (ArtistActivity)this.Activity;
            _artist = artistActivity.GetArtist();
            _imageBitmap = artistActivity.GetArtistBitmap();

            SetTextLabels();

            _view.FindViewById<ImageView>(Resource.Id.imageArtist).SetImageBitmap(_imageBitmap);
            _view.FindViewById<TextView>(Resource.Id.textName).Text = _artist.Name;
            _view.FindViewById<TextView>(Resource.Id.textSummary).Text = _artist.Bio.Summary;
            _view.FindViewById<TextView>(Resource.Id.textYearFormed).Text = _artist.Bio.YearFormed.ToString();
            _view.FindViewById<TextView>(Resource.Id.textUrl).Text = _artist.Url;
            _view.FindViewById<TextView>(Resource.Id.textPublished).Text = _artist.Bio.Published.ToShortDateString();
        }
    }
}