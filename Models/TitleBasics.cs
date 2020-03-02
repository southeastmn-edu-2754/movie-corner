using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class TitleBasics
    {
        public TitleBasics()
        {
            TitleAkas = new HashSet<TitleAkas>();
            TitleGenre = new HashSet<TitleGenre>();
            TitlePrincipals = new HashSet<TitlePrincipals>();
            WatchlistTitles = new HashSet<WatchlistTitles>();
        }

        public string Tconst { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public string IsAdult { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string RuntimeMinutes { get; set; }
        public string Genres { get; set; }

        public virtual UserTitleRating UserTitlerating { get; set; }
        public virtual ICollection<TitleAkas> TitleAkas { get; set; }
        public virtual ICollection<TitleGenre> TitleGenre { get; set; }
        public virtual ICollection<TitlePrincipals> TitlePrincipals { get; set; }
        public virtual ICollection<WatchlistTitles> WatchlistTitles { get; set; }
    }
}
