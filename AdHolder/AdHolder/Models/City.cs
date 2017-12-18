using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdHolder.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }

        [NotMapped]
        [Required]
        public string AreaName { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}