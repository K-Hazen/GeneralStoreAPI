using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Product
    {
        [Key]

        public int Id { get; set; }  //why to leave it just as ID --> because when you call it... it should clarify the name example product.Id

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]     //saying it cannot go below zero
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int QuantityOnHand { get; set; }
    }
}