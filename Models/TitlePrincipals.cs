using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class TitlePrincipals
    {
        public string Tconst { get; set; }
        public string Ordering { get; set; }
        public string Nconst { get; set; }
        public string Category { get; set; }
        public string Job { get; set; }
        public string Characters { get; set; }

        public virtual ArtistCategory CategoryNavigation { get; set; }
        public virtual NameBasics NconstNavigation { get; set; }
        public virtual TitleBasics TconstNavigation { get; set; }
    }
}
