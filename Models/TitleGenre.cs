using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class TitleGenre
    {
        public string Genre { get; set; }
        public string Tconst { get; set; }

        public virtual TitleBasics TconstNavigation { get; set; }
    }
}
