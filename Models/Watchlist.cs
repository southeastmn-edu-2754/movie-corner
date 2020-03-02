using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class Watchlist
    {
        public Watchlist()
        {
            UserWatchlists = new HashSet<UserWatchlists>();
            WatchlistTitles = new HashSet<WatchlistTitles>();
        }

        public int WatchlistId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public int Permission { get; set; }

        public virtual Permission PermissionNavigation { get; set; }
        public virtual ICollection<UserWatchlists> UserWatchlists { get; set; }
        public virtual ICollection<WatchlistTitles> WatchlistTitles { get; set; }
    }
}
