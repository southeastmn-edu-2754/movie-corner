using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class UserTitleRating
    {
        public int RatingId { get; set; }
        public int Rating { get; set; }
        public string Tconst { get; set; }
        public DateTime RatingDate { get; set; }
        public int UserRatingId { get; set; }

        public virtual TitleBasics TconstNavigation { get; set; }
        public virtual User UserRating { get; set; }
    }
}
