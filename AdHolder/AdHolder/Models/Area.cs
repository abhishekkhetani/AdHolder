using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdHolder.Models
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("City")]
        public int CityRefId { get; set; }
        public City City { get; set; }

    }
}