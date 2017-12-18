using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdHolder.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Title")]
        public string ProductTitle { get; set; }
        
        [Required]
        [DisplayName("Product Description")]
        public string Description { get; set; }
        
        [Required]
        public string Image { get; set; }
        
        [Required]
        [DisplayName("Fare Per Day")]
        public int FarePerDay { get; set; }
        
        [Required]
        [DisplayName("Payment Option")]
        public int PaymentOption { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("City")]
        public int CityId { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("Area")]
        public int AreaId { get; set; }
    }
}