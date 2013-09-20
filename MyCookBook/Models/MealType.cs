using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCookBook.Models
{
    [Table("MealTypes")]
    public class MealType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealTypeId { get; set; }

        [Required]
        [MaxLength(25)]
        public String Name { get; set; }

        [MaxLength(255)]
        public String Description { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}