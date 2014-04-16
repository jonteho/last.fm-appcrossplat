using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lastfm.DL
{
    public class Artist
    {
        public string Name { get; set; }
        public string Mbid { get; set; }
        public string Url { get; set; }
        public Biography Bio { get; set; }
        public ArtistImageCollection Image { get; set; }
        public List<Artist> Similar { get; set; } 

        public string GetImageUrlOfSize(string size)
        {
            return Image.Where(x => x.Size == size).Select(x => x.Value).First();
        }
    }
}
