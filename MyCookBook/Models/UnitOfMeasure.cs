using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCookBook.Models
{
     [Table("UnitOfMeasure")]
    public class UnitOfMeasure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitOfMeasureId { get; set; }

        [MaxLength(75)]
        [Required]
        public String Unit { get; set; }

        [MaxLength(10)]
        [Required]
        public String UnitAbreviation { get; set; }

    }
}