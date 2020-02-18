using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class NameBasics
    {
        public NameBasics()
        {
            TitlePrincipals = new HashSet<TitlePrincipals>();
        }

        public string Nconst { get; set; }
        public string PrimaryName { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public string PrimaryProfession { get; set; }
        public string KnownForTitles { get; set; }

        public virtual ICollection<TitlePrincipals> TitlePrincipals { get; set; }
    }
}
