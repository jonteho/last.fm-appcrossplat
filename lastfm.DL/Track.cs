using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfm.DL
{
    public class Track
    {
        public string Name { get; set; }
        public int PlayCount { get; set; }
        public string Url { get; set; }

        public string Heading {
            get { return Name; }
            set { value = Name; } }

        public string SubHeading {
            get { return PlayCount.ToString(); }
            set { value = PlayCount.ToString(); } }
    }
}
