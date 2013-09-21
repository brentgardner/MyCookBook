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
            : base("DefaultConnection")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<MealType> MealTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}