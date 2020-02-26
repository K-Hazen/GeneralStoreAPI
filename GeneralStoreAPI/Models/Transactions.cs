using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }

        //giving the name of the other property in this class. Name of = turns () into a string, which allows us to refactor without having to manually change it (in this case "product)

        [ForeignKey(nameof(Product))]

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } //need to make a connection to customer class. A virtual object has funcationality but we can rewrite it/populate it. Acts as a placeholder
        
        public int CustomerId { get; set; }
        [ForeignKey(nameof(Customer))]  //this tells us that we have a connection with a foreign key relationship and place it inbetween so table is first
        public virtual Customer Customer { get; set; }

        
        public DateTime DateOfTransaction { get; set; }

        public decimal TotalCost   // could do => Product.Price * ProductCount; 
        {
            get
            {
                return Product.Price * ProductCount; 
            }
        }

        public int ProductCount { get; set; }

    }
}