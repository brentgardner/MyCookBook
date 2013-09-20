using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCookBook.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(55)]
        public String Name { get; set; }

        [MaxLength(255)]
        public String Descritpion { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}