using System;
using System.Collections.Generic;

namespace MovieCorner.Models
{
    public partial class Permission
    {
        public Permission()
        {
            UserWatchlists = new HashSet<UserWatchlists>();
        }

        public int PermissionId { get; set; }
        public string PermissionName { get; set; }

        public virtual ICollection<UserWatchlists> UserWatchlists { get; set; }
    }
}
