using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class UserTitleRating
    {
        public int UserId { get; set; }
        public string Tconst { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }

        public virtual TitleBasics TconstNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
