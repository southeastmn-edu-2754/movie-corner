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

            // Check for previously populated TitleGenre table
            if (!context.User.Any())
            {
                var users = new User[] 
                {
                    new User { UserName = "Jason.Smith",        FullName = "Jason Smith" },
                    new User { UserName = "Molly.Johnson",      FullName = "Molly Johnson" },
                    new User { UserName = "Benjamin.Thompson",  FullName = "Benjamin Thompson" },
                    new User { UserName = "Ashley.Bates",       FullName = "Ashley Bates" },
                    new User { UserName = "Jillian.Sorenson",   FullName = "Jillian Sorenson" },

                    new User { UserName = "Johnathon.Bourne",   FullName = "Johnathon Bourne" },
                    new User { UserName = "Maddy.Peters",       FullName = "Maddy Peters" },
                    new User { UserName = "Dylan.Williams",     FullName = "Dylan Williams" },
                    new User { UserName = "Emma.Jones",         FullName = "Emma Jones" },
                    new User { UserName = "Joshua.Miller",      FullName = "Joshua Miller" },

                    new User { UserName = "Olivia.Craig",       FullName = "Olivia Craig" },
                    new User { UserName = "Lucas.Brown",        FullName = "Lucas Brown" },
                    new User { UserName = "Sophie.Wilson",      FullName = "Sophie Wilson" },
                    new User { UserName = "Mason.Thomas",       FullName = "Mason Thomas" },
                    new User { UserName = "Evelyn.White",       FullName = "Evelyn White" },

                    new User { UserName = "Jacob.Harris",       FullName = "Jacob Harris" },
                    new User { UserName = "Emily.Clark",        FullName = "Emily Clark" },
                    new User { UserName = "Daniel.Lee",         FullName = "Daniel Lee" },
                    new User { UserName = "Elizabeth.Hall",     FullName = "Elizabeth Hall" },
                    new User { UserName = "Henry.King",         FullName = "Henry King" }
                };
                foreach (User u in users) 
                {
                    context.User.Add(u);
                }
                context.SaveChanges();
            }
        }
    }
}