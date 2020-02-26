using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //expression body. => <fat arrow, lamda) automatically returns whatever is on the right side of the arrow. Assumes it's just a get
        //This a ready only property - any read only properties will not need to be stored because they automatically get the value

        public string FullName => $"{FirstName} {LastName}";  


        public string Address { get; set; }

        [DataType(DataType.EmailAddress)] //we are plugging in to help us see what DataType it is supposed to be 
        public string Email { get; set; }
    }
}