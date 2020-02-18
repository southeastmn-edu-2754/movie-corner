using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class ArtistCategory
    {
        public ArtistCategory()
        {
            TitlePrincipals = new HashSet<TitlePrincipals>();
        }

        public string Category { get; set; }

        public virtual ICollection<TitlePrincipals> TitlePrincipals { get; set; }
    }
}
