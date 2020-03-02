using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class UserWatchlists
    {
        public int UserwatchlistId { get; set; }
        public int Permission { get; set; }
        public DateTime WatchlistCreated { get; set; }
        public int WatchlistownerId { get; set; }

        public virtual Permission PermissionNavigation { get; set; }
        public virtual User Watchlistowner { get; set; }
        public virtual Watchlist WatchlistownerNavigation { get; set; }
    }
}
