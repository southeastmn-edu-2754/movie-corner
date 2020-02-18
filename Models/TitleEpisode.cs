using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class TitleEpisode
    {
        public string Tconst { get; set; }
        public string ParentTconst { get; set; }
        public string SeasonNumber { get; set; }
        public string EpisodeNumber { get; set; }
    }
}
