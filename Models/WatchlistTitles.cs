using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class WatchlistTitles
    {
        public int WatchlistId { get; set; }
        public string Tconst { get; set; }
        public short SequenceNum { get; set; }
        public DateTime Created { get; set; }
        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }
        public virtual TitleBasics TconstNavigation { get; set; }
        public virtual Watchlist Watchlist { get; set; }
    }
}
