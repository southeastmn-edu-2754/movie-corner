using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MovieCorner.Models;

namespace MovieCorner.Data
{
    public class DbInitializer
    {
        public static void Initialize(MoviesContext context)
        {
            context.Database.EnsureCreated();

            // Check for previously populated User table
            if (!context.User.Any())
            {
                var users = new User[] 
                {
                    new User { UserName = "Jason.Smith",        FullName = "Jason Smith",       Password = "", Created = DateTime.Now },
                    new User { UserName = "Molly.Johnson",      FullName = "Molly Johnson",     Password = "", Created = DateTime.Now },
                    new User { UserName = "Benjamin.Thompson",  FullName = "Benjamin Thompson", Password = "", Created = DateTime.Now },
                    new User { UserName = "Ashley.Bates",       FullName = "Ashley Bates",      Password = "", Created = DateTime.Now },
                    new User { UserName = "Jillian.Sorenson",   FullName = "Jillian Sorenson",  Password = "", Created = DateTime.Now },

                    new User { UserName = "Johnathon.Bourne",   FullName = "Johnathon Bourne",  Password = "", Created = DateTime.Now },
                    new User { UserName = "Maddy.Peters",       FullName = "Maddy Peters",      Password = "", Created = DateTime.Now },
                    new User { UserName = "Dylan.Williams",     FullName = "Dylan Williams",    Password = "", Created = DateTime.Now },
                    new User { UserName = "Emma.Jones",         FullName = "Emma Jones",        Password = "", Created = DateTime.Now },
                    new User { UserName = "Joshua.Miller",      FullName = "Joshua Miller",     Password = "", Created = DateTime.Now },

                    new User { UserName = "Olivia.Craig",       FullName = "Olivia Craig",      Password = "", Created = DateTime.Now },
                    new User { UserName = "Lucas.Brown",        FullName = "Lucas Brown",       Password = "", Created = DateTime.Now },
                    new User { UserName = "Sophie.Wilson",      FullName = "Sophie Wilson",     Password = "", Created = DateTime.Now },
                    new User { UserName = "Mason.Thomas",       FullName = "Mason Thomas",      Password = "", Created = DateTime.Now },
                    new User { UserName = "Evelyn.White",       FullName = "Evelyn White",      Password = "", Created = DateTime.Now },

                    new User { UserName = "Jacob.Harris",       FullName = "Jacob Harris",      Password = "", Created = DateTime.Now },
                    new User { UserName = "Emily.Clark",        FullName = "Emily Clark",       Password = "", Created = DateTime.Now },
                    new User { UserName = "Daniel.Lee",         FullName = "Daniel Lee",        Password = "", Created = DateTime.Now },
                    new User { UserName = "Elizabeth.Hall",     FullName = "Elizabeth Hall",    Password = "", Created = DateTime.Now },
                    new User { UserName = "Henry.King",         FullName = "Henry King",        Password = "", Created = DateTime.Now }
                };
                foreach (User u in users) 
                {
                    context.User.Add(u);
                }
                context.SaveChanges();
            }

            // Check for previously populated Permission table
            if (!context.Permission.Any())
            {
                var permissions = new Permission[] 
                {
                   new Permission { PermissionName = "Admin"},
                   new Permission { PermissionName = "Owner"},
                   new Permission { PermissionName = "Write"},
                   new Permission { PermissionName = "Read"},
                   new Permission { PermissionName = "None"}
                };
                foreach (Permission p in permissions) 
                {
                    context.Permission.Add(p);
                }
                context.SaveChanges();
            }
        }
    }
}