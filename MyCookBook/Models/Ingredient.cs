using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCookBook.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }

        [MaxLength(75)]
        [Required]
        public String Name { get; set; }
        
        [Required]
        public double Measurment { get; set; }

        [Required]
        public int UnitId { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public Recipe Recipe { get; set; }
    }
}