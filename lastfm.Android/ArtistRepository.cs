using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using lastfm.DL;
using Newtonsoft.Json;
using Org.Apache.Http.Client.Params;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Extensions;
using RestSharp.Serializers;

namespace lastfm.Android
{
    public class ArtistRepository
    {
        private const string _clientUrl = "http://ws.audioscrobbler.com";
        private const string _apiKey = "e4391b80ca7ae69790d990527103f635";

        public async Task<string> FindArtistAsync(string query)
        {
            return await Task.Factory.StartNew(() =>
            {
                var client = new RestClient(_clientUrl);
                var request = new RestRequest("2.0/");
                request.AddParameter("method", "artist.search");
                request.AddParameter("artist", query);
                request.AddParameter("api_key", _apiKey);
                var response = client.Execute<Artist>(request);
                return response.Data.Name;
            });
        }

        public async Task<Artist> SearchArtistAsync(string query)
        {
            return await Task.Factory.StartNew(() =>
            {
                var client = new RestClient(_clientUrl);
                var request = new RestRequest("2.0/");
                request.AddParameter("method", "artist.getInfo");
                request.AddParameter("artist", query);
                request.AddParameter("api_key", _apiKey);
                var response = client.Execute<Artist>(request);
                return response.Data;
            });
        }

        public async Task<TopTracks> GetTopTracksAsync(string artist)
        {
            return await Task.Factory.StartNew(() =>
            {
                var client = new RestClient(_clientUrl);
                var request = new RestRequest("2.0/");
                request.AddParameter("method", "artist.gettoptracks");
                request.AddParameter("artist", artist);
                request.AddParameter("api_key", _apiKey);
                var response = client.Execute<TopTracks>(request);
                return response.Data;
            });
        }

        public async Task<TopAlbums> GetTopAlbumsAsync(string artist)
        {
            return await Task.Factory.StartNew(() =>
            {
                var client = new RestClient(_clientUrl);
                var request = new RestRequest("2.0/");
                request.AddParameter("method", "artist.gettopalbums");
                request.AddParameter("artist", artist);
                request.AddParameter("api_key", _apiKey);
                var response = client.Execute<TopAlbums>(request);
                return response.Data;
            });
        }

    }
}