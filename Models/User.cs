using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class User
    {
        public User()
        {
            WatchlistTitles = new HashSet<WatchlistTitles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<WatchlistTitles> WatchlistTitles { get; set; }
    }
}
