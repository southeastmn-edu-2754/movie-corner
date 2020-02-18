using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class Watchlist
    {
        public Watchlist()
        {
            WatchlistTitles = new HashSet<WatchlistTitles>();
        }

        public int WatchlistId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<WatchlistTitles> WatchlistTitles { get; set; }
    }
}
