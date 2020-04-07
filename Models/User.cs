using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class User
    {
        public User()
        {
            UserTitleRating = new HashSet<UserTitleRating>();
            UserWatchlists = new HashSet<UserWatchlists>();
            WatchlistTitles = new HashSet<WatchlistTitles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<UserTitleRating> UserTitleRating { get; set; }
        public virtual ICollection<UserWatchlists> UserWatchlists { get; set; }
        public virtual ICollection<WatchlistTitles> WatchlistTitles { get; set; }
    }
}
