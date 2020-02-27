using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        //giving the name of the other property in this class. Name of = turns () into a string, which allows us to refactor without having to manually change it (in this case "product")

        //we use product instead of productId because we placed it above ProductID and it references the field immediatly below
        
        [ForeignKey(nameof(Product))]  //Or we could use [ForeignKey("Product")] ---> just passing in a string 
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; } //need to make a connection to product class. A virtual object has funcationality but we can rewrite it/populate it. Acts as a placeholder
        
        public int CustomerId { get; set; }

        //with foreign keys you have to name it to that it links with the other pair... so customer Id + customer because its below cusomter ID

        [ForeignKey(nameof(CustomerId))]  
        public virtual Customer Customer { get; set; }

        
        public DateTime DateOfTransaction { get; set; }

        public decimal TotalCost   // could do => Product.Price * ProductCount; 
        {
            get
            {
                return (Product != null) ? Product.Price * ProductCount : 0; //has to add this conditional statement so that it would evaluate if it was null or not
            }
        }

        public int ProductCount { get; set; }

    }
}