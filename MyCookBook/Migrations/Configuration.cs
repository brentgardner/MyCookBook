using MyCookBook.Models;

namespace MyCookBook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyCookBook.Models.RecipesDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
           
        }

        protected override void Seed(MyCookBook.Models.RecipesDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(
                c => c.Name, 
                new Category { Name = "Appetizer"},
                new Category { Name = "Soup"},
                new Category { Name = "Salad"},
                new Category { Name = "Dip"}, 
                new Category { Name = "Snack"},
                new Category { Name = "Pasta"},
                new Category { Name = "Baked Good"},
                new Category { Name = "Stir Fry"}
             );

            context.MealTypes.AddOrUpdate(
                m => m.Name,
                new MealType { Name = "Breakfast"},
                new MealType { Name = "Lunch"},
                new MealType { Name = "Dinner"},
                new MealType { Name = "Snack"}
            );
        }
    }
}
