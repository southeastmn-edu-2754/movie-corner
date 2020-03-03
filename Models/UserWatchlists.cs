using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class UserWatchlists
    {
        public int UserId { get; set; }
        public int WatchlistId { get; set; }
        public int PermissionId { get; set; }
        public DateTime Created { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual User User { get; set; }
        public virtual Watchlist Watchlist { get; set; }
    }
}
