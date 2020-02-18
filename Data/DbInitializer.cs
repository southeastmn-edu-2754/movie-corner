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
            if (!context.TitleGenre.Any())
            {

            }
        }
    }
}