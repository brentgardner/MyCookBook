using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyCookBook.Models
{
    public class RecipesDataContext : DbContext
    {
        public RecipesDataContext()
            : base("RecipesConnection")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<MealType> MealTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}