using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCookBook.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }

        [MaxLength(150)]
        [Required]
        public String Name { get; set; }

        [MaxLength(255)]
        public String Description { get; set; }

        [Display(Name = "Prep Time")]
        public int PrepTime { get; set; }

        [Display(Name = "Cook Time")]
        public int CookTime { get; set; }

        public String Instructions { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int MealTypeId { get; set; }

        public UserProfile User { get; set; }

        public Category Category { get; set; }

        public MealType MealType { get; set; }


    }
}